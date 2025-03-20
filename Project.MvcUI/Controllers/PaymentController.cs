using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Bll.Managers.Concretes;
using Project.Entities.Enums;
using Project.Entities.Models;
using Project.MvcUI.Models.PageVms.Payments;
using Project.MvcUI.Models.PureVms.Payments.RequestModels;
using Project.MvcUI.Models.PureVms.Payments.ResponseModels;
using System.Net.Http;
using System.Text;

namespace Project.MvcUI.Controllers
{
    [Authorize(Roles = "Admin,Member")] 
    public class PaymentController : Controller
    {
        private readonly IReservationManager _reservationManager;
        private readonly IAppUserManager _appUserManager;
        private readonly IAppUserProfileManager _appUserProfileManager;
        private readonly IRoomManager _roomManager;
        private readonly IPaymentManager _paymentManager;
        private readonly IReservationExtraServiceManager _reservationExtraServiceManager;
        private readonly IHttpClientFactory _httpClientFactory;

        public PaymentController(IReservationManager reservationManager, IAppUserManager appUserManager, IAppUserProfileManager appUserProfileManager, IRoomManager roomManager, IPaymentManager paymentManager, IReservationExtraServiceManager reservationExtraServiceManager, IHttpClientFactory httpClientFactory)
        {
            _reservationManager = reservationManager;
            _appUserManager = appUserManager;
            _appUserProfileManager = appUserProfileManager;
            _roomManager = roomManager;
            _paymentManager = paymentManager;
            _reservationExtraServiceManager = reservationExtraServiceManager;
            _httpClientFactory = httpClientFactory;
        }

        #region Index

        public IActionResult Index()
        {
            return View();
        } 

        #endregion

        #region Checkout

        /// <summary>
        /// Ödeme sayfasını açar.
        /// Rezervasyon ve kullanıcı profil bilgilerini getirip, ödeme işlemi için gerekli PageVM'i oluşturur.
        /// </summary>
        public async Task<IActionResult> Checkout(int reservationId) // Ödeme sayfası için PageVM oluşturma
        {
            // Rezervasyon bilgisini asenkron olarak alıyoruz
            ReservationDto reservation = await _reservationManager.GetByIdAsync(reservationId); // Rezervasyon bilgisi çekiliyor
            if (reservation == null)
            {
                // Rezervasyon bulunamazsa hata mesajı verip, rezervasyon listesinin bulunduğu sayfaya yönlendiriyoruz
                TempData["ErrorMessage"] = "Rezervasyon bulunamadı.";
                return RedirectToAction("MyReservations", "Reservation");
            }

            // Rezervasyon durumunu kontrol ediyoruz: Eğer rezervasyon zaten onaylanmış veya iptal edilmişse, ödeme işlemi başlatılamaz
            if (!await _reservationManager.IsReservationPayableAsync(reservationId))
            {
                TempData["ErrorMessage"] = "Bu rezervasyon için ödeme işlemi başlatılamaz. Rezervasyon zaten onaylanmış veya iptal edilmiş.";
                return RedirectToAction("MyReservations", "Reservation");
            }

            // Rezervasyonun ilişkilendirildiği kullanıcı bilgisinin (AppUserId) dolu olup olmadığını kontrol ediyoruz
            if (reservation.AppUserId == null)
            {
                TempData["ErrorMessage"] = "Rezervasyonla ilişkilendirilmiş kullanıcı bulunamadı.";
                return RedirectToAction("MyReservations", "Reservation");
            }

            // Rezervasyona ait kullanıcı profil bilgisini getiriyoruz
            AppUserProfileDto userProfile = await _appUserProfileManager.GetByAppUserIdAsync(reservation.AppUserId.Value); // Kullanıcı profili çekiliyor

            if (userProfile == null)
            {
                TempData["ErrorMessage"] = "Kullanıcı bilgisi bulunamadı.";
                return RedirectToAction("MyReservations", "Reservation");
            }

            // Ödeme işlemi için kullanılacak pure model oluşturuluyor
            PaymentProcessRequestModel processRequest = new PaymentProcessRequestModel
            {
                ReservationId = reservation.Id,          // Rezervasyon ID'si atanıyor
                CardUserName = "",                       // Kart sahibi bilgisi; kullanıcı tarafından manuel girilecek
                CardNumber = "",                         // Kart numarası; kullanıcı tarafından manuel girilecek
                CVV = "",                                // CVV; kullanıcı tarafından manuel girilecek
                ExpiryMonth = DateTime.Now.Month,        // Varsayılan olarak geçerli ay
                ExpiryYear = DateTime.Now.Year,          // Varsayılan olarak geçerli yıl
                ShoppingPrice = reservation.TotalPrice   // Ödeme tutarı, rezervasyonun toplam fiyatı olarak atanıyor
            };

            // UI'ya özgü ek bilgileri barındıran PageVM oluşturuluyor
            PaymentProcessPageVm pageVm = new PaymentProcessPageVm
            {
                PaymentProcessRequest = processRequest,  // Pure model PageVM'e ekleniyor
                PageTitle = "💳 Ödeme Yap"               // Sayfa başlığı belirleniyor
            };

            // Oluşturulan PageVM ile view render ediliyor
            return View(pageVm);
        }

