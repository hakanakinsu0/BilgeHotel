using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Entities.Enums;
using Project.MvcUI.Areas.Admin.Models.PageVms.Reservations;
using Project.MvcUI.Areas.Admin.Models.RequestModels.Reservations;
using Project.MvcUI.Areas.Admin.Models.ResponseModels;

namespace Project.MvcUI.Areas.Admin.Controllers
{
    /// <summary>
    /// Admin panelinde rezervasyon işlemlerini yöneten controller'dır.
    /// Rezervasyon listesi, oluşturma, düzenleme, ödeme güncelleme ve detaylı hizmet yönetimi gibi işlemleri içerir.
    /// </summary>

    [Area("Admin")]
    [Authorize(Roles = "Admin")] 
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
        /// <param name="model">Rezervasyon filtre parametrelerini tutan request model.</param>
        /// <returns>Filtrelenmiş rezervasyonların UI modeline dönüştürülmüş listesi</returns>
        public async Task<IActionResult> Index(ReservationIndexPageView model)
        {
            // Kullanıcının arama ve filtre girişleri alınır
            string search = model.Search;
            bool? isPaid = model.IsPaid;
            ReservationStatus? status = model.Status;

            // BLL katmanından filtrelenmiş rezervasyon verileri çekilir
            List<ReservationDto> reservationDtos = await _reservationManager
                .GetFilteredReservationReportsAsync(search, isPaid, status);

            // DTO verileri ViewModel'e dönüştürülür
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

            // Rezervasyon durumu dropdown'u için enum değerleri Türkçe olarak ViewBag'e aktarılır
            ViewBag.Statuses = new List<SelectListItem>
            {
                new SelectListItem { Text = "Onaylandı", Value = ReservationStatus.Confirmed.ToString(), Selected = model.Status == ReservationStatus.Confirmed },
                new SelectListItem { Text = "Ödeme Bekleniyor", Value = ReservationStatus.PendingPayment.ToString(), Selected = model.Status == ReservationStatus.PendingPayment },
                new SelectListItem { Text = "İptal Edildi", Value = ReservationStatus.Canceled.ToString(), Selected = model.Status == ReservationStatus.Canceled },
            };

            // View'e filtrelenmiş ve dönüştürülmüş model gönderilir
            return View(model);
        }

        #endregion

        #region ReservationEdit

        /// <summary>
        /// Rezervasyon düzenleme formunu hazırlar.
        /// Belirtilen rezervasyonun bilgilerini BLL'den alır ve kullanıcı, ekstra hizmet gibi eksik bilgileri tamamlayarak
        /// ReservationUpdateRequestModel'e dönüştürür.
        /// </summary>
        /// <param name="id">Düzenlenecek rezervasyonun ID'si</param>
        /// <returns>Rezervasyon güncelleme formu view'i</returns>
        public async Task<IActionResult> Edit(int id)
        {
            // Belirtilen ID'ye sahip rezervasyon detaylı şekilde alınır
            ReservationDto reservation = await _reservationManager.GetDetailedReservationByIdAsync(id);
            if (reservation == null)
            {
                // Rezervasyon bulunamazsa kullanıcıya hata mesajı gösterilir
                TempData["ErrorMessage"] = "Rezervasyon bulunamadı.";
                return RedirectToAction("Index");
            }

            // Rezervasyona ait aktif ekstra hizmetler alınır
            List<ReservationExtraServiceDto> existingExtraServices = await _reservationExtraServiceManager.GetByReservationIdAsync(reservation.Id);
            List<int> selectedExtraServiceIds = existingExtraServices
                .Where(es => es.Status != DataStatus.Deleted)
                .Select(es => es.ExtraServiceId)
                .ToList();

            // ReservationDto → ReservationUpdateRequestModel dönüşümü yapılır
            var model = new ReservationUpdateRequestModel
            {
                ReservationId = reservation.Id,
                CustomerName = reservation.CustomerName,
                CustomerEmail = reservation.CustomerEmail,
                RoomId = reservation.RoomId,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate,
                PackageId = reservation.PackageId,
                ExtraServiceIds = selectedExtraServiceIds,
                ReservationStatus = reservation.ReservationStatus,
                ReactivateReservation = reservation.ReservationStatus != ReservationStatus.Canceled
            };

            // ViewBag üzerinden odalar, paketler ve ekstra hizmet dropdown'ları doldurulur
            await LoadSelectListsAsync(model.RoomId, model.PackageId, model.ExtraServiceIds);
            ViewBag.ReservationStatuses = new SelectList(Enum.GetValues(typeof(ReservationStatus)));

            return View(model);
        }

