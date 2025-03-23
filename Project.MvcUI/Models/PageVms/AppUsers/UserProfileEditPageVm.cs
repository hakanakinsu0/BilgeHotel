using Project.MvcUI.Models.PureVms.AppUsers.RequestModels;

namespace Project.MvcUI.Models.PageVms.AppUsers
{
    public class UserProfileEditPageVm
    {
        public UserProfileEditPageVm()
        {
            PageTitle = "Profil Güncelleme";
            HelpText = "Profil bilgilerinizi düzenleyebilirsiniz.";
        }

        // Güncelleme form verilerini içeren model.
        public UserProfileUpdateRequestModel UserProfileUpdate { get; set; }

        // Sayfa başlığı, yardım metni ve mesaj alanları.
        public string PageTitle { get; set; }
        public string? HelpText { get; set; }
        public string? ErrorMessage { get; set; }
        public string? SuccessMessage { get; set; }
    }
}
