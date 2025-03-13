using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Bll.Managers.Concretes;
using Project.Entities.Enums;
using Project.Entities.Models;
using Project.MvcUI.Models.PureVms.Reservations.RequestModels;
using Project.MvcUI.Models.PureVms.Reservations.ResponseModels;
using System.Security.Claims;

namespace Project.MvcUI.Controllers
{
    [Authorize] // Kullanıcı girişi zorunlu
    public class ReservationController : Controller
    {
        private readonly IReservationManager _reservationManager;
        private readonly IEmployeeManager _employeeManager;
        private readonly IRoomManager _roomManager;
        private readonly IPackageManager _packageManager;
        private readonly IExtraServiceManager _extraServiceManager;
        private readonly IReservationExtraServiceManager _reservationExtraServiceManager;

        public ReservationController(
            IReservationManager reservationManager,
            IEmployeeManager employeeManager,
            IRoomManager roomManager,
            IPackageManager packageManager,
            IExtraServiceManager extraServiceManager,
            IReservationExtraServiceManager reservationExtraServiceManager)
        {
            _reservationManager = reservationManager;
            _employeeManager = employeeManager;
            _roomManager = roomManager;
            _packageManager = packageManager;
            _extraServiceManager = extraServiceManager;
            _reservationExtraServiceManager = reservationExtraServiceManager;
        }

        // GET: /Reservation/Create
        public async Task<IActionResult> Create()
        {
            // Kat bilgilerini hazırlıyoruz
            var floorsInfo = new Dictionary<int, string>
            {
                { 1, "Tek Kişilik ve Üç Kişilik Odalar - Minibar bulunmamaktadır." },
                { 2, "Tek Kişilik ve İki Kişilik Odalar - Klima, TV, Saç Kurutma Makinesi, Kablosuz İnternet mevcut." },
                { 3, "Çift Kişilik (Duble) ve Üç Kişilik Odalar - Balkonlu, Minibar, Tüm olanaklar mevcut." },
                { 4, "Çift Kişilik (Duble), Dört Kişilik ve Kral Dairesi - Balkon, Minibar, Tüm olanaklar mevcut." }
            };

            ViewBag.FloorsInfo = floorsInfo;
            await LoadSelectListsAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservationCreateRequestModel model)
        {
            string dateValidationError = _reservationManager.ValidateReservationDates(model.StartDate, model.EndDate);
            if (dateValidationError != null)
            {
                ModelState.AddModelError("", dateValidationError);
                await LoadSelectListsAsync();
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                await LoadSelectListsAsync();
                return View(model);
            }

            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            // DTO'ya mapping yaparak rezervasyon oluşturuyoruz.
            ReservationDto dto = new ReservationDto
            {
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                RoomId = model.RoomId,
                PackageId = model.PackageId,
                AppUserId = userId,
                ReservationStatus = ReservationStatus.PendingPayment,
                Status = DataStatus.Inserted
            };

            var employees = await _employeeManager.GetAllAsync();
            if (employees.Any())
            {
                var random = new Random();
                var randomEmployee = employees[random.Next(employees.Count)];
                dto.EmployeeId = randomEmployee.Id;
            }
            else
            {
                dto.EmployeeId = null;
            }

            string resultMessage = await _reservationManager.CreateReservation(dto);

            if (resultMessage == "Rezervasyon başarıyla oluşturuldu.")
            {
                TempData["SuccessMessage"] = resultMessage;

                // Yeni rezervasyonun ID'sini alıyoruz.
                var createdReservation = await _reservationManager.GetLatestReservationByUserId(userId);

                // Kullanıcıyı ekstra hizmet seçimi sayfasına yönlendiriyoruz.
                return RedirectToAction("SelectExtras", new { reservationId = createdReservation.Id });
            }
            else
            {
                ModelState.AddModelError("", resultMessage);
                await LoadSelectListsAsync();
                return View(model);
            }
        }

