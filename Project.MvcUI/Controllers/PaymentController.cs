using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Bll.Managers.Abstracts;
using Project.Bll.Managers.Concretes;
using Project.Entities.Enums;
using Project.MvcUI.Models.PureVms.Payments.RequestModels;
using Project.MvcUI.Models.PureVms.Payments.ResponseModels;
using System.Net.Http;
using System.Text;

namespace Project.MvcUI.Controllers
{
    [Authorize(Roles = "Admin,Member")] // Kullanıcılar ve adminler ödeme yapabilir
    public class PaymentController : Controller
    {
        private readonly IReservationManager _reservationManager;
        private readonly IAppUserManager _appUserManager;
        private readonly IAppUserProfileManager _appUserProfileManager;
        private readonly IRoomManager _roomManager;
        private readonly IHttpClientFactory _httpClientFactory;

        public PaymentController(IReservationManager reservationManager, IAppUserManager appUserManager, IAppUserProfileManager appUserProfileManager, IHttpClientFactory httpClientFactory, IRoomManager roomManager)
        {
            _reservationManager = reservationManager;
            _appUserManager = appUserManager;
            _appUserProfileManager = appUserProfileManager;
            _httpClientFactory = httpClientFactory;
            _roomManager = roomManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// ✅ **Ödeme Sayfasını Açma**
        [HttpGet]
        public async Task<IActionResult> Checkout(int reservationId)
        {
            var reservation = await _reservationManager.GetByIdAsync(reservationId);
            if (reservation == null)
            {
                TempData["ErrorMessage"] = "Rezervasyon bulunamadı.";
                return RedirectToAction("Index", "Reservation");
            }

            var userProfile = await _appUserProfileManager.GetByAppUserIdAsync(reservation.AppUserId.Value);
            if (userProfile == null)
            {
                TempData["ErrorMessage"] = "Kullanıcı bilgisi bulunamadı.";
                return RedirectToAction("Index", "Reservation");
            }

            var model = new PaymentProcessRequestModel
            {
                ReservationId = reservation.Id,
                CardUserName = "", // Kullanıcı kart bilgilerini manuel girecek
                CardNumber = "",
                CVV = "",
                ExpiryMonth = DateTime.Now.Month,
                ExpiryYear = DateTime.Now.Year,
                ShoppingPrice = reservation.TotalPrice  // ✅ **TotalAmount yerine ShoppingPrice gönderiliyor**
            };

            return View(model);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProcessPayment(PaymentProcessRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Lütfen tüm alanları eksiksiz doldurun.";

                foreach (var key in ModelState.Keys)
                {
                    foreach (var error in ModelState[key].Errors)
                    {
                        Console.WriteLine($"Key: {key}, Hata: {error.ErrorMessage}");
                    }
                }

                return RedirectToAction("Checkout", new { reservationId = model.ReservationId });
            }

            Console.WriteLine($"Ödeme İşlemi Başlatılıyor: {JsonConvert.SerializeObject(model)}");

            var client = _httpClientFactory.CreateClient();
            string apiUrl = "http://localhost:5190/api/Transaction/StartTransaction";

            var jsonContent = JsonConvert.SerializeObject(new
            {
                model.ReservationId,
                model.CardUserName,
                model.CardNumber,
                model.CVV,
                model.ExpiryMonth,
                model.ExpiryYear,
                ShoppingPrice = model.ShoppingPrice // ✅ **API'ye doğru isimle gönderiliyor**
            });

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(apiUrl, content);
            var responseString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var reservation = await _reservationManager.GetByIdAsync(model.ReservationId);
                if (reservation != null)
                {
                    reservation.ReservationStatus = Project.Entities.Enums.ReservationStatus.Confirmed;
                    await _reservationManager.UpdateAsync(reservation);
                }

                TempData["SuccessMessage"] = "Ödeme başarıyla tamamlandı ve rezervasyon onaylandı!";
                return RedirectToAction("MyReservations", "Reservation");
            }
            else
            {
                TempData["ErrorMessage"] = $"Ödeme başarısız: {responseString}";
                return RedirectToAction("Checkout", new { reservationId = model.ReservationId });
            }
        }