        #endregion

        #region ProcessPayment

        /// <summary>
        /// Ödeme işlemini gerçekleştirir.
        /// PaymentProcessPageVm içindeki PaymentProcessRequest verilerini kullanarak ödeme API'sine çağrı yapar.
        /// API başarılı ise, ilgili rezervasyon "Confirmed" duruma getirilir ve ödeme kaydı manager üzerinden oluşturulur.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProcessPayment(PaymentProcessPageVm pageVm)
        {
            // Formdan gönderilen ödeme bilgilerinin yer aldığı modeli PageVM içinden alıyoruz.
            PaymentProcessRequestModel model = pageVm.PaymentProcessRequest;

            // Model validasyonu kontrol ediliyor.
            // Eğer model valid değilse, hata mesajı set edilip Checkout sayfasına yönlendiriliyor.
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Lütfen tüm alanları eksiksiz doldurun.";
                return RedirectToAction("Checkout", new { reservationId = model.ReservationId });
            }

            // HTTP client örneği oluşturuluyor.
            HttpClient client = _httpClientFactory.CreateClient();

            // Ödeme API'sinin URL'si belirleniyor.
            string apiUrl = "http://localhost:5190/api/Transaction/StartTransaction";

            // API'ye gönderilecek JSON içeriği oluşturuluyor.
            // Bu içerik, ödeme işlemi için gerekli kart ve tutar bilgilerini içerir.
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

            // API'ye POST isteği gönderiliyor.
            HttpResponseMessage response = await client.PostAsync(apiUrl, content);

            // API çağrısı başarılı ise:
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    // Rezervasyonun onaylanması işlemi, ilgili manager metodu aracılığıyla merkezi hale getiriliyor.
                    // Eğer rezervasyon onaylanamazsa exception fırlatılır.
                    await _reservationManager.ConfirmReservationAsync(model.ReservationId);
                }
                catch (Exception ex)
                {
                    // Rezervasyon onaylama sırasında hata oluşursa, hata mesajı belirlenip Checkout sayfasına yönlendiriliyor.
                    TempData["ErrorMessage"] = "Rezervasyon güncellenirken bir hata oluştu: " + ex.Message;
                    return RedirectToAction("Checkout", new { reservationId = model.ReservationId });
                }

                try
                {
                    // Ödeme kaydı işlemi, ilgili manager metodu kullanılarak merkezi hale getiriliyor.
                    // Eğer ödeme kaydı oluşturulamazsa exception fırlatılır.
                    await _paymentManager.RecordPaymentAsync(model.ReservationId, model.ShoppingPrice);
                }
                catch (Exception ex)
                {
                    // Ödeme kaydı oluşturma sırasında hata oluşursa, hata mesajı belirlenip Checkout sayfasına yönlendiriliyor.
                    TempData["ErrorMessage"] = "Ödeme kaydı oluşturulurken bir hata oluştu: " + ex.Message;
                    return RedirectToAction("Checkout", new { reservationId = model.ReservationId });
                }

