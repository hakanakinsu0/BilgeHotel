using Project.MvcUI.Models.PureVms.AppUsers.RequestModels;

namespace Project.MvcUI.Models.PageVms.AppUsers
{
    /// <summary>
    /// Login sayfası için view model.
    /// Hem login form verilerini (UserLoginRequestModel) hem de sayfaya özgü ek bilgileri taşır.
    /// </summary>
    public class LoginPageViewModel
    {
        /// <summary>
        /// Varsayılan yapıcı metot; sayfa başlığı, yardım metni ve login form verilerini başlatır.
        /// </summary>
        public LoginPageViewModel()
        {
            PageTitle = "Giriş Yap"; // Sayfa başlığı
            HelpText = "Lütfen kullanıcı bilgilerinizi giriniz."; // Yardım metni
            LoginRequest = new UserLoginRequestModel(); // Login form verileri için model oluşturulur
        }

        /// <summary>
        /// Login form verilerini içeren model.
        /// </summary>
        public UserLoginRequestModel LoginRequest { get; set; } // Form verisi

        /// <summary>
        /// Sayfa başlığı.
        /// </summary>
        public string PageTitle { get; set; } // Sayfa başlığı

        /// <summary>
        /// Yardım metni veya açıklama.
        /// </summary>
        public string HelpText { get; set; } // Yardım metni

        /// <summary>
        /// Ek hata mesajları (örneğin, işlem sonucu hatalar).
        /// </summary>
        public string? ErrorMessage { get; set; } // Hata mesajı
    }
}
