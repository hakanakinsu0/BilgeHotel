using Project.MvcUI.Models.PureVms.AppUsers.ResponseModels;

namespace Project.MvcUI.Models.PageVms.AppUsers
{
    /// <summary>
    /// Kullanıcının profilini görüntülemek için kullanılan PageVM sınıfıdır.
    /// Kullanıcı bilgilerini, sayfa başlığını, yardım metnini ve işlem mesajlarını içerir.
    /// </summary>
    public class UserProfilePageVm
    {
        /// <summary>
        /// Varsayılan sayfa başlığı ve yardım metni tanımlanır.
        /// </summary>
        public UserProfilePageVm()
        {
            PageTitle = "Profilim";
            HelpText = "Profil bilgilerinizi görüntüleyebilir ve güncelleyebilirsiniz.";
        }

        /// <summary>
        /// Kullanıcının mevcut profil bilgilerini taşıyan response model.
        /// </summary>
        public UserProfileResponseModel UserProfile { get; set; }

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
