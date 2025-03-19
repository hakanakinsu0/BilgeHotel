using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity.Data;
using Project.MvcUI.Models.PureVms.AppUsers.RequestModels;

namespace Project.MvcUI.Models.PageVms.AppUsers
{
    /// <summary>
    /// Kayıt sayfası için view model. 
    /// Hem kayıt form verilerini (UserRegisterRequestModel) hem de sayfaya özgü ek bilgileri taşır.
    /// </summary>
    public class RegisterPageViewModel
    {
        public RegisterPageViewModel()
        {
            PageTitle = "Kayıt Ol";
            HelpText = "Lütfen kayıt formunu eksiksiz doldurunuz.";
            RegisterRequest = new UserRegisterRequestModel();
        }

        /// <summary>
        /// Kayıt form verilerini içeren model.
        /// </summary>
        public UserRegisterRequestModel RegisterRequest { get; set; } // Form verisi

        /// <summary>
        /// Sayfa başlığı.
        /// </summary>
        public string PageTitle { get; set; } // Sayfa başlığı

        /// <summary>
        /// Yardım metni veya açıklama.
        /// </summary>
        public string HelpText { get; set; } // Yardım metni

        /// <summary>
        /// Ek hata mesajları (örn. işlem sonucu hatalar).
        /// </summary>
        public string? ErrorMessage { get; set; } // Hata mesajı
    }
}
