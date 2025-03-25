using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Bll.Managers.Concretes;
using Project.Entities.Enums;
using Project.Entities.Models;
using Project.MvcUI.Models.PageVms.Reservations;
using Project.MvcUI.Models.PureVms.Reservations.RequestModels;
using Project.MvcUI.Models.PureVms.Reservations.ResponseModels;
using System.Security.Claims;

namespace Project.MvcUI.Controllers
{
    /// <summary>
    /// ReservationController, Member rolündeki kullanıcıların rezervasyon işlemlerini (oluşturma, düzenleme, iptal ve ekstra hizmet seçimi) yönetir.
    /// Bu controller; rezervasyon oluşturma sayfasını hazırlama, girilen verilerin validasyonunu yapma, 
    /// rezervasyon DTO'larını oluşturma, manager sınıfları aracılığıyla iş mantığını yürütme ve ilgili view'lere verileri aktarma görevlerini üstlenir.
    /// Ayrıca, hata ve başarı mesajlarının merkezi yönlendirilmesi için yardımcı metotlar kullanarak kullanıcı deneyimini iyileştirir.
    /// </summary>
    [Authorize(Roles = "Member")]
    public class ReservationController : Controller
    {
        private readonly IReservationManager _reservationManager;
        private readonly IEmployeeManager _employeeManager;
        private readonly IRoomManager _roomManager;
        private readonly IPackageManager _packageManager;
        private readonly IExtraServiceManager _extraServiceManager;
        private readonly IReservationExtraServiceManager _reservationExtraServiceManager;
        readonly IMapper _mapper;


        public ReservationController(
            IReservationManager reservationManager,
            IEmployeeManager employeeManager,
            IRoomManager roomManager,
            IPackageManager packageManager,
            IExtraServiceManager extraServiceManager,
            IReservationExtraServiceManager reservationExtraServiceManager,
            IMapper mapper)
        {
            _reservationManager = reservationManager;
            _employeeManager = employeeManager;
            _roomManager = roomManager;
            _packageManager = packageManager;
            _extraServiceManager = extraServiceManager;
            _reservationExtraServiceManager = reservationExtraServiceManager;
            _mapper = mapper;
        }

        #region CreateReservation

        /// <summary>
        /// Rezervasyon oluşturma sayfasını hazırlar.
        /// Kat bilgilerini içeren bir dictionary oluşturur ve gerekli seçim listelerini yükleyerek view'e gönderir.
        /// </summary>
        /// <returns>Rezervasyon oluşturma view'i</returns>
        public async Task<IActionResult> Create()
        {
            // Kat bilgilerini içeren bir dictionary oluşturuluyor.
            var floorsInfo = new Dictionary<int, string>
            {
                { 1, "Tek Kişilik ve Üç Kişilik Odalar - Minibar bulunmamaktadır." },
                { 2, "Tek Kişilik ve İki Kişilik Odalar - Klima, TV, Saç Kurutma Makinesi, Kablosuz İnternet mevcut." },
                { 3, "Çift Kişilik (Duble) ve Üç Kişilik Odalar - Balkonlu, Minibar, Tüm olanaklar mevcut." },
                { 4, "Çift Kişilik (Duble), Dört Kişilik ve Kral Dairesi - Balkon, Minibar, Tüm olanaklar mevcut." }
            };

            // Oluşturulan kat bilgileri, view içerisinde kullanılmak üzere ViewBag'e aktarılıyor.
            ViewBag.FloorsInfo = floorsInfo;

            // Oda, paket ve ekstra hizmet seçim listeleri, LoadSelectListsAsync metodu ile yükleniyor.
            await LoadSelectListsAsync();

            // Oluşturulan seçim listeleri ile birlikte view render ediliyor.
            return View();
        }

