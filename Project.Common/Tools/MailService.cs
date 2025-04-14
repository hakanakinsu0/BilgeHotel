using System.Net.Mail;
using System.Net;

namespace Project.Common.Tools
{
    /// <summary>
    /// SMTP protokolü kullanarak e-posta gönderme işlemlerini yöneten servis.
    /// </summary>
    public static class MailService
    {
        // Varsayılan gönderici e-posta adresi
        private const string DefaultSender = "testemail3172@gmail.com";

        // Varsayılan gönderici e-posta şifresi (uygulama şifresi)
        private const string DefaultPassword = "rvzhpxwpegickwtq";

        // Gmail SMTP sunucusu
        private const string SmtpHost = "smtp.gmail.com";

        // Gmail SMTP portu (TLS bağlantısı için 587 kullanılır)
        private const int SmtpPort = 587;

        /// <summary>
        /// Belirtilen alıcıya e-posta gönderir.
        /// </summary>
        /// <param name="receiver">E-posta alıcısının adresi.</param>
        /// <param name="password">Gönderici e-posta şifresi (opsiyonel, varsayılan şifre kullanılır).</param>
        /// <param name="body">E-posta içeriği (varsayılan: "Test mesajıdır").</param>
        /// <param name="subject">E-posta konusu (varsayılan: "Email Testi").</param>
        /// <param name="sender">Gönderici e-posta adresi (opsiyonel, varsayılan hesap kullanılır).</param>
        public static async Task SendAsync(
            string receiver,
            string password = DefaultPassword,
            string body = "Test mesajıdır",
            string subject = "Email Testi",
            string sender = DefaultSender)
        {
            try
            {
                // Gönderici ve alıcı e-posta adreslerini MailAddress tipinde tanımla
                MailAddress senderEmail = new(sender);
                MailAddress receiverEmail = new(receiver);

                // SMTP istemcisi tanımlanıyor ve yapılandırılıyor
                using SmtpClient smtp = new()
                {
                    Host = SmtpHost,                           // SMTP sunucu adresi
                    Port = SmtpPort,                           // SMTP portu
                    EnableSsl = true,                          // SSL/TLS şifreleme aktif
                    DeliveryMethod = SmtpDeliveryMethod.Network, // E-posta gönderim yöntemi
                    UseDefaultCredentials = false,             // Varsayılan kimlik bilgileri kullanılmaz
                    Credentials = new NetworkCredential(senderEmail.Address, password) // Kimlik bilgileri
                };

                // Gönderilecek e-posta mesajı oluşturuluyor
                using MailMessage message = new(senderEmail, receiverEmail)
                {
                    Subject = subject,         // Konu
                    Body = body,               // Gövde
                    IsBodyHtml = true          // HTML içeriği aktif
                };

                // Asenkron olarak e-posta gönderilir
                await smtp.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                // Hata durumunda özel açıklamalı Exception fırlatılır
                throw new Exception($"Mail gönderme sırasında hata oluştu: {ex.Message}");
            }
        }
    }
}
