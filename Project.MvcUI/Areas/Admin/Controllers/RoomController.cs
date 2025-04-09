using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Entities.Enums;
using Project.Entities.Models;
using Project.MvcUI.Areas.Admin.Models.PageVms.Reservations;
using Project.MvcUI.Areas.Admin.Models.RequestModels.Reservations;
using Project.MvcUI.Areas.Admin.Models.RequestModels.Rooms;
using Project.MvcUI.Areas.Admin.Models.ResponseModels.Rooms;

namespace Project.MvcUI.Areas.Admin.Controllers
{
    /// <summary>
    /// Admin panelinde oda (Room) işlemlerini yöneten controller'dır.
    /// Oda listeleme, filtreleme, oluşturma, düzenleme, silme ve durum güncelleme işlemlerini içerir.
    /// Ayrıca MVC View tarafında kullanılmak üzere gerekli ViewBag verilerini hazırlar.
    /// </summary>

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

        #region ReservationIndex

        /// <summary>
        /// Rezervasyon listesini filtreleme seçenekleriyle birlikte getirir.
        /// Arama (müşteri adı veya e-posta), ödeme durumu ve rezervasyon durumu gibi filtrelerle BLL'den veriler alınır.
        /// Veriler UI'a uygun response modele dönüştürülerek view'e gönderilir.
        /// </summary>
        /// <param name="model">Kullanıcının arama ve filtreleme seçimlerini içeren view modeli.</param>
        /// <returns>Filtrelenmiş rezervasyon listesi view'i</returns>
        public async Task<IActionResult> Index(ReservationIndexPageView model)
        {
            // Arama ve filtre parametreleri
            string search = model.Search;
            bool? isPaid = model.IsPaid;
            ReservationStatus? status = model.Status;

            // BLL'den filtrelenmiş rezervasyon verileri alınır
            List<ReservationDto> reservationDtos = await _reservationManager
                .GetFilteredReservationReportsAsync(search, isPaid, status);

            // DTO'lar view model'e dönüştürülür
            model.Reservations = reservationDtos.Select(r => new ReservationListRequestModel
            {
                Id = r.Id,
                CustomerName = r.CustomerName,
                CustomerEmail = r.CustomerEmail,
                RoomNumber = r.RoomNumber,
                StartDate = r.StartDate,
                EndDate = r.EndDate,
                TotalPrice = r.TotalPrice,
                IsPaid = (r.ReservationStatus == ReservationStatus.Confirmed),
                ReservationStatus = r.ReservationStatus.ToString()
            }).ToList();

            // Rezervasyon durumu dropdown'u için ViewBag verileri
            ViewBag.Statuses = new List<SelectListItem>
            {
                new SelectListItem { Text = "Onaylandı", Value = ReservationStatus.Confirmed.ToString(), Selected = model.Status == ReservationStatus.Confirmed },
                new SelectListItem { Text = "Ödeme Bekleniyor", Value = ReservationStatus.PendingPayment.ToString(), Selected = model.Status == ReservationStatus.PendingPayment },
                new SelectListItem { Text = "İptal Edildi", Value = ReservationStatus.Canceled.ToString(), Selected = model.Status == ReservationStatus.Canceled },
            };
            return View(model); // View'e response modeli gönderilir
        }

        #endregion

        #region RoomCreateAction

        /// <summary>
        /// Yeni oda oluşturma formunu gösterir.
        /// Oda tipi dropdown'u gibi veriler ViewBag üzerinden View'e aktarılır.
        /// </summary>
        public async Task<IActionResult> Create()
        {
            await LoadSelectListsAsync(); // Oda tipi listesi yükleniyor
            return View(); // Boş form gösterilir
        }