        /// <summary>
        /// Girdi tarihlerini doğrulayarak, form modelini bir DTO'ya haritalandırır, 
        /// rastgele bir resepsiyonist atar ve ReservationManager aracılığıyla yeni rezervasyonu oluşturur.
        /// Başarılı ise kullanıcı ekstra hizmet seçimi sayfasına yönlendirilir; başarısız ise hata mesajı gösterilir.
        /// </summary>
        /// <param name="model">Kullanıcının girdiği rezervasyon oluşturma bilgilerini içeren form modeli</param>
        /// <returns>Başarılı ise ekstra hizmet seçimi sayfasına, aksi halde formun yeniden render edildiği view'e yönlendirme</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservationCreateRequestModel model)
        {
            // Girilen tarih aralığının doğruluğu kontrol ediliyor.
            string dateValidationError = _reservationManager.ValidateReservationDates(model.StartDate, model.EndDate);
            if (dateValidationError != null)
            {
                // Eğer tarih validasyonu başarısız olursa, hata mesajı ModelState'e eklenir.
                ModelState.AddModelError(string.Empty, dateValidationError);
                // Seçim listeleri, girilen tarih, oda ve paket bilgilerine göre yeniden yüklenir.
                await LoadSelectListsAsync(model.StartDate, model.EndDate, model.RoomId, model.PackageId);
                // Hatalı model ile view yeniden render edilir.
                return View(model);
            }

            // Genel model validasyonu yapılır.
            if (!ModelState.IsValid)
            {
                await LoadSelectListsAsync(model.StartDate, model.EndDate, model.RoomId, model.PackageId);
                return View(model);
            }

            // Giriş yapan kullanıcının ID'si, ClaimTypes üzerinden alınır ve int'e dönüştürülür.
            int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            // AutoMapper kullanılarak form modeli ReservationDto'ya dönüştürülüyor.
            ReservationDto dto = _mapper.Map<ReservationDto>(model);

            // Mapping sonrası ek ayarlamalar yapılıyor.
            dto.AppUserId = userId;
            dto.ReservationStatus = ReservationStatus.PendingPayment;
            dto.Status = DataStatus.Inserted;

            // Resepsiyonist çalışan ID'si, rastgele seçilerek DTO'ya ekleniyor.
            int receptionistId = await _employeeManager.GetRandomReceptionistEmployeeIdAsync();
            dto.EmployeeId = receptionistId;

            // Rezervasyon manager üzerinden rezervasyon oluşturuluyor ve sonuç mesajı alınıyor.
            string resultMessage = await _reservationManager.CreateReservation(dto);

            // Eğer rezervasyon başarıyla oluşturulmuşsa:
            if (resultMessage == "Rezervasyon başarıyla oluşturuldu.")
            {
                // Kullanıcının son oluşturulan rezervasyonu alınıyor.
                ReservationDto createdReservation = await _reservationManager.GetLatestReservationByUserId(userId);
                // Başarı mesajı ile birlikte, ekstra hizmet seçimi sayfasına yönlendirme yapılıyor.
                return RedirectWithMessage("Rezervasyon başarıyla oluşturuldu.", false, "SelectExtras", "Reservation", new RouteValueDictionary(new { reservationId = createdReservation.Id }));
            }
            else
            {
                // Rezervasyon oluşturma başarısız olursa, hata mesajı ModelState'e eklenir.
                ModelState.AddModelError(string.Empty, resultMessage);
                // Seçim listeleri yeniden yüklenir.
                await LoadSelectListsAsync();
                // Hata mesajıyla view yeniden render edilir.
                return View(model);
            }
        }

        #endregion

        #region SelectExtrasReservation

        /// <summary>
        /// Seçilen rezervasyona ait ekstra hizmet seçimi sayfasını hazırlar.
        /// Aktif ekstra hizmetler, SelectListItem listesi olarak ReservationSelectExtrasPageVm içine aktarılır.
        /// Kullanıcıdan ekstra hizmet seçimlerini almak için gerekli form modeli, PageVM içerisinde yer alır.
        /// </summary>
        /// <param name="reservationId">Rezervasyon ID'si</param>
        /// <returns>Ekstra hizmet seçim view'i</returns>
        public async Task<IActionResult> SelectExtras(int reservationId)
        {
            // İlgili rezervasyon bilgisini çekiyoruz.
            var reservation = await _reservationManager.GetByIdAsync(reservationId);
            if (reservation == null)
            {
                // Rezervasyon bulunamazsa, hata mesajı belirlenip rezervasyonlar sayfasına yönlendiriyoruz.
                return RedirectWithMessage("Rezervasyon bulunamadı.", true);
            }

            // Aktif ekstra hizmetleri alıyoruz.
            var extraServices = _extraServiceManager.GetActives();
            // Yardımcı metot kullanılarak, ekstra hizmetlerin SelectListItem listesi oluşturuluyor.
            var extraServiceSelectList = BuildExtraServiceSelectList(extraServices);

            // Yeni PageVM oluşturuluyor: Form modeli (ReservationSelectExtrasRequest) ve ekstra hizmet listesi ekleniyor.
            ReservationSelectExtrasPageVm vm = new()
            {
                ReservationSelectExtrasRequest = new Project.MvcUI.Models.PureVms.Reservations.RequestModels.ReservationSelectExtrasRequestModel
                {
                    ReservationId = reservationId
                },
                ExtraServices = extraServiceSelectList
            };

            // Oluşturulan PageVM, view'e gönderilir.
            return View(vm);
        }

