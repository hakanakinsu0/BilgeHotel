using Project.MvcUI.Models.PureVms.AppUsers.RequestModels;

namespace Project.MvcUI.Models.PageVms.AppUsers
{
    /// <summary>
    /// Kullanıcının profilini güncellemesi için kullanılan PageVM sınıfıdır.
    /// Güncelleme form verilerini, sayfa başlığını, yardım metnini ve işlem mesajlarını içerir.
    /// </summary>
    public class UserProfileEditPageVm
    {
        /// <summary>
        /// Sayfa başlığı ve yardım metni için varsayılan değerler atanır.
        /// </summary>
        public UserProfileEditPageVm()
        {
            PageTitle = "Profil Güncelleme";
            HelpText = "Profil bilgilerinizi düzenleyebilirsiniz.";
        }

        /// <summary>
        /// Kullanıcının profil bilgilerini güncellemek için gerekli form verilerini taşıyan model.
        /// </summary>
        public UserProfileUpdateRequestModel UserProfileUpdate { get; set; }

        /// <summary>
        /// View'da gösterilecek sayfa başlığı.
        /// </summary>
        public string PageTitle { get; set; }

        /// <summary>
        /// Kullanıcıya gösterilecek yardım açıklaması.
        /// </summary>
        public string? HelpText { get; set; }

        /// <summary>
        /// İşlem sırasında oluşabilecek hata mesajı.
        /// </summary>
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// İşlem başarıyla tamamlandığında gösterilecek başarı mesajı.
        /// </summary>
        public string? SuccessMessage { get; set; }
    }
}