        /// <summary>
        /// Yeni oda oluşturma işlemini gerçekleştirir.
        /// Kullanıcıdan gelen form verileri doğrulanır, iş kurallarına göre düzenlenir ve veritabanına kaydedilir.
        /// </summary>
        /// <param name="model">Oluşturulacak oda bilgilerini içeren request model</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomCreateRequestModel model)
        {
            // Model doğrulaması başarısızsa form tekrar gösterilir
            if (!ModelState.IsValid)
            {
                await LoadSelectListsAsync();
                return View(model);
            }

            // Aynı oda numarası zaten kayıtlıysa hata döndürülür
            RoomDto existingRoom = await _roomManager.GetByRoomNumberAsync(model.RoomNumber);
            if (existingRoom != null)
            {
                ModelState.AddModelError("RoomNumber", "Bu oda numarası zaten kayıtlı.");
                await LoadSelectListsAsync();
                return View(model);
            }

            // Oda için varsayılan özelliklerin atanması (sabit gelen donanımlar)
            model.HasAirConditioner = true;
            model.HasTV = true;
            model.HasHairDryer = true;
            model.HasWifi = true;

            // Balkon sadece 3. ve 4. katta olur
            model.HasBalcony = (model.Floor == 3 || model.Floor == 4);

            // Tek kişilik odalarda minibar bulunmaz
            int? singleRoomTypeId = await _roomTypeManager.GetRoomTypeIdByNameAsync("Tek Kişilik");
            if (singleRoomTypeId.HasValue && model.RoomTypeId == singleRoomTypeId.Value)
                model.HasMinibar = false;

            // DTO dönüşümü ve ek metadata ayarları
            RoomDto roomDto = _mapper.Map<RoomDto>(model);
            roomDto.RoomStatus = RoomStatus.Empty; // Yeni oda boş olarak başlatılır
            roomDto.Status = DataStatus.Inserted;
            roomDto.CreatedDate = DateTime.Now;

            // Veritabanına kayıt işlemi
            await _roomManager.CreateAsync(roomDto);

            // Başarı mesajı ve yönlendirme
            TempData["SuccessMessage"] = "Oda başarıyla eklendi.";
            return RedirectToAction("Index");
        }

        #endregion

        #region RoomEditAction

        /// <summary>
        /// Oda düzenleme formunu gösterir.
        /// Belirtilen ID'ye sahip odanın bilgilerini getirerek, düzenleme formunu hazırlar.
        /// </summary>
        /// <param name="id">Düzenlenecek odanın ID'si</param>
        /// <returns>Oda bilgilerini içeren düzenleme formu</returns>
        public async Task<IActionResult> Edit(int id)
        {
            // Veritabanından ilgili oda bilgisi alınır
            RoomDto room = await _roomManager.GetByIdAsync(id);
            if (room == null)
            {
                // Oda bulunamazsa hata mesajı gösterilir
                TempData["ErrorMessage"] = "Oda bulunamadı.";
                return RedirectToAction("Index");
            }

            // DTO → RequestModel dönüşümü yapılır
            RoomUpdateRequestModel model = _mapper.Map<RoomUpdateRequestModel>(room);

            // Oda tipi dropdown'u doldurulur
            await LoadSelectListsAsync(model.RoomTypeId);

            // Form view'i gösterilir
            return View(model);
        }

