using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.WebApi.Models.ContextClasses;
using Project.WebApi.Models.RequestModels;
using Project.WebApi.Models.ResponseModels;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        MyContext _context;

        public TransactionController(MyContext context)
        {
            _context = context;
        }

        /// ✅ **Ödeme İşlemi Başlatma**
        [HttpPost("StartTransaction")]
        public async Task<IActionResult> StartTransaction(PaymentRequestModel item)
        {
            var userCard = await _context.CardInfoes
                .SingleOrDefaultAsync(x => x.CardNumber == item.CardNumber &&
                                           x.CVV == item.CVV &&
                                           x.CardUserName == item.CardUserName &&
                                           x.ExpiryMonth == item.ExpiryMonth &&
                                           x.ExpiryYear == item.ExpiryYear);

            if (userCard == null)
                return BadRequest("Kart bulunamadı veya bilgiler hatalı.");

            if (userCard.Balance < item.ShoppingPrice)
                return BadRequest("Kart bakiyesi yetersiz.");

            // ✅ **Bakiye düşülüyor**
            userCard.Balance -= item.ShoppingPrice;
            await _context.SaveChangesAsync();

            return Ok("Ödeme başarıyla alındı.");
        }

        /// ✅ **Ödeme İptali**
        [HttpPost("CancelTransaction")]
        public async Task<IActionResult> CancelTransaction(PaymentCancelRequestModel item)
        {
            var userCard = await _context.CardInfoes
                .SingleOrDefaultAsync(x => x.CardNumber == item.CardNumber &&
                                           x.CVV == item.CVV &&
                                           x.CardUserName == item.CardUserName);

            if (userCard == null)
                return BadRequest("Kart bulunamadı veya bilgiler hatalı.");

            // ✅ **Bakiye iade ediliyor**
            userCard.Balance += item.RefundAmount;
            await _context.SaveChangesAsync();

            return Ok("Ödeme iptali başarıyla gerçekleştirildi.");
        }

        /// ✅ **Ödeme Geçmişi**
        [HttpGet("PaymentHistoryByUser/{fullName}")]
        public async Task<IActionResult> GetPaymentHistoryByUser(string fullName)
        {
            var userCard = await _context.CardInfoes
                .FirstOrDefaultAsync(x => x.CardUserName == fullName);

            if (userCard == null)
                return BadRequest("Kullanıcıya ait kart bulunamadı.");

            var paymentHistory = new PaymentHistoryResponseModel
            {
                CardUserName = userCard.CardUserName,
                CardNumber = userCard.CardNumber,
                CVV = userCard.CVV, // ✅ CVV Bilgisini de gönderiyoruz
                PaymentAmount = 0 // Ödeme işlemi için kullanılacak
            };

            return Ok(new List<PaymentHistoryResponseModel> { paymentHistory });
        }

    }
}

