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
    [Authorize(Roles = "Member")]

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

        #region CreateReservation

        /// <summary>
        /// Rezervasyon oluşturma sayfasını hazırlar. 
        /// Kat bilgilerini oluşturur ve gerekli seçim listelerini yükleyerek view'e gönderir.
        /// </summary>
        public async Task<IActionResult> Create()
        {
            // Kat bilgilerini içeren dictionary oluşturuluyor.
            var floorsInfo = new Dictionary<int, string>
            {
                { 1, "Tek Kişilik ve Üç Kişilik Odalar - Minibar bulunmamaktadır." },
                { 2, "Tek Kişilik ve İki Kişilik Odalar - Klima, TV, Saç Kurutma Makinesi, Kablosuz İnternet mevcut." },
                { 3, "Çift Kişilik (Duble) ve Üç Kişilik Odalar - Balkonlu, Minibar, Tüm olanaklar mevcut." },
                { 4, "Çift Kişilik (Duble), Dört Kişilik ve Kral Dairesi - Balkon, Minibar, Tüm olanaklar mevcut." }
            };

            // Oluşturulan kat bilgileri ViewBag üzerinden view'e aktarılıyor.
            ViewBag.FloorsInfo = floorsInfo;
            // Seçim listeleri (oda, paket, ekstra hizmetler vb.) yükleniyor.
            await LoadSelectListsAsync();
            return View();
        }

        /// <summary>
        /// Girdi tarihlerini doğrulayarak, isteği bir DTO'ya haritalandırır, rastgele bir resepsiyonist atar ve ReservationManager aracılığıyla yeni rezervasyonu oluşturur. 
        /// Başarılı ise kullanıcı ekstra hizmet seçimi sayfasına yönlendirilir; başarısız ise hata mesajı gösterilir.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservationCreateRequestModel model)
        {
            // Tarih validasyonu yapılıyor; eğer hata mesajı dönerse hata ekleniyor.
            string dateValidationError = _reservationManager.ValidateReservationDates(model.StartDate, model.EndDate);
            if (dateValidationError != null)
            {
                ModelState.AddModelError(string.Empty, dateValidationError); // Hata mesajı ModelState'e ekleniyor.
                await LoadSelectListsAsync(model.StartDate, model.EndDate, model.RoomId, model.PackageId); // Select listeler tekrar yükleniyor.
                return View(model); // Hatalı model ile view yeniden render ediliyor.
            }

            // Genel model validasyonu kontrol ediliyor.
            if (!ModelState.IsValid)
            {
                await LoadSelectListsAsync(model.StartDate, model.EndDate, model.RoomId, model.PackageId); // Select listeler tekrar yükleniyor.
                return View(model); // Model hataları varsa view yeniden render ediliyor.
            }

            // Giriş yapan kullanıcının ID'si alınıyor; ClaimTypes.NameIdentifier üzerinden alınıp int'e çevriliyor.
            int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value); // Kullanıcı ID'si alınır.

            // Formdan gelen verilerle ReservationDto oluşturuluyor.
            ReservationDto dto = new ReservationDto
            {
                StartDate = model.StartDate,                      // Giriş tarihi atanıyor.
                EndDate = model.EndDate,                          // Çıkış tarihi atanıyor.
                RoomId = model.RoomId,                            // Seçilen oda ID'si atanıyor.
                PackageId = model.PackageId,                      // Seçilen paket ID'si atanıyor.
                AppUserId = userId,                               // Kullanıcı ID'si atanıyor.
                ReservationStatus = ReservationStatus.PendingPayment, // Rezervasyon durumu "PendingPayment" olarak belirleniyor.
                Status = DataStatus.Inserted                     // Veri durumu "Inserted" olarak ayarlanıyor.
            };

            // Çalışan ataması: Resepsiyonist çalışan ID'si, manager üzerinden rastgele seçiliyor.
            int receptionistId = await _employeeManager.GetRandomReceptionistEmployeeIdAsync();
            dto.EmployeeId = receptionistId; // Çalışan ID'si DTO'ya ekleniyor.

            // Rezervasyon manager üzerinden rezervasyon oluşturuluyor ve sonuç mesajı alınıyor.
            string resultMessage = await _reservationManager.CreateReservation(dto);

            // Rezervasyon başarıyla oluşturulmuşsa:
            if (resultMessage == "Rezervasyon başarıyla oluşturuldu.")
            {
                TempData["SuccessMessage"] = resultMessage; // Success mesajı TempData'ya ekleniyor.

                // Kullanıcının son oluşturulan rezervasyonunu alıyoruz.
                ReservationDto createdReservation = await _reservationManager.GetLatestReservationByUserId(userId);

                // Kullanıcı, ekstra hizmet seçimi sayfasına yönlendiriliyor.
                return RedirectToAction("SelectExtras", new { reservationId = createdReservation.Id });
            }
            else
            {
                // Hata durumunda, hata mesajı ModelState'e ekleniyor.
                ModelState.AddModelError(string.Empty, resultMessage);
                await LoadSelectListsAsync(); // Select listeler tekrar yükleniyor.
                return View(model); // Hata mesajıyla view yeniden render ediliyor.
            }
        }

        #endregion

        #region SelectExtrasReservation

        /// <summary>
        /// Seçilen rezervasyona ait ekstra hizmet seçimi sayfasını hazırlar.
        /// Aktif ekstra hizmetler, SelectListItem olarak ViewBag üzerinden gönderilir.
        /// Request modeli, kullanıcıdan ekstra hizmet seçimlerini almak için kullanılır.
        /// </summary>
        /// <param name="reservationId">Rezervasyon ID'si</param>
        /// <returns>Ekstra hizmet seçim view'i</returns>
        public async Task<IActionResult> SelectExtras(int reservationId)
        {
            // Seçilen rezervasyonu kontrol ediyoruz.
            var reservation = await _reservationManager.GetByIdAsync(reservationId);
            if (reservation == null)
            {
                TempData["ErrorMessage"] = "Rezervasyon bulunamadı.";
                return RedirectToAction("MyReservations", "Reservation");
            }

            // Aktif ekstra hizmetleri alıyoruz.
            var extraServices = _extraServiceManager.GetActives();
            ViewBag.ExtraServices = extraServices.Select(es => new SelectListItem
            {
                Value = es.Id.ToString(),
                Text = $"{es.Name} - {es.Price} TL"
            }).ToList();

            // Request modeli oluşturuyoruz; sadece rezervasyon ID'sini set ediyoruz.
            var requestModel = new ReservationSelectExtrasRequestModel
            {
                ReservationId = reservationId
            };

            return View(requestModel);
        }

        /// <summary>
        /// Kullanıcının seçtiği ekstra hizmetleri işleyerek, rezervasyonun toplam fiyatını günceller
        /// ve işlemin sonucunu response modeli aracılığıyla bildirir.
        /// </summary>
        /// <param name="model">RezervasyonSelectExtrasRequestModel: ekstra hizmet seçim bilgileri</param>
        /// <returns>Başarılı ise Checkout sayfasına yönlendirir; aksi halde hata mesajı gösterir.</returns>
        [HttpPost]
        public async Task<IActionResult> SelectExtras(ReservationSelectExtrasRequestModel model)
        {
            // Response modeli oluşturuluyor.
            var responseModel = new ReservationSelectExtrasResponseModel();

            // Kullanıcı ekstra hizmet seçimi yapmışsa işlemleri gerçekleştiriyoruz.
            if (model.ExtraServiceIds != null && model.ExtraServiceIds.Any())
            {
                var extraServices = model.ExtraServiceIds.Select(id => new ReservationExtraServiceDto
                {
                    ReservationId = model.ReservationId,
                    ExtraServiceId = id
                }).ToList();

                // Seçilen ekstra hizmetleri ekliyoruz.
                await _reservationExtraServiceManager.CreateRangeAsync(extraServices);
                // Rezervasyonun toplam fiyatına ekstra hizmet ücretlerini ekliyoruz.
                await _reservationManager.UpdateReservationPriceWithExtraServices(model.ReservationId, model.ExtraServiceIds);

                responseModel.Success = true;
                responseModel.Message = "Ekstra hizmetler başarıyla eklendi.";
            }
            else
            {
                responseModel.Success = false;
                responseModel.Message = "Ekstra hizmet seçilmedi.";
            }

            // Response modeldeki mesajı TempData ile aktararak kullanıcıya bildiriyoruz.
            TempData["SuccessMessage"] = responseModel.Message;
            return RedirectToAction("Checkout", "Payment", new { reservationId = model.ReservationId });
        }

        #endregion

        #region MyReservations

        /// <summary>
        /// Kullanıcının kendi rezervasyonlarını getirir ve görüntüler.
        /// Kullanıcının ID'si, ClaimTypes.NameIdentifier üzerinden elde edilir ve buna göre rezervasyonlar sorgulanır.
        /// Rezervasyon verileri, ReservationListResponseModel içine aktarılır ve ilgili view'e gönderilir.
        /// </summary>
        public async Task<IActionResult> MyReservations()
        {
            // Kullanıcının ID'sini ClaimTypes.NameIdentifier üzerinden alır ve Convert.ToInt32 ile int'e çevirir.
            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)); // Kullanıcı ID'si alınır.

            // Belirtilen kullanıcıya ait rezervasyonları asenkron olarak getirir.
            var reservations = await _reservationManager.GetReservationsByUserIdAsync(userId); // Rezervasyonlar çekilir.

            // Rezervasyon verilerini içeren ResponseModel oluşturulur.
            var responseModel = new ReservationListResponseModel
            {
                Reservations = reservations // Rezervasyonlar ResponseModel'e atanır.
            };

            // ResponseModel view'e aktarılır ve kullanıcıya sunulur.
            return View(responseModel); // View'e model gönderilir.
        }

        #endregion

        #region CancelReservation

        /// <summary>
        /// İptal işlemi için onay sayfasını gösterir.
        /// Verilen rezervasyon ID'si ile ilgili iptal onay view'ini yükler.
        /// </summary>
        /// <param name="id">İptal edilecek rezervasyonun ID'si</param>
        /// <returns>İptal onay view'i</returns>
        public IActionResult Cancel(int id)
        {
            return View(id); // Rezervasyon ID'si view'e gönderilir.
        }

        /// <summary>
        /// Kullanıcının rezervasyon iptali işlemini gerçekleştirir.
        /// Öncelikle, rezervasyonun geçerli olup olmadığı ve kullanıcının bu rezervasyona ait olup olmadığı kontrol edilir.  
        /// Ardından, ekstra servisler iptal edilir ve rezervasyon manager'ı kullanılarak rezervasyon iptali yapılır.  
        /// Rezervasyon onaylı ise, ödeme iptali işlemi için PaymentController'a yönlendirilir; aksi halde başarı mesajı gösterilir.
        /// </summary>
        /// <param name="id">İptal edilecek rezervasyonun ID'si</param>
        /// <returns>İşlem sonucuna göre uygun yönlendirme</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmCancel(int id)
        {
            // Giriş yapan kullanıcının ID'sini ClaimTypes.NameIdentifier üzerinden alır ve int'e çevirir.
            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)); // Kullanıcı ID'sini alır.

            // Verilen ID ile rezervasyon bilgisi çekilir.
            var reservation = await _reservationManager.GetByIdAsync(id); // Rezervasyon çekilir

            // Rezervasyon bulunamazsa veya rezervasyon giriş yapan kullanıcıya ait değilse hata mesajı verilir.
            if (reservation == null || reservation.AppUserId != userId)
            {
                TempData["ErrorMessage"] = "Yetkisiz işlem. Sadece kendi rezervasyonlarınızı iptal edebilirsiniz."; // Hata mesajı
                return RedirectToAction("MyReservations"); // Kullanıcı rezervasyonlar sayfasına yönlendirilir.
            }

            // Rezervasyon zaten iptal edilmişse hata mesajı verilir.
            if (reservation.ReservationStatus == ReservationStatus.Canceled)
            {
                TempData["ErrorMessage"] = "Bu rezervasyon zaten iptal edilmiş."; // Hata mesajı
                return RedirectToAction("MyReservations"); // Kullanıcı rezervasyonlar sayfasına yönlendirilir.
            }

            // Rezervasyona ait ekstra servisler iptal edilir.
            await CancelReservationExtraServicesAsync(id); // Ekstra servis iptali gerçekleştirilir.

            // Rezervasyon manager'ı kullanılarak rezervasyon iptali yapılır (status'u Deleted, DeletedDate ayarlanır).
            var cancelResult = await _reservationManager.CancelReservationAsync(id); // Rezervasyon iptal edilir.

            // Rezervasyon iptali başarısız olursa hata mesajı verilir.
            if (!cancelResult)
            {
                TempData["ErrorMessage"] = "Bir hata oluştu. Lütfen tekrar deneyin."; // Hata mesajı
                return RedirectToAction("MyReservations"); // Kullanıcı rezervasyonlar sayfasına yönlendirilir.
            }

            // Eğer rezervasyon onaylı ise, ödeme iptali için PaymentController'a yönlendirme yapılır.
            if (reservation.ReservationStatus == ReservationStatus.Confirmed)
            {
                return RedirectToAction("CancelPaymentConfirm", "Payment", new { reservationId = reservation.Id }); // Ödeme iptaline yönlendir.
            }
            else
            {
                // Diğer durumlarda başarı mesajı gösterilir.
                TempData["SuccessMessage"] = "Rezervasyonunuz ve ek hizmetler başarıyla iptal edilmiştir."; // Başarı mesajı
                return RedirectToAction("MyReservations"); // Kullanıcı rezervasyonlar sayfasına yönlendirilir.
            }
        }

        #endregion

        #region EditReservation

        /// <summary>
        /// GET: Rezervasyon güncelleme sayfasını yükler. 
        /// Rezervasyon detaylarını, seçili oda bilgilerini ve ilgili ekstra servisleri (Status'u Deleted olmayan) hazırlar.
        /// </summary>
        /// <param name="id">Rezervasyon ID'si</param>
        /// <returns>Güncelleme view'i</returns>
        public async Task<IActionResult> Edit(int id) // GET: Rezervasyon güncelleme sayfasını yükle
        {
            // Kullanıcının ID'sini, claim üzerinden alıp int'e dönüştürüyoruz.
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            // Rezervasyon verisini getiriyoruz (lazy loading veya Include ile ExtraServices de yüklenecek).
            var reservation = await _reservationManager.GetByIdAsync(id);

            // Ayrı olarak, ilgili rezervasyona ait ekstra servisleri _reservationExtraServiceManager üzerinden çekiyoruz.
            var extraServices = await _reservationExtraServiceManager.GetByReservationIdAsync(id);

            // Rezervasyon yoksa veya rezervasyon, giriş yapan kullanıcıya ait değilse hata mesajı verip yönlendiriyoruz.
            if (reservation == null || reservation.AppUserId != userId)
            {
                TempData["ErrorMessage"] = "Yetkisiz işlem. Sadece kendi rezervasyonlarınızı düzenleyebilirsiniz.";
                return RedirectToAction("MyReservations");
            }

            // Extra servislerin ID'lerini filtreliyoruz; sadece Status değeri Deleted olmayan servislerin ID'lerini alıyoruz.
            var selectedExtraServiceIds = extraServices?
                .Where(es => es.Status != DataStatus.Deleted)
                .Select(es => es.ExtraServiceId)
                .ToList() ?? new List<int>();

            // Rezervasyon verilerini, güncelleme işlemi için kullanılan model'e eşliyoruz.
            var model = new ReservationUpdateRequestModel
            {
                ReservationId = reservation.Id,           // Rezervasyon ID'si
                StartDate = reservation.StartDate,          // Rezervasyonun başlangıç tarihi
                EndDate = reservation.EndDate,              // Rezervasyonun bitiş tarihi
                RoomId = reservation.RoomId,                // Seçili oda numarası
                PackageId = reservation.PackageId,          // Seçili paket ID'si
                TotalPrice = reservation.TotalPrice,        // Rezervasyonun toplam fiyatı
                ExtraServiceIds = selectedExtraServiceIds    // Aktif (Status != Deleted) ekstra servis ID'leri
            };

            // Seçim listelerini, rezervasyon tarih bilgilerine göre hazırlıyoruz (ör. oda ve paket dropdown'ları).
            await LoadSelectListsAsync(model.StartDate, model.EndDate, model.RoomId, model.PackageId, model.ExtraServiceIds);

            return View(model); // Güncelleme view'ine model ile dönüyoruz.
        }

        /// <summary>
        /// POST: Rezervasyon güncelleme işlemini gerçekleştirir. 
        /// Girilen tarih, oda, paket ve ekstra servis bilgilerine göre rezervasyonu günceller.
        /// </summary>
        /// <param name="model">Güncelleme için rezervasyon model verileri</param>
        /// <returns>Başarılı ise rezervasyonlar sayfasına, aksi halde güncelleme view'ine yönlendirir</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ReservationUpdateRequestModel model) // POST: Rezervasyon güncelleme işlemi
        {
            // Model doğrulaması başarısızsa, seçim listelerini yeniden yükleyip view'e geri dönüyoruz.
            if (!ModelState.IsValid)
            {
                await LoadSelectListsAsync(model.StartDate, model.EndDate, model.RoomId, model.PackageId, model.ExtraServiceIds);
                return View(model);
            }

            // Mevcut rezervasyonu, ID üzerinden getiriyoruz.
            var existingReservation = await _reservationManager.GetByIdAsync(model.ReservationId);
            if (existingReservation == null)
            {
                TempData["ErrorMessage"] = "Rezervasyon bulunamadı.";
                return RedirectToAction("MyReservations");
            }

            // Yeni oda ve tarih aralıkları için müsaitlik kontrolü yapıyoruz.
            bool isAvailable = _reservationManager.CheckAvailabilityForUpdate(model.ReservationId, model.RoomId, model.StartDate, model.EndDate);
            if (!isAvailable)
            {
                ModelState.AddModelError("", "Seçtiğiniz tarihler arasında oda dolu.");
                await LoadSelectListsAsync(model.StartDate, model.EndDate, model.RoomId, model.PackageId, model.ExtraServiceIds);
                return View(model);
            }

            // Oda ve paket bilgilerine göre temel fiyatı hesaplıyoruz (ekstra servis fiyatı hariç).
            decimal basePrice = _reservationManager.CalculateUpdatedPrice(model.RoomId, model.StartDate, model.EndDate, model.PackageId);

            // Güncelleme için DTO oluşturuyoruz; burada CreatedDate mevcut rezervasyondan alınarak korunuyor.
            var updateDto = new ReservationDto
            {
                Id = model.ReservationId,                       // Rezervasyon ID'si
                StartDate = model.StartDate,                    // Yeni başlangıç tarihi
                EndDate = model.EndDate,                        // Yeni bitiş tarihi
                RoomId = model.RoomId,                          // Yeni oda numarası
                PackageId = model.PackageId,                    // Yeni paket seçimi
                TotalPrice = basePrice,                         // Hesaplanan temel fiyat
                Status = DataStatus.Updated,                    // Rezervasyon durumu güncellendi
                ModifiedDate = DateTime.Now,                    // Güncelleme zamanı
                CreatedDate = existingReservation.CreatedDate   // Mevcut CreatedDate değerini koruyoruz
            };

            // Rezervasyonu güncelliyoruz.
            var updateResult = await _reservationManager.UpdateReservationAsync(updateDto);
            if (updateResult)
            {
                // Rezervasyona ait ekstra servisleri güncellemek için ilgili manager metodunu çağırıyoruz.
                await _reservationExtraServiceManager.UpdateExtraServicesForReservation(model.ReservationId, model.ExtraServiceIds);

                // Ekstra servislerin fiyat etkisini hesaplamak için ilgili metodu çağırıyoruz.
                await _reservationManager.UpdateReservationPriceWithExtraServices(model.ReservationId, model.ExtraServiceIds);

                // Eğer oda numarası değiştiyse, eski ve yeni oda durumlarını güncelliyoruz.
                if (existingReservation.RoomId != model.RoomId)
                {
                    await _roomManager.UpdateRoomStatusOnReservationChangeAsync(existingReservation.RoomId, model.RoomId);
                }

                // Başarı mesajı belirleyip rezervasyonlar sayfasına yönlendiriyoruz.
                TempData["SuccessMessage"] = "Rezervasyon başarıyla güncellendi.";
                return RedirectToAction("MyReservations");
            }

            // Güncelleme işlemi sırasında hata oluştuysa, hata mesajı ekleyip seçim listelerini yeniden yüklüyoruz.
            ModelState.AddModelError("", "Rezervasyon güncellenirken bir hata oluştu.");
            await LoadSelectListsAsync(model.StartDate, model.EndDate, model.RoomId, model.PackageId, model.ExtraServiceIds);
            return View(model);
        }

        #endregion

        #region ControllerPrivateMethods

        // Seçim listelerini yüklemek için yardımcı metot.
        private async Task LoadSelectListsAsync(DateTime? startDate = null, DateTime? endDate = null, int? selectedRoomId = null, int? selectedPackageId = null, List<int> selectedExtraServiceIds = null)
        {
            List<RoomDto> availableRooms = new List<RoomDto>();

            // Eğer geçerli tarihler girildiyse, sadece müsait odaları getir.
            if (startDate.HasValue && endDate.HasValue && startDate < endDate)
            {
                // Belirtilen tarihlerde müsait odaları döndüren metot.
                availableRooms = await _roomManager.GetAvailableRoomsAsync(startDate.Value, endDate.Value);

                // Daha önce seçilmiş oda varsa ve müsait listede yoksa, ekleyelim.
                if (selectedRoomId.HasValue && !availableRooms.Any(r => r.Id == selectedRoomId.Value))
                {
                    var selectedRoom = await _roomManager.GetByIdAsync(selectedRoomId.Value);
                    if (selectedRoom != null)
                    {
                        availableRooms.Add(selectedRoom);
                    }
                }
            }

            // Oda seçimi için SelectListItem listesi oluşturuluyor.
            var roomSelectList = availableRooms.Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = $"Kat {r.Floor} - Oda {r.RoomNumber} - {r.PricePerNight} TL"
            }).ToList();

            if (!availableRooms.Any())
            {
                roomSelectList.Insert(0, new SelectListItem { Value = "", Text = "Önce giriş ve çıkış tarihlerini seçiniz" });
            }

            ViewBag.Rooms = new SelectList(roomSelectList, "Value", "Text", selectedRoomId);

            // Paketleri yükleyelim (tarihlerle ilgisi yok)
            var packages = await _packageManager.GetAllAsync();
            ViewBag.Packages = new SelectList(packages, "Id", "Name", selectedPackageId);

            // Ekstra hizmetleri yükleyelim.
            var extraServices = _extraServiceManager.GetActives();
            ViewBag.ExtraServices = extraServices.Select(es => new SelectListItem
            {
                Value = es.Id.ToString(),
                Text = $"{es.Name} - {es.Price} TL",
                Selected = selectedExtraServiceIds != null && selectedExtraServiceIds.Contains(es.Id)
            }).ToList();
        }


        private async Task LoadPackagesAsync(int? selectedPackageId = null)
        {
            var packages = await _packageManager.GetAllAsync();
            ViewBag.Packages = new SelectList(packages, "Id", "Name", selectedPackageId);
        }

        public async Task<IActionResult> GetAvailableRooms(DateTime startDate, DateTime endDate)
        {
            var availableRooms = await _roomManager.GetAvailableRoomsAsync(startDate, endDate);
            // Partial view veya JSON olarak dönebilirsiniz. Örneğin partial view:
            return PartialView("_AvailableRoomsPartial", availableRooms);
        }

        private async Task CancelReservationExtraServicesAsync(int reservationId)
        {
            var existingServices = await _reservationExtraServiceManager.GetByReservationIdAsync(reservationId);
            foreach (var service in existingServices.Where(x => x.Status != DataStatus.Deleted))
            {
                await _reservationExtraServiceManager.UpdateDeletedAsync(service);
            }
        }

        #endregion
    }
}