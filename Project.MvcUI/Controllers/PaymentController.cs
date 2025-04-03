using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Bll.Managers.Concretes;
using Project.Common.Tools;
using Project.Entities.Enums;
using Project.Entities.Models;
using Project.MvcUI.Helpers;
using Project.MvcUI.Models.PageVms.Payments;
using Project.MvcUI.Models.PureVms.Payments.RequestModels;
using Project.MvcUI.Models.PureVms.Payments.ResponseModels;
using System.Net.Http;
using System.Security.Claims;
using System.Text;

namespace Project.MvcUI.Controllers
{
    // Bu controller, yalnızca Admin ve Member rollerindeki kullanıcılar tarafından erişilebilir.
    [Authorize(Roles = "Admin,Member")]
    public class PaymentController : Controller
    {
        // Controller'ın ihtiyaç duyduğu manager ve servis bağımlılıkları tanımlanıyor.
        private readonly IReservationManager _reservationManager;
        private readonly IAppUserManager _appUserManager;
        private readonly IAppUserProfileManager _appUserProfileManager;
        private readonly IRoomManager _roomManager;
        private readonly IPaymentManager _paymentManager;
        private readonly IReservationExtraServiceManager _reservationExtraServiceManager;
        private readonly IExtraServiceManager _extraServiceManager;
        private readonly IHttpClientFactory _httpClientFactory;

        // Constructor enjeksiyonu ile tüm bağımlılıklar sağlanıyor.
        public PaymentController(IReservationManager reservationManager, IAppUserManager appUserManager, IAppUserProfileManager appUserProfileManager, IRoomManager roomManager, IPaymentManager paymentManager, IReservationExtraServiceManager reservationExtraServiceManager, IHttpClientFactory httpClientFactory, IExtraServiceManager extraServiceManager)
        {
            _reservationManager = reservationManager;
            _appUserManager = appUserManager;
            _appUserProfileManager = appUserProfileManager;
            _roomManager = roomManager;
            _paymentManager = paymentManager;
            _reservationExtraServiceManager = reservationExtraServiceManager;
            _httpClientFactory = httpClientFactory;
            _extraServiceManager = extraServiceManager;
        }

        #region Index

        // Index action'ı, PaymentController için varsayılan view'i döndürür.
        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region Checkout

        /// <summary>
        /// Ödeme sayfasını açar. İlgili rezervasyon ve kullanıcı profil bilgilerini çekip, ödeme işlemi için gerekli PageVM'i oluşturur.
        /// </summary>
        /// <param name="reservationId">İlgili rezervasyonun ID'si</param>
        /// <returns>Ödeme işlemi için hazırlanmış view</returns>
        public async Task<IActionResult> Checkout(int reservationId)
        {
            // Belirtilen ID ile rezervasyon bilgisini asenkron olarak çekiyoruz.
            ReservationDto reservation = await _reservationManager.GetByIdAsync(reservationId); // Rezervasyon verisi alınıyor

            // Rezervasyon bulunamazsa, hata mesajı belirleyip yönlendirme yapıyoruz.
            if (reservation == null)
                return RedirectWithError("Rezervasyon bulunamadı.");

            // Rezervasyonun ödeme için uygun olup olmadığını kontrol ediyoruz.
            // Eğer rezervasyon onaylanmış veya iptal edilmişse, ödeme işlemi başlatılamaz.
            if (!await _reservationManager.IsReservationPayableAsync(reservationId))
                return RedirectWithError("Bu rezervasyon için ödeme işlemi başlatılamaz. Rezervasyon zaten onaylanmış veya iptal edilmiş.");

            // Rezervasyonun ilişkilendirildiği kullanıcı bilgisinin mevcut olup olmadığını kontrol ediyoruz.
            if (reservation.AppUserId == null)
                return RedirectWithError("Rezervasyonla ilişkilendirilmiş kullanıcı bulunamadı.");

            // Rezervasyona ait kullanıcı profil bilgilerini çekiyoruz.
            AppUserProfileDto userProfile = await _appUserProfileManager.GetByAppUserIdAsync(reservation.AppUserId.Value); // Kullanıcı profili alınıyor

            // Kullanıcı profili bulunamazsa, hata mesajı ile yönlendiriyoruz.
            if (userProfile == null)
                return RedirectWithError("Kullanıcı bilgisi bulunamadı.");

            // Ödeme işlemi için kullanılacak olan request modelini oluşturuyoruz.
            PaymentProcessRequestModel processRequest = new PaymentProcessRequestModel
            {
                ReservationId = reservation.Id,          // Rezervasyon ID'si modelde atanıyor
                CardUserName = "",                       // Kart sahibi bilgisi; kullanıcı tarafından girilecek
                CardNumber = "",                         // Kart numarası; kullanıcı tarafından girilecek
                CVV = "",                                // CVV; kullanıcı tarafından girilecek
                ExpiryMonth = DateTime.Now.Month,        // Geçerli ay atanıyor (varsayılan değer)
                ExpiryYear = DateTime.Now.Year,          // Geçerli yıl atanıyor (varsayılan değer)
                ShoppingPrice = reservation.TotalPrice   // Rezervasyondan alınan toplam fiyat ödeme tutarı olarak belirleniyor
            };

            // UI'ya özgü ek bilgileri barındıran PaymentProcessPageVm oluşturuluyor.
            PaymentProcessPageVm pageVm = new PaymentProcessPageVm
            {
                PaymentProcessRequest = processRequest,  // Ödeme işlemi için oluşturulan request model PageVM'e ekleniyor
                PageTitle = "💳 Ödeme Yap"               // View için sayfa başlığı belirleniyor
            };

            // Oluşturulan PaymentProcessPageVm modelini view'e gönderiyoruz.
            return View(pageVm);
        }