                // İşlem başarılı ise, isteğe bağlı olarak ödeme sonucu bilgileri oluşturulabilir.
                // Ancak burada direkt olarak kullanıcı ödeme geçmişi sayfasına yönlendiriliyor.
                TempData["SuccessMessage"] = "Ödeme başarıyla tamamlandı!";
                return RedirectToAction("History", "Payment");
            }
            else
            {
                // API çağrısı başarısız ise, hata mesajı belirlenip Checkout sayfasına yönlendiriliyor.
                TempData["ErrorMessage"] = "Ödeme başarısız.";
                return RedirectToAction("Checkout", new { reservationId = model.ReservationId });
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
            {
                TempData["ErrorMessage"] = "Ödeme geçmişini görmek için giriş yapmalısınız.";
                return RedirectToAction("Index", "Home");
            }

            // Kullanıcının tüm bilgilerini alıp, aktif oturum açan kullanıcının bilgilerini User.Identity.Name üzerinden buluyoruz.
            List<AppUserDto> allUsers = await _appUserManager.GetAllAsync();

            AppUserDto? user = allUsers.FirstOrDefault(u => u.UserName == User.Identity.Name);

            if (user == null)
            {
                TempData["ErrorMessage"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("Index");
            }

            // Kullanıcının profil bilgilerini getiriyoruz.
            AppUserProfileDto userProfile = await _appUserProfileManager.GetByAppUserIdAsync(user.Id);

            if (userProfile == null)
            {
                TempData["ErrorMessage"] = "Kullanıcı profili bulunamadı.";
                return RedirectToAction("Index");
            }

            // Kullanıcının tam adını oluşturuyoruz.
            string userFullName = $"{userProfile.FirstName} {userProfile.LastName}";

            // Ödeme geçmişi API'sine çağrı yaparak, kullanıcının kart bilgilerini içeren verileri elde ediyoruz.
            HttpClient client = _httpClientFactory.CreateClient();

            string apiUrl = $"http://localhost:5190/api/Transaction/PaymentHistoryByUser/{userFullName}";

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
            {
                TempData["ErrorMessage"] = "Ödeme geçmişi alınamadı.";
                return RedirectToAction("Index");
            }

            // API'den gelen JSON yanıtı okunuyor ve PaymentHistoryResponseModel listesine deserialize ediliyor.
            string jsonResponse = await response.Content.ReadAsStringAsync();
            List<PaymentHistoryResponseModel>? paymentHistory = JsonConvert.DeserializeObject<List<PaymentHistoryResponseModel>>(jsonResponse);

            // Kullanıcıya ait onaylanmış rezervasyon bilgilerini alıyoruz.
            List<ReservationDto> reservations = await _reservationManager.GetAllAsync();
            List<PaymentHistoryResponseModel> userReservations = new List<PaymentHistoryResponseModel>();

            // Her rezervasyon için, oda bilgilerini çekip, ödeme geçmişi verilerinden gelen kart numarası ile birleştiriyoruz.
            foreach (ReservationDto reservation in reservations.Where(r => r.AppUserId == user.Id && r.ReservationStatus == ReservationStatus.Confirmed))
            {
                RoomDto room = await _roomManager.GetByIdAsync(reservation.RoomId);
                userReservations.Add(new PaymentHistoryResponseModel
                {
                    ReservationId = reservation.Id,
                    CardUserName = userFullName,
                    RoomNumber = room?.RoomNumber ?? "Oda Bilgisi Yok",
                    PaymentAmount = reservation.TotalPrice,
                    CardNumber = paymentHistory?.FirstOrDefault()?.CardNumber ?? "Kart Bilgisi Yok"
                });
            }

            // Oluşturulan ödeme geçmişi verilerini, UI'ya özgü ek bilgilerle birlikte PaymentHistoryPageVm'e ekliyoruz.
            PaymentHistoryPageVm pageVm = new PaymentHistoryPageVm
            {
                PaymentHistoryList = userReservations,
                PageTitle = "Ödeme Geçmişim",
                HelpText = "Ödeme geçmişinizi aşağıda görebilirsiniz."
            };

            // PageVM view'e gönderiliyor.
            return View(pageVm);
        }

        #endregion

        #region CancelPaymentConfirm

        /// <summary>
        /// Ödeme iptali onay sayfasını açar.
        /// Oturum açmış kullanıcının bilgilerini, profilini ve kart bilgilerini alır; 
        /// ilgili rezervasyonun onaylı olup olmadığını kontrol eder. Eğer rezervasyon onaylı ise,
        /// ilgili rezervasyon ve oda bilgileriyle PaymentCancelRequestModel oluşturulur ve bu model,
        /// PaymentCancelPageVm içerisine eklenip view'e gönderilir.
        /// </summary>
        /// <param name="reservationId">İptal edilecek rezervasyonun ID'si</param>
        /// <returns>Ödeme iptali onay view'i</returns>
        [HttpGet]
        public async Task<IActionResult> CancelPaymentConfirm(int reservationId)
        {
            // Kullanıcının oturum açtığını doğruluyoruz.
            if (User.Identity == null || !User.Identity.IsAuthenticated)
            {
                TempData["ErrorMessage"] = "Ödeme iptali için giriş yapmalısınız.";
                return RedirectToAction("Index", "Home");
            }

            // Kullanıcı bilgilerini ve profil bilgilerini merkezi metot üzerinden alıyoruz.
            var (user, userProfile) = await _appUserManager.GetUserWithProfileAsync(User.Identity.Name);
            if (user == null || userProfile == null)
            {
                TempData["ErrorMessage"] = "Kullanıcı veya profil bilgileri bulunamadı.";
                return RedirectToAction("Index");
            }

            // Kullanıcının tam adını oluşturuyoruz.
            string userFullName = $"{userProfile.FirstName} {userProfile.LastName}";

            // Kullanıcının kart bilgilerini almak için, HTTP client ile ödeme geçmişi API'sine çağrı yapıyoruz.
            HttpClient client = _httpClientFactory.CreateClient();
            string apiUrl = $"http://localhost:5190/api/Transaction/PaymentHistoryByUser/{userFullName}";
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (!response.IsSuccessStatusCode)
            {
                TempData["ErrorMessage"] = "Kullanıcı kart bilgileri alınamadı.";
                return RedirectToAction("History");
            }

            // API'den gelen JSON yanıtını okuyup, PaymentHistoryResponseModel listesine deserialize ediyoruz.
            string jsonResponse = await response.Content.ReadAsStringAsync();
            List<PaymentHistoryResponseModel> paymentHistory = JsonConvert.DeserializeObject<List<PaymentHistoryResponseModel>>(jsonResponse);
            PaymentHistoryResponseModel userCard = paymentHistory.FirstOrDefault();
            if (userCard == null || string.IsNullOrEmpty(userCard.CardNumber))
            {
                TempData["ErrorMessage"] = "Kart bilgisi bulunamadı.";
                return RedirectToAction("History");
            }

            // İptal edilecek rezervasyonu, onaylı rezervasyon olarak almak için ilgili manager metodunu kullanıyoruz.
            ReservationDto reservationObj = await _reservationManager.GetConfirmedReservationByIdAsync(reservationId);
            if (reservationObj == null)
            {
                TempData["ErrorMessage"] = "Rezervasyon bulunamadı veya onaylı değil.";
                return RedirectToAction("History");
            }

            // Rezervasyonla ilişkilendirilen oda bilgilerini alıyoruz.
            RoomDto room = await _roomManager.GetByIdAsync(reservationObj.RoomId);

            // PaymentCancelRequestModel oluşturuluyor; gerekli form verileri dolduruluyor.
            PaymentCancelRequestModel requestModel = new()
            {
                ReservationId = reservationId,
                CardUserName = userCard.CardUserName,
                CardNumber = userCard.CardNumber,
                CVV = userCard.CVV,
                RefundAmount = reservationObj.TotalPrice,
                RoomNumber = (room == null) ? "Oda Bilgisi Yok" : room.RoomNumber
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

            // Kullanıcının oturum açmış olduğunu doğruluyoruz.
            if (User.Identity == null || !User.Identity.IsAuthenticated)
            {
                TempData["ErrorMessage"] = "Ödeme iptali için giriş yapmalısınız.";
                return RedirectToAction("Index", "Home");
            }

            // İlgili rezervasyonun onaylı olup olmadığını kontrol etmek için, manager üzerinden onaylı rezervasyonu getiriyoruz.
            ReservationDto reservation = await _reservationManager.GetConfirmedReservationByIdAsync(requestModel.ReservationId);
            if (reservation == null)
            {
                TempData["ErrorMessage"] = "Rezervasyon bulunamadı veya zaten iptal edilmiş.";
                return RedirectToAction("History");
            }

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
                TempData["SuccessMessage"] = "Ödeme ve rezervasyon iptal edildi.";
                return RedirectToAction("MyReservations", "Reservation");
            }

            // API çağrısı başarısız ise, hata mesajı belirlenip ödeme geçmişi sayfasına yönlendiriliyor.
            TempData["ErrorMessage"] = "Ödeme iptal edilemedi.";
            return RedirectToAction("History");
        }

        #endregion
    }
}