        /// <summary>
        /// Oda düzenleme işlemini gerçekleştirir.
        /// Formdan gelen veriler doğrulanır, mevcut oda ile karşılaştırılır ve güncellenir.
        /// </summary>
        /// <param name="model">Kullanıcı tarafından gönderilen oda düzenleme formu modeli</param>
        /// <returns>Düzenleme işlemi sonrası yönlendirme veya tekrar form</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RoomUpdateRequestModel model)
        {
            // Model doğrulaması başarısızsa form yeniden gösterilir
            if (!ModelState.IsValid)
            {
                await LoadSelectListsAsync(model.RoomTypeId);
                return View(model);
            }

            // Güncellenecek mevcut oda veritabanından alınır
            RoomDto existingRoom = await _roomManager.GetByIdAsync(model.RoomId);
            if (existingRoom == null)
            {
                TempData["ErrorMessage"] = "Oda bulunamadı.";
                return RedirectToAction("Index");
            }

            // Seçilen oda tipi geçerli mi kontrol edilir
            RoomTypeDto roomTypeExists = await _roomTypeManager.GetByIdAsync(model.RoomTypeId);
            if (roomTypeExists == null)
            {
                ModelState.AddModelError("RoomTypeId", "Geçersiz oda tipi seçildi.");
                await LoadSelectListsAsync(model.RoomTypeId);
                return View(model);
            }

            // Eğer oda doluysa kritik alanların değişimine izin verilmez
            if (existingRoom.RoomStatus == RoomStatus.Occupied)
            {
                model.RoomNumber = existingRoom.RoomNumber;
                model.RoomTypeId = existingRoom.RoomTypeId;
                model.Floor = existingRoom.Floor;
            }

            // Model → DTO dönüşümü yapılır ve zorunlu alanlar set edilir
            RoomDto roomDto = _mapper.Map<RoomDto>(model);
            roomDto.Id = model.RoomId;
            roomDto.RoomStatus = existingRoom.RoomStatus; // Durum sabit tutulur
            roomDto.Status = DataStatus.Updated;
            roomDto.ModifiedDate = DateTime.Now;

            // Veritabanına güncelleme işlemi yapılır
            await _roomManager.UpdateAsync(roomDto);

            TempData["SuccessMessage"] = "Oda başarıyla güncellendi.";
            return RedirectToAction("Index");
        }

        #endregion

        #region RoomDeleteAction

        /// <summary>
        /// Oda silme onay ekranını gösterir.
        /// İlgili oda bilgisi alınarak kullanıcıya silme onayı formu gösterilir.
        /// </summary>
        /// <param name="id">Silinecek odanın ID değeri</param>
        /// <returns>Silme onayı formu view</returns>
        public async Task<IActionResult> Delete(int id)
        {
            // Silinmek istenen oda bilgisi veritabanından alınır
            RoomDto room = await _roomManager.GetByIdAsync(id);
            if (room == null)
            {
                // Oda bulunamazsa kullanıcıya hata mesajı gösterilir
                TempData["ErrorMessage"] = "Oda bulunamadı.";
                return RedirectToAction("Index");
            }

            // Odanın silinip silinemeyeceği kontrol edilir (aktif rezervasyon var mı?)
            bool canDelete = await _roomManager.CanDeleteRoomAsync(id);

            // Silme onayı formuna gönderilecek model oluşturulur
            RoomDeleteRequestModel model = new()
            {
                RoomId = room.Id,
                RoomNumber = room.RoomNumber,
                Floor = room.Floor,
                PricePerNight = room.PricePerNight,
                RoomTypeName = room.RoomTypeName,
                RoomStatus = room.RoomStatus,
                HasActiveReservations = !canDelete // Eğer silinemiyorsa aktif rezervasyon vardır
            };

            // Silme ekranı view'e gönderilir
            return View(model);
        }

        /// <summary>
        /// Oda silme işlemini gerçekleştirir.
        /// Eğer oda silinebilecek durumdaysa pasif yapılır; aksi halde bakım moduna alınır.
        /// </summary>
        /// <param name="model">Silinecek oda bilgilerini içeren model</param>
        /// <returns>Liste ekranına yönlendirme</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RoomDeleteRequestModel model)
        {
            // Odanın gerçekten var olup olmadığı tekrar kontrol edilir
            RoomDto room = await _roomManager.GetByIdAsync(model.RoomId);
            if (room == null)
            {
                TempData["ErrorMessage"] = "Oda bulunamadı.";
                return RedirectToAction("Index");
            }

            // Oda silinebilir durumda mı?
            bool canDelete = await _roomManager.CanDeleteRoomAsync(model.RoomId);

            if (canDelete)
            {
                // Silme işlemi: Oda pasif hale getirilir
                await _roomManager.MakePassiveAsync(room);
                TempData["SuccessMessage"] = $"Oda '{model.RoomNumber}' başarıyla silindi.";
            }
            else
            {
                // Silinemiyorsa durum "Bakımda" yapılır
                room.RoomStatus = RoomStatus.Maintenance;
                room.Status = DataStatus.Updated;
                room.ModifiedDate = DateTime.Now;

                await _roomManager.UpdateAsync(room);

                TempData["WarningMessage"] = $"Oda '{model.RoomNumber}' silinemedi, ancak bakım moduna alındı.";
            }

            // Liste ekranına dön
            return RedirectToAction("Index");
        }

