using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.WebApi.Models.ContextClasses;
using Project.WebApi.Models.Entities;
using Project.WebApi.Models.RequestModels;
using Project.WebApi.Models.ResponseModels;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        // DbContext örneği, veritabanı işlemleri için kullanılır
        MyContext _context;

        // Constructor ile DI üzerinden MyContext nesnesi alınır
        public TransactionController(MyContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Ödeme işlemini başlatır.
        /// Kullanıcının kart bilgilerini doğrular, yeterli bakiye varsa ödeme tutarını düşer.
        /// </summary>
        [HttpPost("StartTransaction")]
        public async Task<IActionResult> StartTransaction(PaymentRequestModel item)
        {
            // Kart bilgileri eşleşen kullanıcı aranır
            UserCardInfo? userCard = await _context.CardInfoes
                .SingleOrDefaultAsync(x => x.CardNumber == item.CardNumber &&
                                           x.CVV == item.CVV &&
                                           x.CardUserName == item.CardUserName &&
                                           x.ExpiryMonth == item.ExpiryMonth &&
                                           x.ExpiryYear == item.ExpiryYear);

            // Kart bulunamazsa hata döndür
            if (userCard == null)
                return BadRequest("Kart bulunamadı veya bilgiler hatalı.");

            // Bakiye yetersizse hata döndür
            if (userCard.Balance < item.ShoppingPrice)
                return BadRequest("Kart bakiyesi yetersiz.");

            // Bakiye düşülür
            userCard.Balance -= item.ShoppingPrice;
            await _context.SaveChangesAsync();

            return Ok("Ödeme başarıyla alındı.");
        }

        /// <summary>
        /// Ödeme iptal işlemini gerçekleştirir.
        /// Kart bilgileri doğrulanır ve belirlenen tutar karta geri yüklenir.
        /// </summary>
        [HttpPost("CancelTransaction")]
        public async Task<IActionResult> CancelTransaction(PaymentCancelRequestModel item)
        {
            // Kart doğrulama işlemi (isim ve CVV yeterlidir)
            UserCardInfo? userCard = await _context.CardInfoes
                .SingleOrDefaultAsync(x => x.CardNumber == item.CardNumber &&
                                           x.CVV == item.CVV &&
                                           x.CardUserName == item.CardUserName);

            // Kart bulunamazsa hata döndür
            if (userCard == null)
                return BadRequest("Kart bulunamadı veya bilgiler hatalı.");

            // İade işlemi (bakiye geri eklenir)
            userCard.Balance += item.RefundAmount;
            await _context.SaveChangesAsync();

            return Ok("Ödeme iptali başarıyla gerçekleştirildi.");
        }

        /// <summary>
        /// Kullanıcının ödeme geçmişi bilgilerini getirir.
        /// Not: Şimdilik sadece kart bilgileri ve boş ödeme tutarı döndürülmektedir.
        /// </summary>
        [HttpGet("PaymentHistoryByUser/{fullName}")]
        public async Task<IActionResult> GetPaymentHistoryByUser(string fullName)
        {
            // Kart sahibi adına göre kart bilgileri çekilir
            UserCardInfo? userCard = await _context.CardInfoes
                .FirstOrDefaultAsync(x => x.CardUserName == fullName);

            if (userCard == null)
                return BadRequest("Kullanıcıya ait kart bulunamadı.");

            // Geriye döndürülecek model oluşturulur
            PaymentHistoryResponseModel paymentHistory = new() 
            {
                CardUserName = userCard.CardUserName,
                CardNumber = userCard.CardNumber,
                CVV = userCard.CVV, // Güvenlik için gerçek projelerde gösterilmemeli!
                PaymentAmount = 0 // Gerçek ödeme geçmişi tutarları burada yok
            };

            return Ok(new List<PaymentHistoryResponseModel> { paymentHistory });
        }
    }
}