        /// <summary>
        /// Kullanıcının seçtiği ekstra hizmetleri işleyerek, rezervasyonun toplam fiyatını günceller 
        /// ve işlemin sonucunu bildirir.
        /// Eğer ekstra hizmet seçimi yapılmışsa, bu hizmetler eklenir ve rezervasyon fiyatı güncellenir; 
        /// aksi halde, kullanıcıya bilgilendirici mesaj gösterilir.
        /// </summary>
        /// <param name="pageVm">ReservationSelectExtrasPageVm: ekstra hizmet seçimi sayfası için kullanılan PageVM</param>
        /// <returns>Checkout sayfasına yönlendirme sonucu</returns>
        [HttpPost]
        public async Task<IActionResult> SelectExtras(ReservationSelectExtrasPageVm pageVm)
        {
            // PageVM içerisinden form modeli (ReservationSelectExtrasRequestModel) elde ediliyor.
            var model = pageVm.ReservationSelectExtrasRequest;

            // Response modeli oluşturuluyor.
            var responseModel = new ReservationSelectExtrasResponseModel();

            // Kullanıcı ekstra hizmet seçimi yapmışsa:
            if (model.ExtraServiceIds != null && model.ExtraServiceIds.Any())
            {
                // Seçilen ekstra hizmet ID'leriyle yeni ReservationExtraServiceDto nesneleri oluşturuluyor.
                var extraServices = model.ExtraServiceIds.Select(id => new ReservationExtraServiceDto
                {
                    ReservationId = model.ReservationId,
                    ExtraServiceId = id
                }).ToList();

                // Oluşturulan ekstra hizmet kayıtları veritabanına ekleniyor.
                await _reservationExtraServiceManager.CreateRangeAsync(extraServices);
                // Rezervasyonun toplam fiyatı, seçilen ekstra hizmet ücretlerine göre güncelleniyor.
                await _reservationManager.UpdateReservationPriceWithExtraServices(model.ReservationId, model.ExtraServiceIds);

                responseModel.Success = true;
                responseModel.Message = "Ekstra hizmetler başarıyla eklendi.";
            }
            else
            {
                // Ekstra hizmet seçilmediyse, bilgilendirici mesaj hazırlanıyor.
                responseModel.Success = false;
                responseModel.Message = "Ekstra hizmet seçilmedi, rezervasyon fiyatı aynı kalacaktır.";
            }

            // Sonuç mesajı TempData üzerinden aktarılır ve kullanıcı Checkout sayfasına yönlendirilir.
            return RedirectWithMessage(responseModel.Message, false, "Checkout", "Payment",
                new RouteValueDictionary(new { reservationId = model.ReservationId }));
        }

        #endregion

        #region MyReservations

        /// <summary>
        /// Kullanıcının kendi rezervasyonlarını getirir ve görüntüler.
        /// Kullanıcının ID'si, ClaimTypes.NameIdentifier üzerinden elde edilir ve buna göre rezervasyonlar sorgulanır.
        /// Rezervasyon bilgileri, ReservationListPageVm içine aktarılır ve ilgili view'e gönderilir.
        /// Eğer rezervasyon listesi boşsa, kullanıcı bilgilendirilir.
        /// </summary>
        /// <returns>Kullanıcının rezervasyon listesini içeren view veya bilgi mesajı ile yönlendirme</returns>
        public async Task<IActionResult> MyReservations()
        {
            // Giriş yapan kullanıcının ID'si ClaimTypes üzerinden alınır ve int'e dönüştürülür.
            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            // Belirtilen kullanıcıya ait rezervasyonlar asenkron olarak çekilir.
            var reservations = await _reservationManager.GetReservationsByUserIdAsync(userId);

            // Eğer rezervasyon listesi boşsa, kullanıcıya "Henüz rezervasyonunuz bulunmamaktadır." mesajı ile yönlendirme yapılır.
            if (reservations == null || !reservations.Any())
            {
                RedirectWithMessage("Henüz rezervasyonunuz bulunmamaktadır.", true);
            }

            // Rezervasyon bilgileri, ReservationListPageVm modeline aktarılır.
            var vm = new ReservationListPageVm
            {
                Reservations = reservations,
                PageTitle = "Rezervasyonlarım",
                HelpText = "Aşağıda rezervasyon bilgileriniz görüntülenmektedir."
            };

            // Oluşturulan model view'e gönderilir.
            return View(vm);
        }

