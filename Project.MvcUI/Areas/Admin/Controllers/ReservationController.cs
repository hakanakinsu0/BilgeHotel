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
            // Filtre parametreleri
            string search = model.Search;
            bool? isPaid = model.IsPaid;

            // BLL'den filtreli liste çek 
            // (Dikkat: BLL tarafında da metot imzasını arındırdığınızı varsayıyoruz)
            List<ReservationDto> reservationDtos = await _reservationManager
                .GetFilteredReservationReportsAsync(search, isPaid);

            // DTO'ları, UI için "ReservationListRequestModel" haline dönüştür
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

            // Gerekirse ViewBag doldurma vs.
            return View(model);
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
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            // Rezervasyonu BLL'den detaylı şekilde çek
            ReservationDto reservation = await _reservationManager.GetDetailedReservationByIdAsync(id);
            if (reservation == null)
            {
                TempData["ErrorMessage"] = "Rezervasyon bulunamadı.";
                return RedirectToAction("Index");
            }

            // Rezervasyona ait ekstra hizmetleri al
            List<ReservationExtraServiceDto> existingExtraServices = await _reservationExtraServiceManager.GetByReservationIdAsync(reservation.Id);
            List<int> selectedExtraServiceIds = existingExtraServices
                .Where(es => es.Status != DataStatus.Deleted)
                .Select(es => es.ExtraServiceId)
                .ToList();

            // UI model
            var model = new ReservationUpdateRequestModel
            {
                ReservationId = reservation.Id,
                CustomerName = reservation.CustomerName,   // BLL’de zaten set edilmiş
                CustomerEmail = reservation.CustomerEmail, // BLL’de zaten set edilmiş
                RoomId = reservation.RoomId,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate,
                PackageId = reservation.PackageId,
                ExtraServiceIds = selectedExtraServiceIds,
                ReservationStatus = reservation.ReservationStatus
            };

            // Dropdown'ları dolduralım
            await LoadSelectListsAsync(model.RoomId, model.PackageId, model.ExtraServiceIds);
            ViewBag.ReservationStatuses = new SelectList(Enum.GetValues(typeof(ReservationStatus)));

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
        [HttpGet]
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

            // UI modelini oluşturuyoruz ve yeni ödeme durumu için varsayılan olarak mevcut durumu atıyoruz
            ReservationPaymentUpdateRequestModel model = new()
            {
                ReservationId = reservation.Id,
                CustomerName = customerName,
                RoomNumber = roomNumber,
                CurrentStatus = reservation.ReservationStatus,
                NewStatus = reservation.ReservationStatus // Varsayılan olarak mevcut durum gösterilsin
            };

            // PaymentStatuses için dropdown listesi oluşturuyoruz, model.NewStatus seçili olacak şekilde
            ViewBag.PaymentStatuses = new SelectList(Enum.GetValues(typeof(ReservationStatus)).Cast<ReservationStatus>(), model.NewStatus);
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
            List<ExtraServiceDto> extraServices =  _extraServiceManager.GetActives();
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