        // Seçim listelerini yüklemek için yardımcı metot.
        private async Task LoadSelectListsAsync(int? selectedRoomId = null, int? selectedPackageId = null, List<int> selectedExtraServiceIds = null)
        {
            var allRooms = await _roomManager.GetAllAsync();
            var filteredRooms = allRooms
                .Where(r => r.RoomStatus == RoomStatus.Empty || r.Id == selectedRoomId) // Oda seçilmişse göster
                .Select(r => new SelectListItem
                {
                    Value = r.Id.ToString(),
                    Text = $"Kat {r.Floor} - Oda {r.RoomNumber} - {r.PricePerNight} TL"
                }).ToList();
            ViewBag.Rooms = new SelectList(filteredRooms, "Value", "Text", selectedRoomId);

            var packages = await _packageManager.GetAllAsync();
            ViewBag.Packages = new SelectList(packages, "Id", "Name", selectedPackageId);

            var extraServices = await _extraServiceManager.GetAllAsync();
            ViewBag.ExtraServices = extraServices.Select(es => new SelectListItem
            {
                Value = es.Id.ToString(),
                Text = $"{es.Name} - {es.Price} TL",
                Selected = selectedExtraServiceIds != null && selectedExtraServiceIds.Contains(es.Id)
            }).ToList();
        }

        // GET: /Reservation/SelectExtras/{reservationId}
        [HttpGet]
        public async Task<IActionResult> SelectExtras(int reservationId)
        {
            // Seçilen rezervasyonu kontrol edelim
            var reservation = await _reservationManager.GetByIdAsync(reservationId);
            if (reservation == null)
            {
                return NotFound("Rezervasyon bulunamadı.");
            }

            // Ekstra hizmetleri alıp ViewBag üzerinden gönderiyoruz.
            var extraServices = await _extraServiceManager.GetAllAsync();
            ViewBag.ExtraServices = extraServices.Select(es => new SelectListItem
            {
                Value = es.Id.ToString(),
                Text = $"{es.Name} - {es.Price} TL"
            }).ToList();

            // Modeli view'a gönderiyoruz
            return View(new SelectExtrasRequestModel { ReservationId = reservationId });
        }

        // POST: /Reservation/SelectExtras
        [HttpPost]
        public async Task<IActionResult> SelectExtras(SelectExtrasRequestModel model)
        {
            if (model.ExtraServiceIds != null && model.ExtraServiceIds.Any())
            {
                var extraServices = model.ExtraServiceIds.Select(extraServiceId => new ReservationExtraServiceDto
                {
                    ReservationId = model.ReservationId,
                    ExtraServiceId = extraServiceId
                }).ToList();

                await _reservationExtraServiceManager.CreateRangeAsync(extraServices);
            }

            TempData["SuccessMessage"] = "Ekstra hizmetler başarıyla eklendi.";
            return RedirectToAction("Checkout", "Payment", new { reservationId = model.ReservationId });

        }



        // GET: /Reservation/MyReservations
        public async Task<IActionResult> MyReservations()
        {
            // Giriş yapan kullanıcının ID'sini alıyoruz
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            // Kullanıcıya ait rezervasyonları alıyoruz
            var reservations = await _reservationManager.GetReservationsByUserIdAsync(userId);

            // Veriyi ResponseModel'e taşıyoruz
            var responseModel = new ReservationListResponseModel
            {
                Reservations = reservations
            };

            // View'a iletmek için ResponseModel'i kullanıyoruz
            return View(responseModel); // View ile birlikte veriyi kullanıcıya sunuyoruz
        }