        #endregion

        #region ProcessPayment

        /// <summary>
        /// Ödeme işlemini gerçekleştirir. 
        /// PaymentProcessPageVm içindeki PaymentProcessRequest verilerini kullanarak ödeme API'sine çağrı yapar.
        /// API çağrısı başarılı olursa, rezervasyon onaylanır ve ödeme kaydı oluşturulur.
        /// Hata durumunda ilgili hata mesajı ayarlanıp Checkout sayfasına yönlendirme yapılır.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProcessPayment(PaymentProcessPageVm pageVm)
        {
            // Formdan gönderilen ödeme bilgilerini içeren modeli, PageVM içerisinden alıyoruz.
            PaymentProcessRequestModel model = pageVm.PaymentProcessRequest;

            // Model doğrulamasını kontrol ediyoruz.
            // Eğer model geçerli değilse, hata mesajı ayarlanır ve kullanıcı Checkout sayfasına yönlendirilir.
            if (!ModelState.IsValid)
                return RedirectWithError("Lütfen tüm alanları eksiksiz doldurun.", "Checkout", "Payment", new RouteValueDictionary(new { reservationId = model.ReservationId }));

            // Ödeme yapan kişinin ismi ile kullanıcının profil ismi eşleşmeli:
            AppUserProfileDto userProfile = await _appUserProfileManager.GetByAppUserIdAsync(Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));

            if (userProfile == null)
            {
                return RedirectWithError("Kullanıcı profil bilgisi bulunamadı.", "Checkout", "Payment",
                    new RouteValueDictionary(new { reservationId = model.ReservationId }));
            }

            // Kart sahibi ismi ile kullanıcı profilindeki isim uyuşuyor mu kontrol edilir.
            string userFullName = $"{userProfile.FirstName} {userProfile.LastName}".Trim();
            if (!string.Equals(userFullName, model.CardUserName.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                return RedirectWithError("Ödeme yalnızca rezervasyon sahibi adına kayıtlı bir kart ile yapılabilir.", "Checkout", "Payment",
                    new RouteValueDictionary(new { reservationId = model.ReservationId }));
            }

            // HTTP client örneği oluşturuluyor.
            HttpClient client = _httpClientFactory.CreateClient();

            // Ödeme API'sinin URL'si belirleniyor.
            string apiUrl = "http://localhost:5190/api/Transaction/StartTransaction";

            // API'ye gönderilecek JSON içeriği oluşturuluyor.
            // Bu içerik, ödeme işlemi için gerekli kart bilgileri ve tutar bilgisini içerir.
            string jsonContent = JsonConvert.SerializeObject(new
            {
                model.CardUserName,
                model.CardNumber,
                model.CVV,
                model.ExpiryMonth,
                model.ExpiryYear,
                model.ShoppingPrice
            });

            // JSON içeriği, HTTP POST isteği için uygun formatta hazırlanıyor.
            StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Ödeme API'sine POST isteği gönderiliyor.
            HttpResponseMessage response = await client.PostAsync(apiUrl, content);

            // API çağrısı başarılı ise:
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    // Rezervasyon onaylama işlemi yapılıyor.
                    // İlgili manager metodu çağrılarak, rezervasyon "Confirmed" duruma getiriliyor.
                    await _reservationManager.ConfirmReservationAsync(model.ReservationId);
                }
                catch (Exception ex)
                {
                    // Rezervasyon onaylama sırasında hata oluşursa, hata mesajı ayarlanıp Checkout sayfasına yönlendiriliyor.
                    return RedirectWithError("Rezervasyon güncellenirken bir hata oluştu: " + ex.Message, "Checkout", "Payment",
                        new RouteValueDictionary(new { reservationId = model.ReservationId }));
                }

