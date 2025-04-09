using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Entities.Enums;
using Project.Entities.Models;
using Project.MvcUI.Areas.Admin.Models.RequestModels.Rooms;
using Project.MvcUI.Areas.Admin.Models.ResponseModels.Rooms;

namespace Project.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")] 
    public class RoomController : Controller
    {
        private readonly IRoomManager _roomManager;
        private readonly IRoomTypeManager _roomTypeManager;
        private readonly IReservationManager _reservationManager;
        private readonly IMapper _mapper;

        public RoomController(IRoomManager roomManager, IReservationManager reservationManager, IRoomTypeManager roomTypeManager, IMapper mapper)
        {
            _roomManager = roomManager;
            _reservationManager = reservationManager;
            _roomTypeManager = roomTypeManager;
            _mapper = mapper;
        }

        #region RoomIndexAction

        // Oda listeleme ve filtreleme sayfası
        public async Task<IActionResult> Index(int? roomTypeId, string roomStatus, int? floor, decimal? minPrice, decimal? maxPrice, bool? hasReservation, int page = 1, int pageSize = 10)
        {
            Enum.TryParse(roomStatus, out RoomStatus parsedStatus); // RoomStatus string'ini enum'a çevir

            // Filtre kriterlerine göre DTO oluştur
            RoomDto filterDto = new()
            {
                RoomTypeId = roomTypeId ?? 0,
                FilterRoomStatus = !string.IsNullOrEmpty(roomStatus) ? parsedStatus : null,
                Floor = floor ?? 0,
                PricePerNight = minPrice ?? 0,
                MaxPrice = maxPrice,
                FilterIsReserved = hasReservation,
                Page = page,
                PageSize = pageSize
            };

            List<RoomDto> rooms = await _roomManager.GetFilteredRoomsAsync(filterDto);
            int totalPages = (int)Math.Ceiling((double)filterDto.TotalRooms / pageSize);

            // ViewBag verilerini doldur
            List<RoomTypeDto> roomTypes = await _roomTypeManager.GetAllAsync();
            ViewBag.RoomTypes = new SelectList(roomTypes, "Id", "Name");
            ViewBag.Floors = new SelectList(rooms.Select(r => r.Floor).Distinct());
            ViewBag.Statuses = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = RoomStatus.Empty.ToString(), Text = "Boş" },
                new SelectListItem { Value = RoomStatus.Occupied.ToString(), Text = "Dolu" },
                new SelectListItem { Value = RoomStatus.Maintenance.ToString(), Text = "Bakımda" }
            }, "Value", "Text", roomStatus);

            // ViewModel oluştur
            RoomListResponseModel model = new()
            {
                Rooms = rooms.Select(r => new RoomListItemResponseModel
                {
                    Id = r.Id,
                    RoomNumber = r.RoomNumber,
                    RoomType = r.RoomTypeName,
                    Floor = r.Floor,
                    PricePerNight = r.PricePerNight,
                    RoomStatus = r.RoomStatus.ToString(),
                    IsReserved = r.IsReserved,
                    HasBalcony = r.HasBalcony,
                    HasMinibar = r.HasMinibar,
                    HasAirConditioner = r.HasAirConditioner,
                    HasTV = r.HasTV,
                    HasHairDryer = r.HasHairDryer,
                    HasWifi = r.HasWifi
                }).ToList(),
                TotalPages = totalPages,
                CurrentPage = page,
                PageSize = pageSize
            };

            return View(model);
        }

        #endregion

        #region RoomCreateAction

        // Oda oluşturma sayfası (GET)
        public async Task<IActionResult> Create()
        {
            await LoadSelectListsAsync(); // Oda tipi dropdown'u
            return View();
        }

        // Oda oluşturma işlemi (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomCreateRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                await LoadSelectListsAsync();
                return View(model);
            }

            RoomDto existingRoom = await _roomManager.GetByRoomNumberAsync(model.RoomNumber);
            if (existingRoom != null)
            {
                ModelState.AddModelError("RoomNumber", "Bu oda numarası zaten kayıtlı.");
                await LoadSelectListsAsync();
                return View(model);
            }

            // Özel kurallar
            if (model.Floor == 1) model.HasBalcony = false;
            if (model.Floor == 3 || model.Floor == 4) model.HasBalcony = true;

            int? singleRoomTypeId = await _roomTypeManager.GetRoomTypeIdByNameAsync("Tek Kişilik");
            if (singleRoomTypeId.HasValue && model.RoomTypeId == singleRoomTypeId.Value)
                model.HasMinibar = false;

            model.HasWifi = true;

            RoomDto roomDto = _mapper.Map<RoomDto>(model);
            roomDto.RoomStatus = RoomStatus.Empty;
            roomDto.Status = DataStatus.Inserted;
            roomDto.CreatedDate = DateTime.Now;

            await _roomManager.CreateAsync(roomDto);

            TempData["SuccessMessage"] = "Oda başarıyla eklendi.";
            return RedirectToAction("Index");
        }

        #endregion

        #region RoomEditAction

        // Oda düzenleme sayfası (GET)
        public async Task<IActionResult> Edit(int id)
        {
            RoomDto room = await _roomManager.GetByIdAsync(id);
            if (room == null)
            {
                TempData["ErrorMessage"] = "Oda bulunamadı.";
                return RedirectToAction("Index");
            }

            RoomUpdateRequestModel model = _mapper.Map<RoomUpdateRequestModel>(room);
            await LoadSelectListsAsync(model.RoomTypeId);
            return View(model);
        }

        // Oda düzenleme işlemi (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RoomUpdateRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                await LoadSelectListsAsync(model.RoomTypeId);
                return View(model);
            }

            RoomDto existingRoom = await _roomManager.GetByIdAsync(model.RoomId);
            if (existingRoom == null)
            {
                TempData["ErrorMessage"] = "Oda bulunamadı.";
                return RedirectToAction("Index");
            }

            RoomTypeDto roomTypeExists = await _roomTypeManager.GetByIdAsync(model.RoomTypeId);
            if (roomTypeExists == null)
            {
                ModelState.AddModelError("RoomTypeId", "Geçersiz oda tipi seçildi.");
                await LoadSelectListsAsync(model.RoomTypeId);
                return View(model);
            }

            // Dolu oda ise bazı alanlar değiştirilemez
            if (existingRoom.RoomStatus == RoomStatus.Occupied)
            {
                model.RoomNumber = existingRoom.RoomNumber;
                model.RoomTypeId = existingRoom.RoomTypeId;
                model.Floor = existingRoom.Floor;
            }

            RoomDto roomDto = _mapper.Map<RoomDto>(model);
            roomDto.Id = model.RoomId;
            roomDto.RoomStatus = existingRoom.RoomStatus;
            roomDto.Status = DataStatus.Updated;
            roomDto.ModifiedDate = DateTime.Now;

            await _roomManager.UpdateAsync(roomDto);

            TempData["SuccessMessage"] = "Oda başarıyla güncellendi.";
            return RedirectToAction("Index");
        }

        #endregion

        #region RoomDeleteAction

        // Oda silme onay ekranı (GET)
        public async Task<IActionResult> Delete(int id)
        {
            RoomDto room = await _roomManager.GetByIdAsync(id);
            if (room == null)
            {
                TempData["ErrorMessage"] = "Oda bulunamadı.";
                return RedirectToAction("Index");
            }

            bool canDelete = await _roomManager.CanDeleteRoomAsync(id);

            RoomDeleteRequestModel model = new()
            {
                RoomId = room.Id,
                RoomNumber = room.RoomNumber,
                Floor = room.Floor,
                PricePerNight = room.PricePerNight,
                RoomTypeName = room.RoomTypeName,
                RoomStatus = room.RoomStatus,
                HasActiveReservations = !canDelete
            };

            return View(model);
        }

        // Oda silme işlemi (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RoomDeleteRequestModel model)
        {
            RoomDto room = await _roomManager.GetByIdAsync(model.RoomId);
            if (room == null)
            {
                TempData["ErrorMessage"] = "Oda bulunamadı.";
                return RedirectToAction("Index");
            }

            bool canDelete = await _roomManager.CanDeleteRoomAsync(model.RoomId);

            if (canDelete)
            {
                await _roomManager.MakePassiveAsync(room);
                TempData["SuccessMessage"] = $"Oda '{model.RoomNumber}' başarıyla silindi.";
            }
            else
            {
                room.RoomStatus = RoomStatus.Maintenance;
                room.Status = DataStatus.Updated;
                room.ModifiedDate = DateTime.Now;
                await _roomManager.UpdateAsync(room);

                TempData["WarningMessage"] = $"Oda '{model.RoomNumber}' silinemedi, ancak bakım moduna alındı.";
            }

            return RedirectToAction("Index");
        }

        #endregion

        #region RoomStatusUpdateAction

        // Oda durum güncelleme sayfası (GET)
        public async Task<IActionResult> StatusUpdate(int id)
        {
            RoomDto room = await _roomManager.GetByIdAsync(id);
            if (room == null)
            {
                TempData["ErrorMessage"] = "Oda bulunamadı.";
                return RedirectToAction("Index");
            }

            RoomStatusUpdateRequestModel model = new()
            {
                RoomId = room.Id,
                RoomNumber = room.RoomNumber,
                CurrentStatus = room.RoomStatus
            };

            ViewBag.Statuses = new SelectList(Enum.GetValues(typeof(RoomStatus)).Cast<RoomStatus>());
            return View(model);
        }

        // Oda durum güncelleme işlemi (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> StatusUpdate(RoomStatusUpdateRequestModel model)
        {
            try
            {
                await _roomManager.UpdateRoomStatusAsync(model.RoomId, model.NewStatus);
                TempData["SuccessMessage"] = "Oda durumu başarıyla güncellendi.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction("Index");
        }

        #endregion

        #region ControllerPrivateMethods

        // Oda tipi dropdown'u yükleyen yardımcı metot
        private async Task LoadSelectListsAsync(int? selectedRoomTypeId = null)
        {
            List<RoomTypeDto> roomTypes = await _roomTypeManager.GetAllAsync();
            List<RoomTypeDto> activeRoomTypes = roomTypes.Where(rt => rt.Status != DataStatus.Deleted).ToList();
            ViewBag.RoomTypes = new SelectList(activeRoomTypes, "Id", "Name", selectedRoomTypeId);
        }

        #endregion
    }
}