        /// <summary>
        /// Rezervasyon güncelleme işlemini gerçekleştirir.
        /// Model doğrulaması geçerse, BLL'deki UpdateReservationWithDetailsAsync metodu çağrılarak güncelleme yapılır.
        /// </summary>
        /// <param name="model">Rezervasyon güncelleme formu modeli</param>
        /// <param name="ReactivateReservation">Rezervasyonun tekrar aktif edilip edilmeyeceğini belirler</param>
        /// <returns>Güncelleme işleminin sonucu view'e gönderilir</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ReservationUpdateRequestModel model, bool ReactivateReservation = false)
        {
            // ModelState geçerli değilse form tekrar gösterilir
            if (!ModelState.IsValid)
            {
                await LoadSelectListsAsync(model.RoomId, model.PackageId, model.ExtraServiceIds);
                return View(model);
            }

            // BLL'deki güncelleme metodu çağrılarak rezervasyon ve hizmetler güncellenir
            bool updateResult = await _reservationManager.UpdateReservationWithDetailsAsync(new ReservationDto
            {
                Id = model.ReservationId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                RoomId = model.RoomId,
                PackageId = model.PackageId
                // Eğer gerekliyse DTO'ya ek alanlar burada set edilebilir
            }, model.ExtraServiceIds, ReactivateReservation);

            // Güncelleme başarılıysa kullanıcıya başarı mesajı gösterilir
            if (updateResult)
            {
                TempData["SuccessMessage"] = "Rezervasyon ve ekstra hizmetler başarıyla güncellendi.";
                return RedirectToAction("Index");
            }

            // Güncelleme başarısızsa form tekrar gösterilir
            await LoadSelectListsAsync(model.RoomId, model.PackageId, model.ExtraServiceIds);
            return View(model);
        }

        #endregion

        #region ReservationPaymentUpdate

        /// <summary>
        /// Rezervasyonun ödeme durumunu güncelleme formunu hazırlar.
        /// Rezervasyon, müşteri ve oda bilgileri alınarak form modeline atanır.
        /// </summary>
        /// <param name="id">Ödeme durumu güncellenecek rezervasyonun ID'si</param>
        /// <returns>Rezervasyon ödeme durumu güncelleme formunu içeren view</returns>
        public async Task<IActionResult> PaymentUpdate(int id)
        {
            // Rezervasyon bilgisi veritabanından alınır
            ReservationDto reservation = await _reservationManager.GetByIdAsync(id);
            if (reservation == null)
            {
                TempData["ErrorMessage"] = "Rezervasyon bulunamadı.";
                return RedirectToAction("Index");
            }

            // Müşteri adı oluşturulur (profil yoksa varsayılan gösterilir)
            string customerName = "Bilinmeyen Müşteri";
            if (reservation.AppUserId.HasValue)
            {
                AppUserProfileDto userProfile = await _appUserProfileManager.GetByAppUserIdAsync(reservation.AppUserId.Value);
                if (userProfile != null)
                {
                    customerName = $"{userProfile.FirstName} {userProfile.LastName}";
                }
            }

            // Oda numarası alınır (bulunamazsa varsayılan gösterilir)
            RoomDto room = await _roomManager.GetByIdAsync(reservation.RoomId);
            string roomNumber = room != null ? room.RoomNumber : "Bilinmeyen Oda";

            // Form model hazırlanır
            ReservationPaymentUpdateRequestModel model = new()
            {
                ReservationId = reservation.Id,
                CustomerName = customerName,
                RoomNumber = roomNumber,
                CurrentStatus = reservation.ReservationStatus,
                NewStatus = reservation.ReservationStatus // Varsayılan olarak mevcut durum seçili gelir
            };

            // ViewBag üzerinden dropdown için Türkçeleştirilmiş enum verisi hazırlanır
            ViewBag.PaymentStatuses = new List<SelectListItem>
            {
                new() { Value = ReservationStatus.Confirmed.ToString(), Text = "Onaylandı", Selected = reservation.ReservationStatus == ReservationStatus.Confirmed },
                new() { Value = ReservationStatus.PendingPayment.ToString(), Text = "Ödeme Bekleniyor", Selected = reservation.ReservationStatus == ReservationStatus.PendingPayment },
                new() { Value = ReservationStatus.Canceled.ToString(), Text = "İptal Edildi", Selected = reservation.ReservationStatus == ReservationStatus.Canceled },
            };

            return View(model);
        }