        #endregion

        #region CancelReservation

        /// <summary>
        /// İptal işlemi için onay sayfasını hazırlar.
        /// Belirtilen rezervasyon ID'sine göre ilgili rezervasyon bilgileri çekilir ve ReservationCancelPageVm içerisine aktarılır.
        /// Böylece kullanıcıya rezervasyon iptali onay sayfası, ilgili oda numarası ve yardımcı metin ile sunulur.
        /// </summary>
        /// <param name="id">İptal edilecek rezervasyonun ID'si</param>
        /// <returns>Rezervasyon iptali onay view'i, ReservationCancelPageVm modeline göre</returns>
        public async Task<IActionResult> Cancel(int id)
        {
            // Rezervasyon bilgisi çekiliyor.
            var reservation = await _reservationManager.GetByIdAsync(id);

            if (reservation == null)
            {
                // Rezervasyon bulunamazsa hata mesajı ile yönlendirme yapılır.
                return RedirectWithMessage("Rezervasyon bulunamadı.", true);
            }

            var room = await _roomManager.GetByIdAsync(reservation.RoomId);
            reservation.RoomNumber = room.RoomNumber;

            // ReservationCancelPageVm oluşturuluyor ve ilgili bilgiler atanıyor.
            ReservationCancelPageVm vm = new()
            {
                ReservationId = reservation.Id,
                RoomNumber = reservation.RoomNumber, // Rezervasyon DTO'sunda RoomNumber mevcutsa kullanılır.
                PageTitle = "Rezervasyon İptal Onayı",
                HelpText = "Lütfen rezervasyonu iptal etmek istediğinize emin olun."
            };

            // Oluşturulan page model view'e gönderilir.
            return View(vm);
        }

        /// <summary>
        /// Kullanıcının rezervasyon iptali işlemini gerçekleştirir.
        /// Form üzerinden gönderilen ReservationCancelPageVm modelindeki ReservationId değeri kullanılarak iptal işlemi yapılır.
        /// Öncelikle, rezervasyonun geçerli olup olmadığı ve kullanıcının bu rezervasyona ait olup olmadığı kontrol edilir.
        /// Ardından, ekstra servisler iptal edilir ve rezervasyon manager'ı kullanılarak rezervasyon iptali gerçekleştirilir.
        /// Rezervasyon onaylı ise, ödeme iptali için PaymentController'ın CancelPaymentConfirm action'ına yönlendirme yapılır;
        /// aksi halde, kullanıcıya detaylı başarı mesajı gösterilir.
        /// </summary>
        /// <param name="model">ReservationCancelPageVm: Rezervasyon iptali onay sayfası için gönderilen page model</param>
        /// <returns>İşlem sonucuna göre uygun yönlendirme</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmCancel(ReservationCancelPageVm model)
        {
            // Formdan gönderilen modelden rezervasyon ID'si elde ediliyor.
            int reservationId = model.ReservationId;

            // Giriş yapan kullanıcının ID'si, ClaimTypes üzerinden alınır ve int'e dönüştürülür.
            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            // Belirtilen rezervasyon bilgisi çekiliyor.
            var reservation = await _reservationManager.GetByIdAsync(reservationId);
            if (reservation == null || reservation.AppUserId != userId)
            {
                // Rezervasyon bulunamazsa veya kullanıcının kendi rezervasyonu değilse hata mesajı ile yönlendirme yapılır.
                return RedirectWithMessage("Yetkisiz işlem. Sadece kendi rezervasyonlarınızı iptal edebilirsiniz.", true);
            }

            // Rezervasyon zaten iptal edilmişse hata mesajı ile yönlendirme yapılır.
            if (reservation.ReservationStatus == ReservationStatus.Canceled)
            {
                return RedirectWithMessage("Bu rezervasyon zaten iptal edilmiş.", true);
            }

            // Rezervasyona ait ekstra servisler, iptal için güncellenir.
            await CancelReservationExtraServicesAsync(reservationId);

            // Rezervasyon manager'ı kullanılarak rezervasyon iptali gerçekleştirilir (status Deleted, DeletedDate ayarlanır).
            var cancelResult = await _reservationManager.CancelReservationAsync(reservationId);
            if (!cancelResult)
            {
                return RedirectWithMessage("Bir hata oluştu. Lütfen tekrar deneyin.", true);
            }

            // Eğer rezervasyon onaylı ise, ödeme iptali için PaymentController'ın CancelPaymentConfirm action'ına yönlendirme yapılır.
            if (reservation.ReservationStatus == ReservationStatus.Confirmed)
            {
                return RedirectWithMessage("Ödeme iptali onay sayfasına yönlendiriliyorsunuz.", false, "CancelPaymentConfirm", "Payment",
                    new RouteValueDictionary(new { reservationId = reservation.Id }));
            }
            else
            {
                // Diğer durumlarda, kullanıcıya başarı mesajı ile yönlendirme yapılır.
                return RedirectWithMessage("Rezervasyonunuz ve ek hizmetler başarıyla iptal edilmiştir.", false);
            }
        }

