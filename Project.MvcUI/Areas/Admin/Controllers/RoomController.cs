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
    [Authorize(Roles = "Admin")] // 🔐 Sadece Admin yetkisi olanlar erişebilir
    public class RoomController : Controller
    {
        private readonly IRoomManager _roomManager;
        private readonly IRoomTypeManager _roomTypeManager;
        private readonly IReservationManager _reservationManager;

        public RoomController(IRoomManager roomManager, IReservationManager reservationManager, IRoomTypeManager roomTypeManager)
        {
            _roomManager = roomManager;
            _reservationManager = reservationManager;
            _roomTypeManager = roomTypeManager;
        }

        public async Task<IActionResult> Index(int? roomTypeId, string status, int? floor, decimal? minPrice, decimal? maxPrice, bool? hasReservation, int page = 1, int pageSize = 10)
        {
            var rooms = await _roomManager.GetAllAsync();
            // ✅ Yalnızca silinmemiş odaları getiriyoruz
            rooms = rooms.Where(r => r.Status != DataStatus.Deleted).ToList();
            var roomTypes = await _roomTypeManager.GetAllAsync(); // ✅ RoomType verisi çekildi

            // ✅ Odanın rezervasyon durumunu belirleyelim (Boş, Dolu, Bakımda)
            foreach (var room in rooms)
            {
                // **Odaya ait rezervasyonu kontrol et**
                var reservation = await _reservationManager.GetByIdAsync(room.Id);

                // Eğer oda doluysa, durumu "Occupied" olarak güncelle
                //if (reservation != null && reservation.ReservationStatus != ReservationStatus.Canceled)
                if (room.RoomStatus == RoomStatus.Occupied)

                {
                    room.RoomStatus = RoomStatus.Occupied; // ✅ Oda artık dolu
                }

                else if (room.RoomStatus == RoomStatus.Maintenance)
                {
                    room.RoomStatus = RoomStatus.Maintenance; // ✅ Oda bakımda
                }
                else
                {
                    room.RoomStatus = RoomStatus.Empty; // ✅ Oda boş
                }

                // ✅ Odanın rezerve edilip edilmediğini kontrol et
                room.IsReserved = room.RoomStatus == RoomStatus.Occupied;
            }

            // ✅ Filtreleme işlemleri
            if (roomTypeId.HasValue) rooms = rooms.Where(r => r.RoomTypeId == roomTypeId.Value).ToList();
            if (!string.IsNullOrEmpty(status) && Enum.TryParse(status, out RoomStatus roomStatus)) rooms = rooms.Where(r => r.RoomStatus == roomStatus).ToList();
            if (floor.HasValue) rooms = rooms.Where(r => r.Floor == floor.Value).ToList();
            if (minPrice.HasValue) rooms = rooms.Where(r => r.PricePerNight >= minPrice.Value).ToList();
            if (maxPrice.HasValue) rooms = rooms.Where(r => r.PricePerNight <= maxPrice.Value).ToList();
            if (hasReservation.HasValue) rooms = rooms.Where(r => r.IsReserved == hasReservation.Value).ToList();

            // ✅ Sayfalama işlemi
            int totalRooms = rooms.Count;
            int totalPages = (int)Math.Ceiling((double)totalRooms / pageSize);
            rooms = rooms.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // ✅ ViewBag için seçenekleri doldur
            ViewBag.RoomTypes = new SelectList(roomTypes, "Id", "Name");
            ViewBag.Floors = new SelectList(rooms.Select(r => r.Floor).Distinct());
            ViewBag.Statuses = new SelectList(Enum.GetValues(typeof(RoomStatus)).Cast<RoomStatus>());

            // ✅ Response Model'e taşıma
            var model = new RoomListResponseModel
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


        public async Task<IActionResult> Create()
        {
            await LoadSelectListsAsync(); // Oda tipleri ve diğer seçenekleri doldur
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomCreateRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                await LoadSelectListsAsync();
                return View(model);
            }

            // ✅ Aynı oda numarası var mı kontrol edelim
            var existingRoom = await _roomManager.GetByRoomNumberAsync(model.RoomNumber);
            if (existingRoom != null)
            {
                ModelState.AddModelError("RoomNumber", "Bu oda numarası zaten kayıtlı.");
                await LoadSelectListsAsync();
                return View(model);
            }

            // **📌 Kat bilgisine göre özellikleri belirle**
            if (model.Floor == 1) model.HasBalcony = false; // 1. katta balkon yok
            if (model.Floor == 3 || model.Floor == 4) model.HasBalcony = true; // 3. ve 4. katta balkon var

            // **📌 Tek kişilik odalarda minibar yok**
            if (model.RoomTypeId == GetSingleRoomTypeId()) model.HasMinibar = false;

            // **📌 Tüm odalarda WiFi var (Default olarak true)**
            model.HasWifi = true;

            // ✅ Oda DTO oluşturma
            var roomDto = new RoomDto
            {
                RoomNumber = model.RoomNumber,
                Floor = model.Floor,
                PricePerNight = model.PricePerNight,
                RoomStatus = RoomStatus.Empty,
                RoomTypeId = model.RoomTypeId,
                HasBalcony = model.HasBalcony,
                HasMinibar = model.HasMinibar,
                HasAirConditioner = model.HasAirConditioner,
                HasTV = model.HasTV,
                HasHairDryer = model.HasHairDryer,
                HasWifi = model.HasWifi,
                Status = DataStatus.Inserted,
                CreatedDate = DateTime.Now
            };

            await _roomManager.CreateAsync(roomDto);

            TempData["SuccessMessage"] = "Oda başarıyla eklendi.";
            return RedirectToAction("Index");
        }

        /// <summary>
        /// **Tek kişilik oda tipinin ID'sini getirir**
        /// (Bunu veritabanından almak için bir metot yazılabilir)
        /// </summary>
        private int GetSingleRoomTypeId()
        {
            // Varsayılan olarak Tek Kişilik oda tipinin ID'si 1 olarak kabul ediliyor.
            return 1;
        }

        // ✅ SelectList'leri dolduran metot
        private async Task LoadSelectListsAsync()
        {
            var roomTypes = await _roomTypeManager.GetAllAsync();
            ViewBag.RoomTypes = new SelectList(roomTypes, "Id", "Name");
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var room = await _roomManager.GetByIdAsync(id);
            if (room == null)
            {
                TempData["ErrorMessage"] = "Oda bulunamadı.";
                return RedirectToAction("Index");
            }

            var model = new RoomUpdateRequestModel
            {
                RoomId = room.Id,
                RoomNumber = room.RoomNumber,
                Floor = room.Floor,
                PricePerNight = room.PricePerNight,
                RoomTypeId = room.RoomTypeId,
                RoomStatus = room.RoomStatus,
                HasBalcony = room.HasBalcony,
                HasMinibar = room.HasMinibar,
                HasAirConditioner = room.HasAirConditioner,
                HasTV = room.HasTV,
                HasHairDryer = room.HasHairDryer,
                HasWifi = room.HasWifi
            };

            await LoadSelectListsAsync(model.RoomTypeId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RoomUpdateRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                await LoadSelectListsAsync(model.RoomTypeId);
                return View(model);
            }

            var existingRoom = await _roomManager.GetByIdAsync(model.RoomId);
            if (existingRoom == null)
            {
                TempData["ErrorMessage"] = "Oda bulunamadı.";
                return RedirectToAction("Index");
            }

            // ✅ RoomType kontrolü (Geçerli bir oda tipi mi?)
            var roomTypeExists = await _roomTypeManager.GetByIdAsync(model.RoomTypeId);
            if (roomTypeExists == null)
            {
                ModelState.AddModelError("RoomTypeId", "Geçersiz oda tipi seçildi.");
                await LoadSelectListsAsync(model.RoomTypeId);
                return View(model);
            }

            // ✅ Eğer oda doluysa, belirli alanlar değiştirilemez
            if (existingRoom.RoomStatus == RoomStatus.Occupied)
            {
                model.RoomNumber = existingRoom.RoomNumber;
                model.RoomTypeId = existingRoom.RoomTypeId;
                model.Floor = existingRoom.Floor;
            }

            var roomDto = new RoomDto
            {
                Id = model.RoomId,
                RoomNumber = model.RoomNumber,
                Floor = model.Floor,
                PricePerNight = model.PricePerNight,
                RoomTypeId = model.RoomTypeId,
                RoomStatus = existingRoom.RoomStatus,
                HasBalcony = model.HasBalcony,
                HasMinibar = model.HasMinibar,
                HasAirConditioner = model.HasAirConditioner,
                HasTV = model.HasTV,
                HasHairDryer = model.HasHairDryer,
                HasWifi = model.HasWifi,
                Status = DataStatus.Updated,
                ModifiedDate = DateTime.Now
            };

            await _roomManager.UpdateAsync(roomDto);
            TempData["SuccessMessage"] = "Oda başarıyla güncellendi.";
            return RedirectToAction("Index");
        }

        // ✅ SelectList'leri dolduran metot
        private async Task LoadSelectListsAsync(int? selectedRoomTypeId = null)
        {
            var roomTypes = await _roomTypeManager.GetAllAsync();

            // ✅ Sadece aktif oda tiplerini getiriyoruz
            var activeRoomTypes = roomTypes.Where(rt => rt.Status != DataStatus.Deleted).ToList();

            ViewBag.RoomTypes = new SelectList(activeRoomTypes, "Id", "Name", selectedRoomTypeId);
        }



        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var room = await _roomManager.GetByIdAsync(id);
            if (room == null)
            {
                TempData["ErrorMessage"] = "Oda bulunamadı.";
                return RedirectToAction("Index");
            }

            var canDelete = await _roomManager.CanDeleteRoomAsync(id);

            var model = new RoomDeleteRequestModel
            {
                RoomId = room.Id,
                RoomNumber = room.RoomNumber,
                Floor = room.Floor,
                PricePerNight = room.PricePerNight,
                RoomTypeName = room.RoomTypeName,
                RoomStatus = room.RoomStatus,
                HasActiveReservations = !canDelete // Eğer silinemiyorsa, rezervasyon var demektir.
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await _roomManager.GetByIdAsync(id);
            if (room == null)
            {
                TempData["ErrorMessage"] = "Oda bulunamadı.";
                return RedirectToAction("Index");
            }

            var canDelete = await _roomManager.CanDeleteRoomAsync(id);

            if (canDelete)
            {
                await _roomManager.MakePassiveAsync(room); // ✅ Odayı pasife çek
                TempData["SuccessMessage"] = "Oda başarıyla silindi.";
            }
            else
            {
                // ✅ Oda silinemiyorsa, bakım moduna al
                room.RoomStatus = RoomStatus.Maintenance;
                await _roomManager.UpdateAsync(room); // ✅ Güncelleme metodunu kullanarak değişiklikleri kaydet

                TempData["WarningMessage"] = "Oda silinemedi, ancak bakım moduna alındı.";
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> StatusUpdate(int id)
        {
            var room = await _roomManager.GetByIdAsync(id);
            if (room == null)
            {
                TempData["ErrorMessage"] = "Oda bulunamadı.";
                return RedirectToAction("Index");
            }

            var model = new RoomStatusUpdateRequestModel
            {
                RoomId = room.Id,
                RoomNumber = room.RoomNumber,
                CurrentStatus = room.RoomStatus
            };

            ViewBag.Statuses = new SelectList(Enum.GetValues(typeof(RoomStatus)).Cast<RoomStatus>());

            return View(model);
        }

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













    }
}