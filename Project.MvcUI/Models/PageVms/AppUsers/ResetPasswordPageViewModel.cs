using Project.MvcUI.Models.PureVms.AppUsers.RequestModels;

namespace Project.MvcUI.Models.PageVms.AppUsers
{
    /// <summary>
    /// Şifre sıfırlama sayfası için view model.
    /// Hem şifre sıfırlama form verilerini (UserResetPasswordRequestModel) hem de ek UI bilgilerini taşır.
    /// </summary>
    public class ResetPasswordPageViewModel
    {
        /// <summary>
        /// Varsayılan yapıcı metot; sayfa başlığını, yardım metnini ve form verilerini başlatır.
        /// </summary>
        public ResetPasswordPageViewModel()
        {
            PageTitle = "Şifre Sıfırla"; // Sayfa başlığı
            HelpText = "Lütfen yeni şifrenizi giriniz."; // Yardım metni
            ResetPasswordRequest = new UserResetPasswordRequestModel();
            ErrorMessage = string.Empty; // Hata mesajı varsayılan boş
        }

        /// <summary>
        /// Şifre sıfırlama form verilerini içeren model.
        /// </summary>
        public UserResetPasswordRequestModel ResetPasswordRequest { get; set; }

        /// <summary>
        /// Sayfa başlığı.
        /// </summary>
        public string PageTitle { get; set; }

        /// <summary>
        /// Yardım metni veya açıklama.
        /// </summary>
        public string HelpText { get; set; }

        /// <summary>
        /// Ek hata mesajlarını tutar.
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