        #endregion

        #region EditReservation

        /// <summary>
        /// GET: Rezervasyon güncelleme sayfasını yükler.
        /// Belirtilen rezervasyon ID'sine göre rezervasyon detayları, seçili oda bilgileri ve ilgili ekstra hizmetler (Status'u Deleted olmayan) çekilir.
        /// Daha sonra ReservationUpdateRequestModel oluşturulur, inline olarak select listeler hazırlanır ve bu bilgiler ReservationUpdatePageVm modeline eklenerek view'e gönderilir.
        /// </summary>
        /// <param name="id">Güncellenecek rezervasyonun ID'si</param>
        /// <returns>ReservationUpdatePageVm modeline sahip güncelleme view'i</returns>
        public async Task<IActionResult> Edit(int id)
        {
            // Giriş yapan kullanıcının ID'si alınır.
            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            // Rezervasyon bilgisi çekilir (ekstra servisler de lazy ya da Include ile yüklenecek).
            var reservation = await _reservationManager.GetByIdAsync(id);

            // İlgili rezervasyona ait ekstra servis kayıtları çekilir.
            var extraServices = await _reservationExtraServiceManager.GetByReservationIdAsync(id);

            // Rezervasyon yoksa veya rezervasyon, giriş yapan kullanıcıya ait değilse yönlendirme yapılır.
            if (reservation == null || reservation.AppUserId != userId)
            {
                return RedirectWithMessage("Yetkisiz işlem. Sadece kendi rezervasyonlarınızı düzenleyebilirsiniz.", true);
            }

            // Ekstra servislerden, sadece Status'u Deleted olmayanların ID'leri filtrelenir.
            var selectedExtraServiceIds = extraServices?
                .Where(es => es.Status != DataStatus.Deleted)
                .Select(es => es.ExtraServiceId)
                .ToList() ?? new List<int>();

            // Form modeli (ReservationUpdateRequestModel) oluşturulur ve mevcut rezervasyon verileri atanır.
            var formModel = new ReservationUpdateRequestModel
            {
                ReservationId = reservation.Id,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate,
                RoomId = reservation.RoomId,
                PackageId = reservation.PackageId,
                TotalPrice = reservation.TotalPrice,
                ExtraServiceIds = selectedExtraServiceIds
            };

            // Mevcut tarih aralığında müsait odalar çekilir.
            var rooms = await _roomManager.GetAvailableRoomsAsync(formModel.StartDate, formModel.EndDate);

            // Eğer rezervasyonda seçili oda, müsait odalar listesinde yoksa, o oda bilgisi eklenir.
            if (!rooms.Any(r => r.Id == formModel.RoomId))
            {
                var currentRoom = await _roomManager.GetByIdAsync(formModel.RoomId);
                if (currentRoom != null)
                {
                    rooms.Add(currentRoom);
                }
            }

            // Oda seçim listesi oluşturulur.
            var roomSelectList = rooms.Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = $"Kat {r.Floor} - Oda {r.RoomNumber} - {r.PricePerNight} TL",
                Selected = r.Id == formModel.RoomId
            }).ToList();

            // Eğer müsait oda listesi boşsa, kullanıcıya tarih seçmesi gerektiği mesajı eklenir.
            if (!rooms.Any())
            {
                roomSelectList.Insert(0, new SelectListItem { Value = "", Text = "Önce giriş ve çıkış tarihlerini seçiniz" });
            }