        public IActionResult Cancel(int id)
        {
            // İptal işlemi için onay sayfasını göstereceğiz
            return View(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmCancel(int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var reservation = await _reservationManager.GetByIdAsync(id);

            if (reservation == null || reservation.AppUserId != userId)
            {
                TempData["ErrorMessage"] = "Yetkisiz işlem. Sadece kendi rezervasyonlarınızı iptal edebilirsiniz.";
                return RedirectToAction("MyReservations");
            }

            if (reservation.ReservationStatus == ReservationStatus.Canceled)
            {
                TempData["ErrorMessage"] = "Bu rezervasyon zaten iptal edilmiş.";
                return RedirectToAction("MyReservations");
            }

            bool isPaymentConfirmed = reservation.ReservationStatus == ReservationStatus.Confirmed;

            if (isPaymentConfirmed)
            {
                // 🚀 **Ödeme iptali işlemi için PaymentController'a yönlendir**
                return RedirectToAction("CancelPaymentConfirm", "Payment", new { Id = reservation.Id });
            }

            // 🚀 **Ödeme yoksa rezervasyonu direkt iptal et**
            var result = await _reservationManager.CancelReservationAsync(id);

            if (result)
            {
                var existingServices = await _reservationExtraServiceManager.GetByReservationIdAsync(id);
                foreach (var service in existingServices)
                {
                    service.Status = DataStatus.Deleted;
                    service.DeletedDate = DateTime.Now;
                    await _reservationExtraServiceManager.UpdateDeletedAsync(service);
                }

                TempData["SuccessMessage"] = "Rezervasyonunuz ve ek hizmetler başarıyla iptal edilmiştir.";
            }
            else
            {
                TempData["ErrorMessage"] = "Bir hata oluştu. Lütfen tekrar deneyin.";
            }

            return RedirectToAction("MyReservations");
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var reservation = await _reservationManager.GetByIdAsync(id);

            if (reservation == null || reservation.AppUserId != userId) // Yetkisiz erişimi engelle
            {
                TempData["ErrorMessage"] = "Yetkisiz işlem. Sadece kendi rezervasyonlarınızı düzenleyebilirsiniz.";
                return RedirectToAction("MyReservations");
            }

            var model = new ReservationUpdateRequestModel
            {
                ReservationId = reservation.Id,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate,
                RoomId = reservation.RoomId,
                PackageId = reservation.PackageId,
                TotalPrice = reservation.TotalPrice,
                ExtraServiceIds = reservation.ExtraServices?.Select(es => es.ExtraServiceId).ToList() ?? new List<int>()
            };

            await LoadSelectListsAsync(model.RoomId, model.PackageId, model.ExtraServiceIds);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ReservationUpdateRequestModel model)
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
                return RedirectToAction("MyReservations");
            }

            // Yeni oda ve tarihlerde müsaitlik kontrolü
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
                Status = DataStatus.Updated,
                ModifiedDate = DateTime.Now
            });

            if (updateResult)
            {
                await _reservationExtraServiceManager.UpdateExtraServicesForReservation(model.ReservationId, model.ExtraServiceIds);

                // ✅ Eski odanın durumunu "Empty" yap
                if (existingReservation.RoomId != model.RoomId)
                {
                    var oldRoom = await _roomManager.GetByIdAsync(existingReservation.RoomId);
                    if (oldRoom != null)
                    {
                        oldRoom.RoomStatus = RoomStatus.Empty;
                        await _roomManager.UpdateAsync(oldRoom);
                    }

                    // ✅ Yeni odanın durumunu "Occupied" yap
                    var newRoom = await _roomManager.GetByIdAsync(model.RoomId);
                    if (newRoom != null)
                    {
                        newRoom.RoomStatus = RoomStatus.Occupied;
                        await _roomManager.UpdateAsync(newRoom);
                    }
                }

                TempData["SuccessMessage"] = "Rezervasyon başarıyla güncellendi.";
                return RedirectToAction("MyReservations");
            }

            ModelState.AddModelError("", "Rezervasyon güncellenirken bir hata oluştu.");
            await LoadSelectListsAsync(model.RoomId, model.PackageId, model.ExtraServiceIds);
            return View(model);
        }


        private async Task LoadPackagesAsync(int? selectedPackageId = null)
        {
            var packages = await _packageManager.GetAllAsync();
            ViewBag.Packages = new SelectList(packages, "Id", "Name", selectedPackageId);
        }
    }
}