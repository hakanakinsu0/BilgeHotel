using Project.Bll.DtoClasses;
using System.Text;

namespace Project.MvcUI.Helpers
{
    public static class InvoiceHtmlGenerator
    {
        public static string GenerateInvoiceHtml(ReservationDto reservation, PaymentDto payment, RoomDto room, List<ExtraServiceDto> extraServices)
        {
            StringBuilder emailBody = new StringBuilder();

            emailBody.Append("<h2>Bilge Hotel - Fatura Detayları</h2>");
            emailBody.Append("<table style='border-collapse: collapse; width: 100%;'>");
            emailBody.Append("<tr><th style='border: 1px solid #ddd; padding: 8px;'>Rezervasyon ID</th>");
            emailBody.Append($"<td style='border: 1px solid #ddd; padding: 8px;'>{reservation.Id}</td></tr>");
            emailBody.Append("<tr><th style='border: 1px solid #ddd; padding: 8px;'>Oda Numarası</th>");
            emailBody.Append($"<td style='border: 1px solid #ddd; padding: 8px;'>{room?.RoomNumber ?? "Bilinmiyor"}</td></tr>");
            emailBody.Append("<tr><th style='border: 1px solid #ddd; padding: 8px;'>Başlangıç Tarihi</th>");
            emailBody.Append($"<td style='border: 1px solid #ddd; padding: 8px;'>{reservation.StartDate:dd.MM.yyyy}</td></tr>");
            emailBody.Append("<tr><th style='border: 1px solid #ddd; padding: 8px;'>Bitiş Tarihi</th>");
            emailBody.Append($"<td style='border: 1px solid #ddd; padding: 8px;'>{reservation.EndDate:dd.MM.yyyy}</td></tr>");
            emailBody.Append("<tr><th style='border: 1px solid #ddd; padding: 8px;'>Ödeme Tutarı</th>");
            emailBody.Append($"<td style='border: 1px solid #ddd; padding: 8px;'>{payment.PaymentAmount} ₺</td></tr>");
            emailBody.Append("<tr><th style='border: 1px solid #ddd; padding: 8px;'>Ödeme Tarihi</th>");
            emailBody.Append($"<td style='border: 1px solid #ddd; padding: 8px;'>{payment.PaymentDate:yyyy-MM-dd HH:mm}</td></tr>");
            emailBody.Append("</table>");

            if (extraServices.Any())
            {
                emailBody.Append("<h3>Ekstra Hizmetler</h3>");
                emailBody.Append("<table style='border-collapse: collapse; width: 100%;'>");
                emailBody.Append("<tr><th style='border: 1px solid #ddd; padding: 8px;'>Hizmet Adı</th>");
                emailBody.Append("<th style='border: 1px solid #ddd; padding: 8px;'>Fiyat</th></tr>");

                foreach (var service in extraServices)
                {
                    emailBody.Append("<tr>");
                    emailBody.Append($"<td style='border: 1px solid #ddd; padding: 8px;'>{service.Name}</td>");
                    emailBody.Append($"<td style='border: 1px solid #ddd; padding: 8px;'>{service.Price} ₺</td>");
                    emailBody.Append("</tr>");
                }

                emailBody.Append("</table>");
            }

            return emailBody.ToString();
        }
    }
}