                try
                {
                    // Ödeme kaydı oluşturma işlemi gerçekleştiriliyor.
                    // Eğer ödeme kaydı oluşturulamazsa, exception fırlatılır.
                    await _paymentManager.RecordPaymentAsync(model.ReservationId, model.ShoppingPrice);
                }
                catch (Exception ex)
                {
                    // Ödeme kaydı oluşturma sırasında hata oluşursa, hata mesajı ayarlanıp Checkout sayfasına yönlendirme yapılıyor.
                    return RedirectWithError("Ödeme kaydı oluşturulurken bir hata oluştu: " + ex.Message, "Checkout", "Payment",
                        new RouteValueDictionary(new { reservationId = model.ReservationId }));
                }

                // İşlem başarılı ise, başarı mesajı ayarlanıp kullanıcı ödeme geçmişi (History) sayfasına yönlendirilir.
                return RedirectWithError("Ödeme başarıyla tamamlandı!", "History", "Payment");
            }
            else
            {
                // API çağrısı başarısız ise, hata mesajı ayarlanır ve kullanıcı Checkout sayfasına yönlendirilir.
                return RedirectWithError("Ödeme başarısız.", "Checkout", "Payment",
                    new RouteValueDictionary(new { reservationId = model.ReservationId }));
            }
        }

        #endregion

        #region History

        /// <summary>
        /// Kullanıcının ödeme geçmişini getirir ve görüntüler.
        /// Bu metod, oturum açmış kullanıcının bilgilerini, profilini, ödeme geçmişi API çağrısı ile alınan verileri 
        /// ve onaylanmış rezervasyon bilgilerini birleştirerek PaymentHistoryPageVm oluşturur.
        /// Herhangi bir adımda hata oluşursa, kullanıcı uygun şekilde yönlendirilir.
        /// </summary>
        public async Task<IActionResult> History()
        {
            // Kullanıcının oturum açtığından emin oluyoruz; aksi halde ana sayfaya yönlendiriyoruz.
            if (User.Identity == null || !User.Identity.IsAuthenticated)
                return RedirectWithError("Ödeme geçmişini görmek için giriş yapmalısınız.", "Index", "Home");

            // Tüm kullanıcı bilgilerini alıp, aktif oturum açan kullanıcının bilgilerini User.Identity.Name üzerinden buluyoruz.
            List<AppUserDto> allUsers = await _appUserManager.GetAllAsync();
            AppUserDto? user = allUsers.FirstOrDefault(u => u.UserName == User.Identity.Name);

            // Eğer kullanıcı bulunamazsa hata mesajı ile yönlendiriyoruz.
            if (user == null)
                return RedirectWithError("Kullanıcı bulunamadı.", "Index", "Payment");

            // Kullanıcının profil bilgilerini getiriyoruz.
            AppUserProfileDto userProfile = await _appUserProfileManager.GetByAppUserIdAsync(user.Id);
            if (userProfile == null)
                return RedirectWithError("Kullanıcı profili bulunamadı.", "Index", "Payment");

            // Kullanıcının tam adını oluşturuyoruz.
            string userFullName = $"{userProfile.FirstName} {userProfile.LastName}";

            // Ödeme geçmişi API'sine çağrı yaparak, kullanıcının kart bilgilerini içeren verileri elde ediyoruz.
            HttpClient client = _httpClientFactory.CreateClient();
            string apiUrl = $"http://localhost:5190/api/Transaction/PaymentHistoryByUser/{userFullName}";
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (!response.IsSuccessStatusCode)
                return RedirectWithError("Ödeme geçmişi alınamadı.", "Index", "Payment");

            // API'den gelen JSON yanıtını okuyup, PaymentHistoryResponseModel listesine deserialize ediyoruz.
            string jsonResponse = await response.Content.ReadAsStringAsync();
            List<PaymentHistoryResponseModel>? paymentHistory = JsonConvert.DeserializeObject<List<PaymentHistoryResponseModel>>(jsonResponse);

            // Kullanıcıya ait onaylanmış rezervasyon bilgilerini alıyoruz.
            List<ReservationDto> reservations = await _reservationManager.GetAllAsync();
            List<PaymentHistoryResponseModel> userReservations = new List<PaymentHistoryResponseModel>();

            // Her onaylanmış rezervasyon için, oda bilgilerini alıp, ödeme geçmişi verilerinden gelen kart numarası ile birleştiriyoruz.
            foreach (ReservationDto reservation in reservations.Where(r => r.AppUserId == user.Id && r.ReservationStatus == ReservationStatus.Confirmed))
            {
                RoomDto room = await _roomManager.GetByIdAsync(reservation.RoomId);
                userReservations.Add(new PaymentHistoryResponseModel
                {
                    ReservationId = reservation.Id,
                    CardUserName = userFullName,
                    RoomNumber = room?.RoomNumber ?? "Oda Bilgisi Yok",
                    PaymentAmount = reservation.TotalPrice,
                    CardNumber = paymentHistory?.FirstOrDefault()?.CardNumber ?? "Kart Bilgisi Yok",
                    StartDate = reservation.StartDate, 
                    EndDate = reservation.EndDate      
                });
            }

            // Oluşturulan ödeme geçmişi verilerini, UI'ya özgü ek bilgilerle birlikte PaymentHistoryPageVm'e ekliyoruz.
            PaymentHistoryPageVm pageVm = new PaymentHistoryPageVm
            {
                PaymentHistoryList = userReservations,
                PageTitle = "Ödeme Geçmişim",
                HelpText = "Ödeme geçmişinizi aşağıda görebilirsiniz."
            };

            // Hazırlanan PageVM, ilgili view'e gönderilir.
            return View(pageVm);
        }

        #endregion

        #region CancelPaymentConfirm

        /// <summary>
        /// Ödeme iptali onay sayfasını açar.
        /// Oturum açmış kullanıcının bilgilerini ve profilini alır; ilgili rezervasyonun onaylı olup olmadığını kontrol eder.
        /// Eğer rezervasyon onaylı ise, ilgili rezervasyon ve oda bilgileriyle PaymentCancelRequestModel oluşturulur ve 
        /// bu model, PaymentCancelPageVm içerisine eklenip view'e gönderilir.
        /// </summary>
        /// <param name="reservationId">İptal edilecek rezervasyonun ID'si</param>
        /// <returns>Ödeme iptali onay view'i</returns>
        [HttpGet]
        public async Task<IActionResult> CancelPaymentConfirm(int reservationId)
        {
            // Kullanıcının oturum açtığından emin oluyoruz; eğer oturum açmamışsa, hata mesajı verip ana sayfaya yönlendiriyoruz.
            if (User.Identity == null || !User.Identity.IsAuthenticated)
                return RedirectWithError("Ödeme iptali için giriş yapmalısınız.", "Index", "Home");

            // Kullanıcı bilgilerini ve profilini, merkezi metot aracılığıyla alıyoruz.
            var (user, userProfile) = await _appUserManager.GetUserWithProfileAsync(User.Identity.Name);
            if (user == null || userProfile == null)
                return RedirectWithError("Kullanıcı veya profil bilgileri bulunamadı.", "Index", "Payment");

            // Kullanıcının tam adını oluşturuyoruz.
            string userFullName = $"{userProfile.FirstName} {userProfile.LastName}";

            // Kullanıcının kart bilgilerini almak için ödeme geçmişi API'sine HTTP client ile çağrı yapıyoruz.
            HttpClient client = _httpClientFactory.CreateClient();
            string apiUrl = $"http://localhost:5190/api/Transaction/PaymentHistoryByUser/{userFullName}";
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (!response.IsSuccessStatusCode)
                return RedirectWithError("Kullanıcı kart bilgileri alınamadı.", "History", "Payment");

            // API'den gelen JSON yanıtını okuyup, PaymentHistoryResponseModel listesine deserialize ediyoruz.
            string jsonResponse = await response.Content.ReadAsStringAsync();
            List<PaymentHistoryResponseModel> paymentHistory = JsonConvert.DeserializeObject<List<PaymentHistoryResponseModel>>(jsonResponse);
            PaymentHistoryResponseModel userCard = paymentHistory.FirstOrDefault();
            if (userCard == null || string.IsNullOrEmpty(userCard.CardNumber))
                return RedirectWithError("Kart bilgisi bulunamadı.", "History", "Payment");

            // İptal edilecek rezervasyonu, onaylı rezervasyon olarak almak için ilgili manager metodunu kullanıyoruz.
            ReservationDto reservationObj = await _reservationManager.GetConfirmedReservationByIdAsync(reservationId);
            if (reservationObj == null)
                return RedirectWithError("Rezervasyon bulunamadı veya onaylı değil.", "History", "Payment");

            // Rezervasyonla ilişkilendirilen oda bilgisini alıyoruz.
            RoomDto room = await _roomManager.GetByIdAsync(reservationObj.RoomId);

            // PaymentCancelRequestModel oluşturuluyor; gerekli form verileri dolduruluyor.
            PaymentCancelRequestModel requestModel = new()
            {
                ReservationId = reservationId,
                CardUserName = userCard.CardUserName, // API'den alınan kart sahibi bilgisi
                CardNumber = userCard.CardNumber,       // API'den alınan kart numarası
                CVV = userCard.CVV,                     // API'den alınan CVV bilgisi
                RefundAmount = reservationObj.TotalPrice, // İptal edilecek tutar, rezervasyonun toplam fiyatı
                RoomNumber = room == null ? "Oda Bilgisi Yok" : room.RoomNumber,
                StartDate = reservationObj.StartDate,  
                EndDate = reservationObj.EndDate       
            };

            // Oluşturulan form verilerini, sayfa başlığı ve yardım metni ile birlikte PaymentCancelPageVm'e ekliyoruz.
            PaymentCancelPageVm pageVm = new PaymentCancelPageVm
            {
                PaymentCancelRequest = requestModel,
                PageTitle = "Ödeme İptali",
                HelpText = "Lütfen iptal işlemini onaylayın."
            };

            return View(pageVm);
        }

        /// <summary>
        /// Ödeme iptali işlemini gerçekleştirir.
        /// Gönderilen PaymentCancelRequestModel verilerini kullanarak ödeme iptali API çağrısı yapılır,
        /// ardından rezervasyon manager'ı üzerinden rezervasyon iptal edilir,
        /// ekstra servisler manager'ı ile ilgili ekstra servisler iptal edilir ve
        /// PaymentManager üzerinden ödeme kaydı "Deleted" durumuna çekilir.
        /// </summary>
        /// <param name="pageVm">Ödeme iptali için gerekli verileri içeren PageVM</param>
        /// <returns>İşlem sonucuna göre yönlendirme</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelPaymentConfirm(PaymentCancelPageVm pageVm)
        {
            // Formdan gönderilen ödeme iptali verilerini içeren modeli alıyoruz.
            PaymentCancelRequestModel requestModel = pageVm.PaymentCancelRequest;

            // Kullanıcının oturum açmış olduğunu kontrol ediyoruz.
            if (User.Identity == null || !User.Identity.IsAuthenticated)
                return RedirectWithError("Ödeme iptali için giriş yapmalısınız.", "Index", "Home");

            // İlgili rezervasyonun onaylı olup olmadığını kontrol etmek için onaylı rezervasyonu getiriyoruz.
            ReservationDto reservation = await _reservationManager.GetConfirmedReservationByIdAsync(requestModel.ReservationId);
            // Rezervasyon bulunamadıysa veya rezervasyon zaten iptal edilmişse hata mesajı ile yönlendiriyoruz.
            if (reservation == null)
                return RedirectWithError("Rezervasyon bulunamadı veya zaten iptal edilmiş.", "History", "Payment");

            // Ödeme iptali için API çağrısı yapabilmek üzere, HTTP client oluşturuyoruz.
            HttpClient client = _httpClientFactory.CreateClient();
            string cancelApiUrl = "http://localhost:5190/api/Transaction/CancelTransaction";

            // Gönderilecek verileri JSON formatına serileştiriyoruz.
            string jsonCancelContent = JsonConvert.SerializeObject(requestModel);
            StringContent content = new StringContent(jsonCancelContent, Encoding.UTF8, "application/json");

            // Ödeme iptali API'sine POST isteği gönderiyoruz.
            HttpResponseMessage cancelResponse = await client.PostAsync(cancelApiUrl, content);

            // Eğer API çağrısı başarılı ise:
            if (cancelResponse.IsSuccessStatusCode)
            {
                // Rezervasyon manager'ı kullanılarak, ilgili rezervasyon iptal ediliyor.
                await _reservationManager.CancelReservationAsync(reservation.Id);

                // Ekstra servislerin iptali, ilgili manager metodu ile merkezi olarak yürütülüyor.
                await _reservationExtraServiceManager.CancelExtraServicesByReservationIdAsync(reservation.Id);

                // Ödeme kaydı, PaymentManager üzerinden "Deleted" durumuna çekilerek iptal ediliyor.
                await _paymentManager.CancelPaymentByReservationIdAsync(requestModel.ReservationId);

                // İşlem başarılı ise, kullanıcıya başarı mesajı gösterilip, MyReservations sayfasına yönlendiriliyor.
                return RedirectWithError("Ödeme ve rezervasyon iptal edildi.");
            }

            // API çağrısı başarısız ise, hata mesajı belirlenip ödeme geçmişi sayfasına yönlendirme yapılır.
            return RedirectWithError("Ödeme iptal edilemedi.", "History", "Payment");
        }

        #endregion

        #region Invoice

        /// <summary>
        /// Fatura sayfasını açar. 
        /// Kullanıcının yaptığı ödeme detayları, rezervasyon, oda ve ekstra servis bilgileri tablo şeklinde görüntülenir.
        /// </summary>
        /// <param name="reservationId">İlgili rezervasyonun ID'si</param>
        /// <returns>Fatura view'i</returns>
        public async Task<IActionResult> Invoice(int reservationId)
        {
            // Rezervasyon bilgisini asenkron olarak çekiyoruz.
            ReservationDto reservation = await _reservationManager.GetByIdAsync(reservationId);
            if (reservation == null)
                return RedirectWithError("Rezervasyon bulunamadı.");

            // Ödeme kayıtlarını çekiyoruz.
            List<PaymentDto> payments = await _paymentManager.GetAllAsync();
            PaymentDto payment = payments.FirstOrDefault(p => p.ReservationId == reservationId);
            if (payment == null)
                return RedirectWithError("Ödeme kaydı bulunamadı.");

            // Rezervasyona ait oda bilgisini çekiyoruz.
            RoomDto room = await _roomManager.GetByIdAsync(reservation.RoomId);

            // Ekstra servisleri çekiyoruz.
            List<ReservationExtraServiceDto> resExtraServices = await _reservationExtraServiceManager.GetByReservationIdAsync(reservationId);
            List<ReservationExtraServiceDto> activeExtraServices = resExtraServices?
                .Where(es => es.Status != DataStatus.Deleted)
                .ToList() ?? new List<ReservationExtraServiceDto>();

            List<ExtraServiceDto> extraServices = new List<ExtraServiceDto>();
            foreach (ReservationExtraServiceDto resExtra in activeExtraServices)
            {
                ExtraServiceDto extraService = await _extraServiceManager.GetByIdAsync(resExtra.ExtraServiceId);
                if (extraService != null)
                    extraServices.Add(extraService);
            }

            // Kullanıcı bilgisini ve profilini alıyoruz.
            var (user, userProfile) = await _appUserManager.GetUserWithProfileAsync(User.Identity.Name);
            if (user == null || userProfile == null)
                return RedirectWithError("Kullanıcı bilgileri bulunamadı.");

            // Kullanıcı adını oluşturuyoruz.
            string userFullName = $"{userProfile.FirstName} {userProfile.LastName}";

            // Ödeme geçmişi API çağrısı yapıyoruz ve kart bilgisini çekiyoruz.
            HttpClient client = _httpClientFactory.CreateClient();
            string apiUrl = $"http://localhost:5190/api/Transaction/PaymentHistoryByUser/{userFullName}";
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
                return RedirectWithError("Kullanıcı kart bilgileri alınamadı.");

            string jsonResponse = await response.Content.ReadAsStringAsync();
            List<PaymentHistoryResponseModel> paymentHistory = JsonConvert.DeserializeObject<List<PaymentHistoryResponseModel>>(jsonResponse);

            // İlgili rezervasyonun kart numarasını çekiyoruz.
            string cardNumber = paymentHistory?.FirstOrDefault()?.CardNumber ?? "Kart Bilgisi Yok";


            // ViewModel'i dolduruyoruz.
            PaymentInvoicePageVm pageVm = new PaymentInvoicePageVm
            {
                Reservation = reservation,
                Payment = payment,
                Room = room,
                ExtraServices = extraServices,
                PageTitle = "Fatura Detayları",
                HelpText = "Aşağıda ödeme, rezervasyon ve ekstra hizmet detaylarınız görüntülenmektedir.",
                CardNumber = cardNumber // Yeni eklendi ✅
            };

            return View(pageVm);
        }

        #endregion

        #region SendInvoiceMail

        /// <summary>
        /// Fatura detaylarını e-posta olarak gönderir.
        /// İlgili rezervasyon, ödeme, oda ve ekstra servis bilgilerini çekip, HTML formatında fatura oluşturur ve
        /// MailService aracılığıyla kullanıcının kayıtlı e-posta adresine gönderir.
        /// </summary>
        /// <param name="reservationId">Fatura gönderilecek rezervasyonun ID'si</param>
        /// <returns>İşlem sonucuna göre yönlendirme</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendInvoiceMail(int reservationId)
        {
            // Rezervasyon
            ReservationDto reservation = await _reservationManager.GetByIdAsync(reservationId);
            if (reservation == null)
                return RedirectWithError("Rezervasyon bulunamadı.");

            // Ödeme
            List<PaymentDto> payments = await _paymentManager.GetAllAsync();
            PaymentDto payment = payments.FirstOrDefault(p => p.ReservationId == reservationId);
            if (payment == null)
                return RedirectWithError("Ödeme kaydı bulunamadı.");

            // Oda
            RoomDto room = await _roomManager.GetByIdAsync(reservation.RoomId);

            // Ekstra Servisler
            List<ReservationExtraServiceDto> resExtraServices = await _reservationExtraServiceManager.GetByReservationIdAsync(reservationId);
            List<ReservationExtraServiceDto> activeExtraServices = resExtraServices?
                .Where(es => es.Status != DataStatus.Deleted)
                .ToList() ?? new List<ReservationExtraServiceDto>();

            List<ExtraServiceDto> extraServices = new();
            foreach (var resExtra in activeExtraServices)
            {
                var extraService = await _extraServiceManager.GetByIdAsync(resExtra.ExtraServiceId);
                if (extraService != null)
                    extraServices.Add(extraService);
            }

            // Kullanıcı e-posta
            string userEmail = User.FindFirstValue(ClaimTypes.Email);
            if (string.IsNullOrEmpty(userEmail))
                return RedirectWithError("Mail adresiniz bulunamadı.");

            // Fatura HTML içeriğini oluştur
            string htmlBody = InvoiceHtmlGenerator.GenerateInvoiceHtml(reservation, payment, room, extraServices);

            // Mail gönderimi
            try
            {
                await MailService.SendAsync(
                    receiver: userEmail,
                    subject: "Bilge Hotel - Fatura Detaylarınız",
                    body: htmlBody
                );

                TempData["SuccessMessage"] = "Fatura bilgileri e-posta ile gönderildi.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Mail gönderilirken hata oluştu: {ex.Message}";
            }

            return RedirectToAction("Invoice", new { reservationId });
        }

        #endregion

        #region ControllerPrivateMethods

        /// <summary>
        /// Belirtilen hata mesajını TempData'ya atar ve belirtilen action ve controller'a yönlendirir.
        /// Böylece, hata durumlarında merkezi bir şekilde yönlendirme işlemi gerçekleştirilir.
        /// </summary>
        /// <param name="errorMessage">Gönderilecek hata mesajı</param>
        /// <param name="action">Yönlendirilecek action; varsayılan "MyReservations"</param>
        /// <param name="controller">Yönlendirilecek controller; varsayılan "Reservation"</param>
        /// <param name="routeValues">Ek yönlendirme parametreleri (opsiyonel)</param>
        /// <returns>Belirtilen action ve controller'a yönlendirme sonucu bir IActionResult</returns>
        private IActionResult RedirectWithError(string errorMessage, string action = "MyReservations", string controller = "Reservation", RouteValueDictionary routeValues = null)
        {
            // Hata mesajını TempData'ya atıyoruz.
            TempData["ErrorMessage"] = errorMessage;
            // Belirtilen action, controller ve ek route değerleriyle yönlendirme yapıyoruz.
            return RedirectToAction(action, controller, routeValues);
        }

        #endregion
    }
}