            // Paket seçim listesi oluşturulur.
            var packages = await _packageManager.GetAllAsync();
            var packageSelectList = packages.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name,
                Selected = formModel.PackageId.HasValue && p.Id == formModel.PackageId.Value
            }).ToList();

            // Ekstra hizmet seçim listesi oluşturulur.
            var extraServiceSelectList = _extraServiceManager.GetActives()
                .Select(es => new SelectListItem
                {
                    Value = es.Id.ToString(),
                    Text = $"{es.Name} - {es.Price} TL",
                    Selected = selectedExtraServiceIds.Contains(es.Id)
                }).ToList();

            // ReservationUpdatePageVm oluşturulur; form modeli ve hazırlanmış select listeler eklenir.
            var pageVm = new ReservationUpdatePageVm
            {
                ReservationUpdateRequest = formModel,
                Rooms = roomSelectList,
                Packages = packageSelectList,
                ExtraServices = extraServiceSelectList,
                PageTitle = "Rezervasyon Güncelleme",
                HelpText = "Rezervasyon bilgilerinizi güncellemek için aşağıdaki alanları düzenleyin."
            };

            // Oluşturulan page model view'e gönderilir.
            return View(pageVm);
        }

        /// <summary>
        /// POST: Rezervasyon güncelleme işlemini gerçekleştirir.
        /// Girilen tarih, oda, paket ve ekstra hizmet bilgilerine göre mevcut rezervasyon güncellenir.
        /// Eğer güncelleme başarılı olursa, ekstra hizmet güncelleme, fiyat güncelleme ve oda durumları da güncellenir.
        /// Hata durumunda, uygun hata mesajı eklenip kullanıcı yönlendirilir.
        /// </summary>
        /// <param name="pageVm">ReservationUpdatePageVm: Güncelleme için gerekli tüm bilgileri içeren page modeli</param>
        /// <returns>Başarılı ise MyReservations sayfasına, aksi halde güncelleme view'ine yönlendirme</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ReservationUpdatePageVm pageVm)
        {
            // Form modeli, page VM içerisinden elde edilir.
            var model = pageVm.ReservationUpdateRequest;

            // Model doğrulaması yapılır; geçersizse, seçim listeleri yeniden yüklenir ve page VM ile view render edilir.
            if (!ModelState.IsValid)
            {
                await LoadSelectListsAsync(model.StartDate, model.EndDate, model.RoomId, model.PackageId, model.ExtraServiceIds);
                return View(pageVm);
            }

            // Mevcut rezervasyon bilgisi, ID üzerinden çekilir.
            var existingReservation = await _reservationManager.GetByIdAsync(model.ReservationId);
            if (existingReservation == null)
            {
                return RedirectWithMessage("Rezervasyon bulunamadı.", true);
            }

            // Girilen yeni oda ve tarih aralıklarının müsaitliği kontrol edilir.
            bool isAvailable = _reservationManager.CheckAvailabilityForUpdate(model.ReservationId, model.RoomId, model.StartDate, model.EndDate);
            if (!isAvailable)
            {
                ModelState.AddModelError("", "Seçtiğiniz tarihler arasında oda dolu.");
                await LoadSelectListsAsync(model.StartDate, model.EndDate, model.RoomId, model.PackageId, model.ExtraServiceIds);
                return View(pageVm);
            }

            // Oda ve paket bilgilerine göre temel fiyat hesaplanır (ekstra hizmet ücreti hariç).
            decimal basePrice = _reservationManager.CalculateUpdatedPrice(model.RoomId, model.StartDate, model.EndDate, model.PackageId);

            // Güncelleme için yeni ReservationDto oluşturulur; mevcut CreatedDate değeri korunur.
            var updateDto = new ReservationDto
            {
                Id = model.ReservationId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                RoomId = model.RoomId,
                PackageId = model.PackageId,
                TotalPrice = basePrice,
                Status = DataStatus.Updated,
                ModifiedDate = DateTime.Now,
                CreatedDate = existingReservation.CreatedDate
            };

            // Rezervasyon güncelleme işlemi gerçekleştirilir.
            var updateResult = await _reservationManager.UpdateReservationAsync(updateDto);
            if (updateResult)
            {
                // Rezervasyona ait ekstra hizmet güncellemesi yapılır.
                await _reservationExtraServiceManager.UpdateExtraServicesForReservation(model.ReservationId, model.ExtraServiceIds);
                // Ekstra hizmetlerin fiyat etkisi hesaplanarak rezervasyonun toplam fiyatı güncellenir.
                await _reservationManager.UpdateReservationPriceWithExtraServices(model.ReservationId, model.ExtraServiceIds ?? new List<int>());
                // Eğer oda numarası değiştiyse, eski ve yeni oda durumları güncellenir.
                if (existingReservation.RoomId != model.RoomId)
                {
                    await _roomManager.UpdateRoomStatusOnReservationChangeAsync(existingReservation.RoomId, model.RoomId);
                }
                // Başarı mesajı belirlenip MyReservations sayfasına yönlendirme yapılır.
                return RedirectWithMessage("Rezervasyon başarıyla güncellendi.", false);
            }

            // Güncelleme işlemi sırasında hata oluşursa, hata mesajı eklenir, seçim listeleri yeniden yüklenir ve view render edilir.
            ModelState.AddModelError("", "Rezervasyon güncellenirken bir hata oluştu.");
            await LoadSelectListsAsync(model.StartDate, model.EndDate, model.RoomId, model.PackageId, model.ExtraServiceIds);
            return View(pageVm);
        }

        #endregion

        #region ControllerPrivateMethods

        /// <summary>
        /// Seçim listelerini yükler. 
        /// Verilen tarih aralığı, seçili oda, paket ve ekstra hizmet ID'lerine göre odalar, paketler ve ekstra hizmetler listelerini ViewBag'e aktarır.
        /// </summary>
        /// <param name="startDate">Giriş tarihi (opsiyonel)</param>
        /// <param name="endDate">Çıkış tarihi (opsiyonel)</param>
        /// <param name="selectedRoomId">Önceden seçilmiş oda ID'si (opsiyonel)</param>
        /// <param name="selectedPackageId">Önceden seçilmiş paket ID'si (opsiyonel)</param>
        /// <param name="selectedExtraServiceIds">Önceden seçilmiş ekstra hizmet ID'leri (opsiyonel)</param>
        /// <returns>Asenkron işlem sonucu</returns>
        private async Task LoadSelectListsAsync(DateTime? startDate = null, DateTime? endDate = null, int? selectedRoomId = null, int? selectedPackageId = null, List<int> selectedExtraServiceIds = null)
        {
            // Müsait odaları tutmak için boş liste oluşturuluyor.
            List<RoomDto> availableRooms = new List<RoomDto>();

            // Eğer geçerli tarihler girilmişse, yalnızca o tarihlerde müsait odalar çekiliyor.
            if (startDate.HasValue && endDate.HasValue && startDate < endDate)
            {
                // Belirtilen tarih aralığında müsait odaları getiriyoruz.
                availableRooms = await _roomManager.GetAvailableRoomsAsync(startDate.Value, endDate.Value);

                // Eğer önceden seçilmiş bir oda varsa ancak müsait odalar listesinde yer almıyorsa, bu oda listeye ekleniyor.
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

            // Eğer müsait oda listesi boşsa, kullanıcıya önce tarihleri seçmesi gerektiğini belirten bir seçenek ekleniyor.
            if (!availableRooms.Any())
            {
                roomSelectList.Insert(0, new SelectListItem { Value = "", Text = "Önce giriş ve çıkış tarihlerini seçiniz" });
            }

            // Oda listesini ViewBag'e aktarıyoruz.
            ViewBag.Rooms = new SelectList(roomSelectList, "Value", "Text", selectedRoomId);

            // Paketleri çekip SelectList'e dönüştürüyoruz (tarih aralığına bağlı değil).
            var packages = await _packageManager.GetAllAsync();
            ViewBag.Packages = new SelectList(packages, "Id", "Name", selectedPackageId);

            // Aktif ekstra hizmetleri çekip, SelectListItem listesine dönüştürüyoruz.
            var extraServices = _extraServiceManager.GetActives();
            ViewBag.ExtraServices = extraServices.Select(es => new SelectListItem
            {
                Value = es.Id.ToString(),
                Text = $"{es.Name} - {es.Price} TL",
                Selected = selectedExtraServiceIds != null && selectedExtraServiceIds.Contains(es.Id)
            }).ToList();
        }

        /// <summary>
        /// Paket listesini yükler ve ViewBag'e aktarır.
        /// </summary>
        /// <param name="selectedPackageId">Önceden seçilmiş paket ID'si (opsiyonel)</param>
        /// <returns>Asenkron işlem sonucu</returns>
        private async Task LoadPackagesAsync(int? selectedPackageId = null)
        {
            // Tüm paketleri çekiyoruz.
            var packages = await _packageManager.GetAllAsync();
            // Paket listesini SelectList formatına çevirip ViewBag'e atıyoruz.
            ViewBag.Packages = new SelectList(packages, "Id", "Name", selectedPackageId);
        }

        /// <summary>
        /// Belirtilen tarih aralığında müsait odaları getirir ve PartialView olarak döndürür.
        /// </summary>
        /// <param name="startDate">Giriş tarihi</param>
        /// <param name="endDate">Çıkış tarihi</param>
        /// <returns>Müsait odaların listesi içeren PartialView</returns>
        public async Task<IActionResult> GetAvailableRooms(DateTime startDate, DateTime endDate)
        {
            // Belirtilen tarih aralığında müsait odaları çekiyoruz.
            var availableRooms = await _roomManager.GetAvailableRoomsAsync(startDate, endDate);
            // Partial view veya JSON olarak dönebilirsiniz. Bu örnekte partial view kullanılmıştır.
            return PartialView("_AvailableRoomsPartial", availableRooms);
        }

        /// <summary>
        /// Belirtilen rezervasyona ait ekstra servislerin iptalini gerçekleştirir.
        /// Her aktif (Status != Deleted) ekstra hizmet kaydı için, ilgili manager metodu ile güncelleme yapılır.
        /// </summary>
        /// <param name="reservationId">Rezervasyon ID'si</param>
        /// <returns>Asenkron işlem sonucu</returns>
        private async Task CancelReservationExtraServicesAsync(int reservationId)
        {
            // İlgili rezervasyona ait tüm ekstra servis kayıtlarını çekiyoruz.
            var existingServices = await _reservationExtraServiceManager.GetByReservationIdAsync(reservationId);
            // Her bir ekstra servis kaydı için, Status değeri Deleted olmayanları iptal ediyoruz.
            foreach (var service in existingServices.Where(x => x.Status != DataStatus.Deleted))
            {
                await _reservationExtraServiceManager.UpdateDeletedAsync(service);
            }
        }

        /// <summary>
        /// Yardımcı metot: Aktif ekstra hizmetler listesini, SelectListItem listesine dönüştürür.
        /// </summary>
        /// <param name="extraServices">Ekstra hizmetler koleksiyonu</param>
        /// <param name="selectedExtraServiceIds">Seçili ekstra hizmet ID'leri (opsiyonel)</param>
        /// <returns>Oluşturulmuş SelectListItem listesi</returns>
        private List<SelectListItem> BuildExtraServiceSelectList(IEnumerable<ExtraServiceDto> extraServices, List<int> selectedExtraServiceIds = null)
        {
            // Her ekstra hizmet için, SelectListItem oluşturuyoruz.
            return extraServices.Select(es => new SelectListItem
            {
                Value = es.Id.ToString(),
                Text = $"{es.Name} - {es.Price} TL",
                Selected = selectedExtraServiceIds != null && selectedExtraServiceIds.Contains(es.Id)
            }).ToList();
        }

        /// <summary>
        /// Yardımcı metot: Belirtilen mesajı (hata veya başarı) TempData'ya atar ve belirtilen action/controller'a yönlendirir.
        /// Böylece, hata veya başarı durumlarında merkezi bir yönlendirme işlemi gerçekleştirilir.
        /// </summary>
        /// <param name="message">Gönderilecek mesaj</param>
        /// <param name="isError">Mesaj hata mı (true) yoksa başarı mı (false)?</param>
        /// <param name="action">Yönlendirilecek action; varsayılan "MyReservations"</param>
        /// <param name="controller">Yönlendirilecek controller; varsayılan "Reservation"</param>
        /// <param name="routeValues">Ek yönlendirme parametreleri (opsiyonel)</param>
        /// <returns>Belirtilen action ve controller'a yönlendirme sonucu bir IActionResult</returns>
        private IActionResult RedirectWithMessage(string message, bool isError, string action = "MyReservations", string controller = "Reservation", RouteValueDictionary routeValues = null)
        {
            // Mesaj türüne göre TempData'ya atama yapıyoruz.
            if (isError)
            {
                TempData["ErrorMessage"] = message;
            }
            else
            {
                TempData["SuccessMessage"] = message;
            }
            // Belirtilen action, controller ve route değerleriyle yönlendirme yapıyoruz.
            return RedirectToAction(action, controller, routeValues);
        }

        #endregion
    }
}