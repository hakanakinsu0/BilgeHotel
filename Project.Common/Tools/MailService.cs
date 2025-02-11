using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common.Tools
{
    /// <summary>
    /// SMTP protokolü kullanarak e-posta gönderme işlemlerini yöneten servis.
    /// </summary>
    public static class MailService
    {
        // Gmail SMTP bilgileri
        private const string DefaultSender = "testemail3172@gmail.com";
        private const string DefaultPassword = "rvzhpxwpegickwtq";
        private const string SmtpHost = "smtp.gmail.com";
        private const int SmtpPort = 587;

        /// <summary>
        /// Belirtilen alıcıya e-posta gönderir.
        /// </summary>
        /// <param name="receiver">E-posta alıcısının adresi.</param>
        /// <param name="password">Gönderici e-posta şifresi (opsiyonel, varsayılan şifre kullanılır).</param>
        /// <param name="body">E-posta içeriği (varsayılan: "Test mesajıdır").</param>
        /// <param name="subject">E-posta konusu (varsayılan: "Email Testi").</param>
        /// <param name="sender">Gönderici e-posta adresi (opsiyonel, varsayılan hesap kullanılır).</param>
        public static void Send(
            string receiver,
            string password = DefaultPassword,
            string body = "Test mesajıdır",
            string subject = "Email Testi",
            string sender = DefaultSender)
        {
            try
            {
                MailAddress senderEmail = new(sender);
                MailAddress receiverEmail = new(receiver);

                using SmtpClient smtp = new()
                {
                    Host = SmtpHost,
                    Port = SmtpPort,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password)
                };

                using MailMessage message = new(senderEmail, receiverEmail)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true // HTML desteği eklenebilir
                };

                smtp.Send(message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Mail gönderme sırasında hata oluştu: {ex.Message}");
            }
        }
    }
}
