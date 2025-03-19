using Project.MvcUI.Models.PureVms.AppUsers.RequestModels;

namespace Project.MvcUI.Models.PageVms.AppUsers
{
    /// <summary>
    /// Şifre sıfırlama sayfası için view model.
    /// Hem forgot password form verilerini (UserForgotPasswordRequestModel) hem de ek UI bilgilerini taşır.
    /// </summary>
    public class ForgotPasswordPageViewModel
    {
        public ForgotPasswordPageViewModel()
        {
            PageTitle = "Şifre Sıfırlama";
            HelpText = "Lütfen e-posta adresinizi giriniz. Şifrenizi sıfırlamak için size bir bağlantı gönderilecektir.";
            ForgotPasswordRequest = new UserForgotPasswordRequestModel();
        }

        /// <summary>
        /// Şifre sıfırlama form verilerini içeren model.
        /// </summary>
        public UserForgotPasswordRequestModel ForgotPasswordRequest { get; set; }

        /// <summary>
        /// Sayfa başlığı.
        /// </summary>
        public string PageTitle { get; set; }

        /// <summary>
        /// Yardım metni veya açıklama.
        /// </summary>
        public string HelpText { get; set; }

        /// <summary>
        /// Ek hata mesajları.
        /// </summary>
        public string? ErrorMessage { get; set; }
    }
}