        #endregion

        #region RoomStatusUpdateAction

        /// <summary>
        /// Belirtilen ID'ye sahip odanın durumunu güncellemek için formu hazırlar.
        /// Mevcut oda durumu modele aktarılır ve ViewBag üzerinden dropdown'a Türkçeleştirilmiş durumlar sağlanır.
        /// </summary>
        /// <param name="id">Durumu güncellenecek odanın ID değeri</param>
        /// <returns>Oda durum güncelleme formunu içeren view</returns>
        public async Task<IActionResult> StatusUpdate(int id)
        {
            // ID'ye göre oda bilgisi alınır
            RoomDto room = await _roomManager.GetByIdAsync(id);
            if (room == null)
            {
                TempData["ErrorMessage"] = "Oda bulunamadı.";
                return RedirectToAction("Index");
            }

            // View'e gönderilecek form modeli hazırlanır
            var model = new RoomStatusUpdateRequestModel
            {
                RoomId = room.Id,
                RoomNumber = room.RoomNumber,
                CurrentStatus = room.RoomStatus
            };

            // ViewBag üzerinden dropdown listesine Türkçeleştirilmiş oda durumları atanır
            ViewBag.Statuses = new SelectList(new List<SelectListItem>
            {
                new() { Value = RoomStatus.Empty.ToString(), Text = "Boş" },
                new() { Value = RoomStatus.Occupied.ToString(), Text = "Dolu" },
                new() { Value = RoomStatus.Maintenance.ToString(), Text = "Bakımda" }
            }, "Value", "Text", room.RoomStatus.ToString());

            // Güncelleme formu view'e gönderilir
            return View(model);
        }

        /// <summary>
        /// Oda durum güncelleme işlemini gerçekleştirir.
        /// BLL'deki güncelleme metodunu çağırarak seçilen yeni durumu veritabanına işler.
        /// </summary>
        /// <param name="model">Oda durum güncelleme form verileri</param>
        /// <returns>Başarılıysa Index'e yönlendirir, aksi halde hata mesajı gösterir</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> StatusUpdate(RoomStatusUpdateRequestModel model)
        {
            try
            {
                // Seçilen yeni durum veritabanına işlenir
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

        /// <summary>
        /// Oda oluşturma ve düzenleme sayfalarında kullanılmak üzere
        /// ViewBag üzerinden aktif oda tiplerini dropdown listesi olarak sağlar.
        /// </summary>
        /// <param name="selectedRoomTypeId">Seçili olarak gelmesi istenen oda tipi ID'si (nullable)</param>
        private async Task LoadSelectListsAsync(int? selectedRoomTypeId = null)
        {
            // Tüm oda tipleri veritabanından alınır
            List<RoomTypeDto> roomTypes = await _roomTypeManager.GetAllAsync();

            // Silinmemiş (aktif) oda tipleri filtrelenir
            List<RoomTypeDto> activeRoomTypes = roomTypes
                .Where(rt => rt.Status != DataStatus.Deleted)
                .ToList();

            // Dropdown listesi olarak ViewBag'e atanır
            ViewBag.RoomTypes = new SelectList(activeRoomTypes, "Id", "Name", selectedRoomTypeId);
        }

        #endregion
    }
}