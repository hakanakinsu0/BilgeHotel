using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Entities.Enums;
using Project.MvcUI.Areas.Admin.Models.RequestModels.Reservations;
using Project.MvcUI.Areas.Admin.Models.ResponseModels;

namespace Project.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")] // Sadece Admin yetkisi olanlar erişebilir
    public class ReservationController : Controller
    {
        private readonly IReservationManager _reservationManager;
        private readonly IReservationExtraServiceManager _reservationExtraServiceManager;
        private readonly IExtraServiceManager _extraServiceManager;
        private readonly IAppUserManager _appUserManager;
        private readonly IAppUserProfileManager _appUserProfileManager; 
        private readonly IRoomManager _roomManager; 
        private readonly IPackageManager _packageManager;
        private readonly IPaymentManager _paymentManager;

        public ReservationController(
            IReservationManager reservationManager,
            IAppUserManager appUserManager,
            IAppUserProfileManager appUserProfileManager,
            IRoomManager roomManager,
            IReservationExtraServiceManager reservationExtraServiceManager,
            IPackageManager packageManager,
            IExtraServiceManager extraServiceManager,
            IPaymentManager paymentManager)
        {
            _reservationManager = reservationManager;
            _appUserManager = appUserManager;
            _appUserProfileManager = appUserProfileManager; 
            _roomManager = roomManager;
            _reservationExtraServiceManager = reservationExtraServiceManager; 
            _packageManager = packageManager;
            _extraServiceManager = extraServiceManager;
            _paymentManager = paymentManager; ;
        }

        #region ReservationIndex

        /// <summary>
        /// Rezervasyon listesini ve ilgili filtreleme işlemlerini gerçekleştirir.
        /// BLL'den eksik bilgileri tamamlanmış ve filtre parametrelerine göre filtrelenmiş rezervasyon DTO'larını alır,
        /// ardından bu verileri UI modeline dönüştürerek view'e gönderir.
        /// </summary>
        /// <param name="search">Kullanıcı adı veya e-posta araması</param>
        /// <param name="roomId">Oda numarasına göre filtre</param>
        /// <param name="status">Rezervasyon durumu filtre</param>
        /// <param name="isPaid">Ödeme durumu filtre (true: ödeme yapılmış, false: ödeme bekleniyor)</param>
        /// <returns>Filtrelenmiş rezervasyonların UI modeline dönüştürülmüş listesi</returns>
        public async Task<IActionResult> Index(string search, int? roomId, string status, bool? isPaid)
        {
            // BLL'den eksik bilgileri tamamlanmış ve filtre parametrelerine göre filtrelenmiş rezervasyon DTO'larını alıyoruz
            List<ReservationDto> reservations = await _reservationManager.GetFilteredReservationReportsAsync(search, roomId, status, isPaid);

            // Rezervasyon DTO'larını UI modeline dönüştürüyoruz
            ReservationListResponseModel model = new()
            {
                Reservations = reservations.Select(r => new ReservationListRequestModel
                {
                    Id = r.Id,
                    CustomerName = r.CustomerName,         // BLL'de tamamlanan müşteri adı
                    CustomerEmail = r.CustomerEmail,       // BLL'de tamamlanan e-posta
                    RoomNumber = r.RoomNumber,             // BLL'de tamamlanan oda numarası
                    StartDate = r.StartDate,
                    EndDate = r.EndDate,
                    TotalPrice = r.TotalPrice,
                    IsPaid = r.ReservationStatus == ReservationStatus.Confirmed,
                    ReservationStatus = r.ReservationStatus.ToString()
                }).ToList()
            };

            return View(model); // UI modelini view'e gönderir
        }

        #endregion

        #region ReservationEdit

        /// <summary>
        /// GET: Rezervasyon düzenleme formunu hazırlar.
        /// Belirtilen rezervasyonun bilgilerini BLL'den alır ve kullanıcı, ekstra hizmet gibi eksik bilgileri tamamlayarak
        /// ReservationUpdateRequestModel'e dönüştürür.
        /// </summary>
        /// <param name="id">Düzenlenecek rezervasyonun ID'si</param>
        /// <returns>Rezervasyon güncelleme formu view'i</returns>
        public async Task<IActionResult> Edit(int id)
        {
            // Rezervasyon bilgilerini BLL'den alıyoruz (ReservationDto)
            ReservationDto reservation = await _reservationManager.GetByIdAsync(id);
            if (reservation == null)
            {
                TempData["ErrorMessage"] = "Rezervasyon bulunamadı.";
                return RedirectToAction("Index");
            }

            // Kullanıcı bilgilerini tamamlıyoruz
            string customerName = "Anonim Kullanıcı";
            string customerEmail = "Email Yok";

            if (reservation.AppUserId.HasValue)
            {
                AppUserDto user = await _appUserManager.GetByIdAsync(reservation.AppUserId.Value);
                AppUserProfileDto userProfile = await _appUserProfileManager.GetByAppUserIdAsync(reservation.AppUserId.Value);

                if (user != null && userProfile != null)
                {
                    customerName = $"{userProfile.FirstName} {userProfile.LastName}";
                    customerEmail = user.Email;
                }
            }

            // Rezervasyona ait ekstra hizmetleri çekiyoruz (Deleted olanları hariç)
            List<ReservationExtraServiceDto> existingExtraServices = await _reservationExtraServiceManager.GetByReservationIdAsync(reservation.Id);
            List<int> selectedExtraServiceIds = existingExtraServices
                .Where(es => es.Status != DataStatus.Deleted) // Deleted olanları listeleme
                .Select(es => es.ExtraServiceId)
                .ToList();

            // UI modeline dönüştürüyoruz
            ReservationUpdateRequestModel model = new()
            {
                ReservationId = reservation.Id,
                CustomerName = customerName,
                CustomerEmail = customerEmail,
                RoomId = reservation.RoomId,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate,
                PackageId = reservation.PackageId,
                ExtraServiceIds = selectedExtraServiceIds, // Seçili ekstra hizmetler
                ReservationStatus = reservation.ReservationStatus
            };

            // Form için gerekli dropdown listeleri yüklüyoruz
            await LoadSelectListsAsync(model.RoomId, model.PackageId, model.ExtraServiceIds);
            ViewBag.ReservationStatuses = new SelectList(Enum.GetValues(typeof(ReservationStatus))); // Rezervasyon durumları
            return View(model);
        }

        /// <summary>
        /// POST: Rezervasyon güncelleme işlemini gerçekleştirir.
        /// Model doğrulaması geçerse, BLL'deki UpdateReservationWithDetailsAsync metodu çağrılarak güncelleme yapılır.
        /// </summary>
        /// <param name="model">Rezervasyon güncelleme formu modeli</param>
        /// <param name="ReactivateReservation">Rezervasyonun tekrar aktif edilip edilmeyeceğini belirler</param>
        /// <returns>Güncelleme işleminin sonucu view'e gönderilir</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ReservationUpdateRequestModel model, bool ReactivateReservation = false)
        {
            if (!ModelState.IsValid)
            {
                await LoadSelectListsAsync(model.RoomId, model.PackageId, model.ExtraServiceIds);
                return View(model);
            }

            // BLL'deki merkezi metodu çağırarak, tüm güncelleme işlemlerini gerçekleştiriyoruz
            bool updateResult = await _reservationManager.UpdateReservationWithDetailsAsync(new ReservationDto
            {
                Id = model.ReservationId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                RoomId = model.RoomId,
                PackageId = model.PackageId,
                // Diğer gerekli alanlar DTO'ya eklenmeli
            }, model.ExtraServiceIds, ReactivateReservation);

            if (updateResult)
            {
                TempData["SuccessMessage"] = "Rezervasyon ve ekstra hizmetler başarıyla güncellendi.";
                return RedirectToAction("Index");
            }

            await LoadSelectListsAsync(model.RoomId, model.PackageId, model.ExtraServiceIds);
            return View(model);
        }

        #endregion

        #region ReservationPaymentUpdate

        /// <summary>
        /// GET: Rezervasyonun ödeme durumunu güncelleme formunu hazırlar.
        /// Rezervasyon ve oda bilgileri ile mevcut ödeme durumunu gösterir.
        /// </summary>
        /// <param name="id">Rezervasyon ID'si</param>
        /// <returns>Ödeme güncelleme formu view'i</returns>
        public async Task<IActionResult> PaymentUpdate(int id)
        {
            // Rezervasyon bilgisini BLL'den alıyoruz
            ReservationDto reservation = await _reservationManager.GetByIdAsync(id);
            if (reservation == null)
            {
                TempData["ErrorMessage"] = "Rezervasyon bulunamadı.";
                return RedirectToAction("Index");
            }

            // Müşteri bilgisini alıyoruz
            string customerName = "Bilinmeyen Müşteri";
            if (reservation.AppUserId.HasValue)
            {
                AppUserProfileDto userProfile = await _appUserProfileManager.GetByAppUserIdAsync(reservation.AppUserId.Value);
                if (userProfile != null)
                {
                    customerName = $"{userProfile.FirstName} {userProfile.LastName}";
                }
            }

            // Oda bilgisini alıyoruz
            RoomDto room = await _roomManager.GetByIdAsync(reservation.RoomId);
            string roomNumber = room != null ? room.RoomNumber : "Bilinmeyen Oda";

            // UI modelini oluşturuyoruz
            ReservationPaymentUpdateRequestModel model = new()
            {
                ReservationId = reservation.Id,
                CustomerName = customerName,
                RoomNumber = roomNumber,
                CurrentStatus = reservation.ReservationStatus
            };

            // PaymentStatuses için dropdown listesi oluşturuyoruz
            ViewBag.PaymentStatuses = new SelectList(Enum.GetValues(typeof(ReservationStatus)).Cast<ReservationStatus>());
            return View(model);
        }

        /// <summary>
        /// POST: Rezervasyonun ödeme durumunu günceller.
        /// BLL'deki UpdateReservationPaymentStatusAsync metodu kullanılarak, rezervasyon ve ödeme durumu güncellenir.
        /// </summary>
        /// <param name="model">Ödeme güncelleme formu modeli</param>
        /// <returns>Güncelleme işleminin sonucu yönlendirme</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PaymentUpdate(ReservationPaymentUpdateRequestModel model)
        {
            try
            {
                // BLL'deki merkezi metodu çağırarak, rezervasyon ve ödeme durumunu güncelliyoruz.
                bool updateResult = await _reservationManager.UpdateReservationPaymentStatusAsync(model.ReservationId, model.NewStatus);

                TempData["SuccessMessage"] = "Ödeme durumu başarıyla güncellendi.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        #endregion

        #region ControllerPrivateMethods

        /// <summary>
        /// Formda kullanılacak SelectList'leri hazırlar.
        /// Oda, paket ve ekstra hizmetler için gerekli verileri ViewBag'e yükler.
        /// </summary>
        /// <param name="selectedRoomId">Seçili oda ID'si</param>
        /// <param name="selectedPackageId">Seçili paket ID'si</param>
        /// <param name="selectedExtraServiceIds">Seçili ekstra hizmet ID'lerinin listesi</param>
        /// <returns>Asenkron işlem için Task</returns>
        private async Task LoadSelectListsAsync(int? selectedRoomId = null, int? selectedPackageId = null, List<int> selectedExtraServiceIds = null)
        {
            List<RoomDto> rooms = await _roomManager.GetAllAsync();
            ViewBag.Rooms = new SelectList(rooms, "Id", "RoomNumber", selectedRoomId);

            List<PackageDto> packages = await _packageManager.GetAllAsync();
            ViewBag.Packages = new SelectList(packages, "Id", "Name", selectedPackageId);

            // Aktif ekstra hizmetleri alıyoruz.
            List<ExtraServiceDto> extraServices = _extraServiceManager.GetActives();
            ViewBag.ExtraServices = extraServices.Select(es => new SelectListItem
            {
                Value = es.Id.ToString(),
                Text = $"{es.Name} - {es.Price} TL",
                Selected = selectedExtraServiceIds != null && selectedExtraServiceIds.Contains(es.Id)
            }).ToList();
        }

        #endregion
    }
}