        [HttpGet]
        public async Task<IActionResult> History()
        {
            if (User.Identity == null || !User.Identity.IsAuthenticated)
            {
                TempData["ErrorMessage"] = "Ödeme geçmişini görmek için giriş yapmalısınız.";
                return RedirectToAction("Index", "Home");
            }

            // **Giriş yapan kullanıcının bilgilerini al**
            var allUsers = await _appUserManager.GetAllAsync();
            var user = allUsers.FirstOrDefault(u => u.UserName == User.Identity.Name);

            if (user == null)
            {
                TempData["ErrorMessage"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("Index");
            }

            // **Kullanıcının profil bilgilerini al**
            var userProfile = await _appUserProfileManager.GetByAppUserIdAsync(user.Id);
            if (userProfile == null)
            {
                TempData["ErrorMessage"] = "Kullanıcı profili bulunamadı.";
                return RedirectToAction("Index");
            }

            string userFullName = $"{userProfile.FirstName} {userProfile.LastName}";

            var client = _httpClientFactory.CreateClient();
            string apiUrl = $"http://localhost:5190/api/Transaction/PaymentHistoryByUser/{userFullName}";

            var response = await client.GetAsync(apiUrl);
            if (!response.IsSuccessStatusCode)
            {
                TempData["ErrorMessage"] = "Ödeme geçmişi alınamadı.";
                return RedirectToAction("Index");
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var paymentHistory = JsonConvert.DeserializeObject<List<PaymentHistoryResponseModel>>(jsonResponse);

            // ✅ **Rezervasyon bilgilerini çekiyoruz**
            var reservations = await _reservationManager.GetAllAsync();

            var userReservations = new List<PaymentHistoryResponseModel>();

            foreach (var reservation in reservations.Where(r => r.AppUserId == user.Id && r.ReservationStatus == Project.Entities.Enums.ReservationStatus.Confirmed))
            {
                var room = await _roomManager.GetByIdAsync(reservation.RoomId);
                userReservations.Add(new PaymentHistoryResponseModel
                {
                    ReservationId = reservation.Id, // ✅ Rezervasyon ID eklendi
                    CardUserName = userFullName,
                    RoomNumber = room?.RoomNumber ?? "Oda Bilgisi Yok",
                    PaymentAmount = reservation.TotalPrice,
                    CardNumber = paymentHistory.FirstOrDefault()?.CardNumber ?? "Kart Bilgisi Yok"
                });
            }


            return View(userReservations);
        }



        [HttpGet]
        public async Task<IActionResult> CancelPaymentConfirm(int Id)
        {
            if (User.Identity == null || !User.Identity.IsAuthenticated)
            {
                TempData["ErrorMessage"] = "Ödeme iptali için giriş yapmalısınız.";
                return RedirectToAction("Index", "Home");
            }

            var allUsers = await _appUserManager.GetAllAsync();
            var user = allUsers.FirstOrDefault(u => u.UserName == User.Identity.Name);

            if (user == null)
            {
                TempData["ErrorMessage"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("Index");
            }

            var userProfile = await _appUserProfileManager.GetByAppUserIdAsync(user.Id);
            if (userProfile == null)
            {
                TempData["ErrorMessage"] = "Kullanıcı profili bulunamadı.";
                return RedirectToAction("Index");
            }

            string userFullName = $"{userProfile.FirstName} {userProfile.LastName}";

            var client = _httpClientFactory.CreateClient();
            string apiUrl = $"http://localhost:5190/api/Transaction/PaymentHistoryByUser/{userFullName}";

            var response = await client.GetAsync(apiUrl);
            if (!response.IsSuccessStatusCode)
            {
                TempData["ErrorMessage"] = "Kullanıcı kart bilgileri alınamadı.";
                return RedirectToAction("History");
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var paymentHistory = JsonConvert.DeserializeObject<List<PaymentHistoryResponseModel>>(jsonResponse);
            var userCard = paymentHistory.FirstOrDefault();

            if (userCard == null || string.IsNullOrEmpty(userCard.CardNumber))
            {
                TempData["ErrorMessage"] = "Kart bilgisi bulunamadı.";
                return RedirectToAction("History");
            }

            var reservation = await _reservationManager.GetByIdAsync(Id);
            if (reservation == null)
            {
                TempData["ErrorMessage"] = "Rezervasyon bulunamadı.";
                return RedirectToAction("History");
            }

            var room = await _roomManager.GetByIdAsync(reservation.RoomId);

            var model = new PaymentCancelRequestModel
            {
                ReservationId = Id,
                CardUserName = userCard.CardUserName,
                CardNumber = userCard.CardNumber,
                CVV = userCard.CVV,
                RefundAmount = reservation.TotalPrice,
                RoomNumber = room?.RoomNumber ?? "Oda Bilgisi Yok"
            };

            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmCancelPayment(PaymentCancelRequestModel model)
        {
            if (User.Identity == null || !User.Identity.IsAuthenticated)
            {
                TempData["ErrorMessage"] = "Ödeme iptali için giriş yapmalısınız.";
                return RedirectToAction("Index", "Home");
            }

            var reservation = await _reservationManager.GetByIdAsync(model.ReservationId);
            if (reservation == null)
            {
                TempData["ErrorMessage"] = "Rezervasyon bulunamadı.";
                return RedirectToAction("History");
            }

            if (reservation.ReservationStatus != ReservationStatus.Confirmed)
            {
                TempData["ErrorMessage"] = "Bu rezervasyon için ödeme yapılmamış veya zaten iptal edilmiş.";
                return RedirectToAction("History");
            }

            var client = _httpClientFactory.CreateClient();
            string cancelApiUrl = "http://localhost:5190/api/Transaction/CancelTransaction";

            var jsonCancelContent = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonCancelContent, Encoding.UTF8, "application/json");

            var cancelResponse = await client.PostAsync(cancelApiUrl, content);
            var cancelResponseString = await cancelResponse.Content.ReadAsStringAsync();

            if (cancelResponse.IsSuccessStatusCode)
            {
                // **✅ Ödeme iptal edildikten sonra rezervasyon durumunu 'Canceled' yap**
                reservation.ReservationStatus = ReservationStatus.Canceled;
                reservation.Status = DataStatus.Updated;
                reservation.ModifiedDate = DateTime.Now;
                await _reservationManager.UpdateAsync(reservation);

                TempData["SuccessMessage"] = "Ödeme başarıyla iptal edildi ve rezervasyon tamamen iptal edildi.";
                //return RedirectToAction("History");
                return RedirectToAction("MyReservations", "Reservation", new { Id = reservation.Id });

            }
            else
            {
                TempData["ErrorMessage"] = $"Ödeme iptal edilemedi: {cancelResponseString}";
                return RedirectToAction("History");
            }
        }












    }
}