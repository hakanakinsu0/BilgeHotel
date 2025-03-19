using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Bll.Managers.Concretes;
using Project.Entities.Enums;
using Project.Entities.Models;
using Project.MvcUI.Areas.Admin.Models.RequestModels.Reservations;
using Project.MvcUI.Areas.Admin.Models.ResponseModels;
using System;

//using Project.MvcUI.Areas.Admin.Models.ResponseModels.Reservations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")] // 🔐 Sadece Admin yetkisi olanlar erişebilir
    public class ReservationController : Controller
    {
        private readonly IReservationManager _reservationManager;
        private readonly IReservationExtraServiceManager _reservationExtraServiceManager;
        private readonly IExtraServiceManager _extraServiceManager;
        private readonly IAppUserManager _appUserManager;
        private readonly IAppUserProfileManager _appUserProfileManager; // ✅ Kullanıcı profilleri için eklendi
        private readonly IRoomManager _roomManager; // ✅ Oda bilgileri için eklendi
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
            _appUserProfileManager = appUserProfileManager; // ✅ eklenmişti zaten
            _roomManager = roomManager;
            _reservationExtraServiceManager = reservationExtraServiceManager; // ✅ düzeltildi, doğru yere eklendi
            _packageManager = packageManager;
            _extraServiceManager = extraServiceManager;
            _paymentManager = paymentManager; ;
        }

        public async Task<IActionResult> Index(string search, int? roomId, string status, bool? isPaid)
        {
            var reservations = await _reservationManager.GetAllAsync(); // ✅ DTO verisini çekiyoruz

            // **Eksik Bilgileri Tamamlıyoruz**
            foreach (var reservation in reservations)
            {
                // ✅ Kullanıcı bilgilerini çekiyoruz
                if (reservation.AppUserId.HasValue)
                {
                    var user = await _appUserManager.GetByIdAsync(reservation.AppUserId.Value);
                    var userProfile = await _appUserProfileManager.GetByAppUserIdAsync(reservation.AppUserId.Value);

                    if (user != null && userProfile != null)
                    {
                        reservation.CustomerName = $"{userProfile.FirstName} {userProfile.LastName}";
                        reservation.CustomerEmail = user.Email;
                    }
                    else
                    {
                        reservation.CustomerName = "Bilinmeyen Kullanıcı";
                        reservation.CustomerEmail = "Email Yok";
                    }
                }
                else
                {
                    reservation.CustomerName = "Anonim Kullanıcı";
                    reservation.CustomerEmail = "Email Yok";
                }

                // ✅ Oda bilgilerini çekiyoruz
                var room = await _roomManager.GetByIdAsync(reservation.RoomId);
                reservation.RoomNumber = room != null ? room.RoomNumber.ToString() : "Bilinmeyen Oda";
                // ✅ Ekstra hizmetlerin isimlerini çekiyoruz

            }

            // **Kullanıcı Adı / E-Posta ile Arama**
            if (!string.IsNullOrEmpty(search))
            {
                reservations = reservations.Where(r =>
                    r.CustomerName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    r.CustomerEmail.Contains(search, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }

            // **Oda Numarasına Göre Filtreleme**
            if (roomId.HasValue)
            {
                reservations = reservations.Where(r => r.RoomNumber == roomId.ToString()).ToList();
            }

            // **Rezervasyon Durumuna Göre Filtreleme**
            if (!string.IsNullOrEmpty(status))
            {
                reservations = reservations.Where(r => r.ReservationStatus.ToString() == status).ToList();
            }

            // **Ödeme Durumuna Göre Filtreleme (`IsPaid` yerine `ReservationStatus` kullanılıyor)**
            if (isPaid.HasValue)
            {
                reservations = reservations.Where(r =>
                    isPaid.Value ? r.ReservationStatus == ReservationStatus.Confirmed : r.ReservationStatus == ReservationStatus.PendingPayment
                ).ToList();
            }

            // **ViewModel'e Dönüştürme (ReservationDto -> ReservationListRequestModel)**
            var model = new ReservationListResponseModel
            {
                Reservations = reservations.Select(r => new ReservationListRequestModel
                {
                    Id = r.Id,
                    CustomerName = r.CustomerName, // 🔥 Artık AppUserProfile'dan çekiliyor
                    CustomerEmail = r.CustomerEmail, // 🔥 Artık AppUser'dan çekiliyor
                    RoomNumber = r.RoomNumber, // 🔥 Artık RoomManager'dan çekiliyor
                    StartDate = r.StartDate,
                    EndDate = r.EndDate,
                    TotalPrice = r.TotalPrice,
                    IsPaid = r.ReservationStatus == ReservationStatus.Confirmed,
                    ReservationStatus = r.ReservationStatus.ToString()
                }).ToList()
            };

            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var reservation = await _reservationManager.GetByIdAsync(id);
            if (reservation == null)
            {
                TempData["ErrorMessage"] = "Rezervasyon bulunamadı.";
                return RedirectToAction("Index");
            }

            // ✅ Kullanıcı bilgilerini çekiyoruz
            string customerName = "Anonim Kullanıcı";
            string customerEmail = "Email Yok";

            if (reservation.AppUserId.HasValue)
            {
                var user = await _appUserManager.GetByIdAsync(reservation.AppUserId.Value);
                var userProfile = await _appUserProfileManager.GetByAppUserIdAsync(reservation.AppUserId.Value);

                if (user != null && userProfile != null)
                {
                    customerName = $"{userProfile.FirstName} {userProfile.LastName}";
                    customerEmail = user.Email;
                }
            }

            // ✅ Rezervasyona ait ekstra servisleri çekiyoruz (Deleted olanları getirme)
            var existingExtraServices = await _reservationExtraServiceManager.GetByReservationIdAsync(reservation.Id);
            var selectedExtraServiceIds = existingExtraServices
                .Where(es => es.Status != DataStatus.Deleted) // ❌ Deleted olanları listeleme
                .Select(es => es.ExtraServiceId)
                .ToList();

            var model = new ReservationUpdateRequestModel
            {
                ReservationId = reservation.Id,
                CustomerName = customerName,
                CustomerEmail = customerEmail,
                RoomId = reservation.RoomId,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate,
                PackageId = reservation.PackageId,
                ExtraServiceIds = selectedExtraServiceIds, // ✅ Seçili ekstra hizmetleri ekledik
                ReservationStatus = reservation.ReservationStatus
            };

            await LoadSelectListsAsync(model.RoomId, model.PackageId, model.ExtraServiceIds);
            ViewBag.ReservationStatuses = new SelectList(Enum.GetValues(typeof(ReservationStatus))); // ✅ Rezervasyon durumlarını dropdown için ekledik
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ReservationUpdateRequestModel model, bool ReactivateReservation = false)
        {
            if (!ModelState.IsValid)
            {
                await LoadSelectListsAsync(model.RoomId, model.PackageId, model.ExtraServiceIds);
                return View(model);
            }

            var existingReservation = await _reservationManager.GetByIdAsync(model.ReservationId);
            if (existingReservation == null)
            {
                TempData["ErrorMessage"] = "Rezervasyon bulunamadı.";
                return RedirectToAction("Index");
            }

            // **Oda değişikliği olup olmadığını kontrol et**
            if (existingReservation.RoomId != model.RoomId)
            {
                // **Eski odanın durumunu boş olarak güncelle**
                await _roomManager.UpdateRoomStatusAsync(existingReservation.RoomId, RoomStatus.Empty);

                // **Yeni odanın durumunu dolu olarak güncelle**
                await _roomManager.UpdateRoomStatusAsync(model.RoomId, RoomStatus.Occupied);
            }

            // **Tarihler için oda doluluk kontrolü**
            bool isAvailable = _reservationManager.CheckAvailabilityForUpdate(
                model.ReservationId, model.RoomId, model.StartDate, model.EndDate);

            if (!isAvailable)
            {
                ModelState.AddModelError("", "Seçtiğiniz tarihler arasında oda dolu.");
                await LoadSelectListsAsync(model.RoomId, model.PackageId, model.ExtraServiceIds);
                return View(model);
            }

            decimal updatedPrice = _reservationManager.CalculateUpdatedPrice(model.RoomId, model.StartDate, model.EndDate, model.PackageId);

            var updateResult = await _reservationManager.UpdateReservationAsync(new ReservationDto
            {
                Id = model.ReservationId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                RoomId = model.RoomId,
                PackageId = model.PackageId,
                TotalPrice = updatedPrice,
                ReservationStatus = existingReservation.ReservationStatus,
                Status = DataStatus.Updated,
                ModifiedDate = DateTime.Now
            });

            if (updateResult)
            {
                await _reservationExtraServiceManager.UpdateExtraServicesForReservation(model.ReservationId, model.ExtraServiceIds);

                // ✅ Eğer checkbox işaretlendiyse rezervasyonu aktif yap
                if (ReactivateReservation)
                {
                    await _reservationManager.ReactivateReservationAsync(model.ReservationId);
                }

                TempData["SuccessMessage"] = "Rezervasyon ve ekstra hizmetler başarıyla güncellendi.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Rezervasyon güncellenirken bir hata oluştu.");
            await LoadSelectListsAsync(model.RoomId, model.PackageId, model.ExtraServiceIds);
            return View(model);
        }



        public async Task<IActionResult> PaymentUpdate(int id)
        {
            var reservation = await _reservationManager.GetByIdAsync(id);
            if (reservation == null)
            {
                TempData["ErrorMessage"] = "Rezervasyon bulunamadı.";
                return RedirectToAction("Index");
            }

            // ✅ Müşteri Bilgisini Al
            string customerName = "Bilinmeyen Müşteri";
            if (reservation.AppUserId.HasValue)
            {
                var userProfile = await _appUserProfileManager.GetByAppUserIdAsync(reservation.AppUserId.Value);
                if (userProfile != null)
                {
                    customerName = $"{userProfile.FirstName} {userProfile.LastName}";
                }
            }

            // ✅ Oda Bilgisini Al
            var room = await _roomManager.GetByIdAsync(reservation.RoomId);
            string roomNumber = room != null ? room.RoomNumber : "Bilinmeyen Oda";

            var model = new ReservationPaymentUpdateRequestModel
            {
                ReservationId = reservation.Id,
                CustomerName = customerName, // ✅ Güncellendi
                RoomNumber = roomNumber,     // ✅ Güncellendi
                CurrentStatus = reservation.ReservationStatus
            };

            ViewBag.PaymentStatuses = new SelectList(Enum.GetValues(typeof(ReservationStatus)).Cast<ReservationStatus>());

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PaymentUpdate(ReservationPaymentUpdateRequestModel model)
        {
            var reservation = await _reservationManager.GetByIdAsync(model.ReservationId);


            if (reservation == null)
            {
                TempData["ErrorMessage"] = "Rezervasyon bulunamadı.";
                return RedirectToAction("Index");
            }

            // ✅ ReservationId'ye göre payment çekiliyor
            var payments = await _paymentManager.GetAllAsync();
            var payment = payments.FirstOrDefault(p => p.ReservationId == model.ReservationId);

            if (payment == null)
            {
                TempData["ErrorMessage"] = "Rezervasyona ait ödeme bilgisi bulunamadı.";
                return RedirectToAction("Index");
            }

            // **Eski ve yeni ödeme durumlarını al**
            var oldStatus = reservation.ReservationStatus;
            var newStatus = model.NewStatus;

            // **Rezervasyon durumunu güncelle**
            reservation.ReservationStatus = newStatus;

            // **Status Güncelleme Kuralları**
            if (newStatus == ReservationStatus.Canceled)
            {
                reservation.Status = DataStatus.Deleted;
                reservation.DeletedDate = DateTime.Now;
                reservation.ModifiedDate = null;

                payment.Status = DataStatus.Deleted;
                payment.DeletedDate = DateTime.Now;
                payment.ModifiedDate = null;

                // ✅ Oda boşaltılmalı
                await _roomManager.UpdateRoomStatusAsync(reservation.RoomId, RoomStatus.Empty);
            }
            else if (newStatus == ReservationStatus.PendingPayment || newStatus == ReservationStatus.Confirmed)
            {
                reservation.Status = DataStatus.Updated;
                reservation.ModifiedDate = DateTime.Now;
                reservation.DeletedDate = null;

                payment.Status = DataStatus.Updated;
                payment.ModifiedDate = DateTime.Now;
                payment.DeletedDate = null;

                // ✅ Oda dolu olmalı (Eğer daha önce boşaltıldıysa)
                await _roomManager.UpdateRoomStatusAsync(reservation.RoomId, RoomStatus.Occupied);
            }

            await _reservationManager.UpdateAsync(reservation);
            await _paymentManager.UpdateAsync(payment);

            TempData["SuccessMessage"] = "Ödeme durumu başarıyla güncellendi.";
            return RedirectToAction("Index");
        }


        private async Task LoadSelectListsAsync(int? selectedRoomId = null, int? selectedPackageId = null, List<int> selectedExtraServiceIds = null)
        {
            var rooms = await _roomManager.GetAllAsync();
            ViewBag.Rooms = new SelectList(rooms, "Id", "RoomNumber", selectedRoomId);

            var packages = await _packageManager.GetAllAsync();
            ViewBag.Packages = new SelectList(packages, "Id", "Name", selectedPackageId);

            // Artık, aktif ekstra hizmetleri direkt manager üzerinden alıyoruz.
            var extraServices = _extraServiceManager.GetActives();
            ViewBag.ExtraServices = extraServices.Select(es => new SelectListItem
            {
                Value = es.Id.ToString(),
                Text = $"{es.Name} - {es.Price} TL",
                Selected = selectedExtraServiceIds != null && selectedExtraServiceIds.Contains(es.Id)
            }).ToList();

        }

    }
}