        /// <summary>
        /// Rezervasyonun ödeme durumunu günceller.
        /// Seçilen yeni ödeme durumu BLL üzerinden güncellenerek veritabanına işlenir.
        /// </summary>
        /// <param name="model">Formdan gelen ödeme durumu bilgilerini içeren model</param>
        /// <returns>Başarılıysa Index'e yönlendirir, aksi halde hata mesajı gösterir</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PaymentUpdate(ReservationPaymentUpdateRequestModel model)
        {
            try
            {
                // Seçilen yeni durum veritabanına işlenir
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
        /// Rezervasyon oluşturma ve düzenleme işlemleri için gerekli olan dropdown verilerini ViewBag'e yükler.
        /// Bu veriler form üzerinde oda, paket ve ekstra hizmet seçimleri için kullanılır.
        /// </summary>
        /// <param name="selectedRoomId">Varsayılan olarak seçili olacak oda ID'si (nullable)</param>
        /// <param name="selectedPackageId">Varsayılan olarak seçili olacak paket ID'si (nullable)</param>
        /// <param name="selectedExtraServiceIds">Varsayılan olarak seçili olacak ekstra hizmet ID'leri (nullable liste)</param>
        /// <returns>Asenkron Task işlemi</returns>
        private async Task LoadSelectListsAsync(int? selectedRoomId = null, int? selectedPackageId = null, List<int> selectedExtraServiceIds = null)
        {
            // Rezervasyon formunda kullanılmak üzere sistemdeki tüm odalar getirilir.
            List<RoomDto> rooms = await _roomManager.GetAllAsync();

            // Oda numaraları ViewBag.Rooms olarak SelectList'e dönüştürülür
            // Dropdown'da seçili olması istenen oda varsa selectedRoomId parametresiyle eşleştirilir.
            ViewBag.Rooms = new SelectList(rooms, "Id", "RoomNumber", selectedRoomId);

            // Kullanıcıya sunulacak paket seçenekleri (örneğin kahvaltı dahil, tam pansiyon vs.)
            List<PackageDto> packages = await _packageManager.GetAllAsync();

            // Paket isimleri ViewBag.Packages olarak SelectList'e dönüştürülür
            // Seçili paket varsa selectedPackageId kullanılır
            ViewBag.Packages = new SelectList(packages, "Id", "Name", selectedPackageId);

            // Ekstra hizmet listesi alınır (yalnızca aktif olanlar)
            List<ExtraServiceDto> extraServices = _extraServiceManager.GetActives();

            // Her ekstra hizmet için bir SelectListItem oluşturulur ve ViewBag.ExtraServices'a atanır
            // Eğer kullanıcının önceden seçtiği ekstra hizmetler varsa, bu ID'ler checked olarak işaretlenir
            ViewBag.ExtraServices = extraServices.Select(es => new SelectListItem
            {
                Value = es.Id.ToString(), // Dropdown için value
                Text = $"{es.Name} - {es.Price} TL", // Görüntülenecek metin
                Selected = selectedExtraServiceIds != null && selectedExtraServiceIds.Contains(es.Id) // Seçili kontrolü
            }).ToList();
        }

        #endregion
    }
}
