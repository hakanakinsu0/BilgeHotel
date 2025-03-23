using Project.MvcUI.Models.PureVms.AppUsers.ResponseModels;

namespace Project.MvcUI.Models.PageVms.AppUsers
{
    public class UserProfilePageVm
    {
        public UserProfilePageVm()
        {
            PageTitle = "Profilim";
            HelpText = "Profil bilgilerinizi görüntüleyebilir ve güncelleyebilirsiniz.";
        }

        public UserProfileResponseModel UserProfile { get; set; }
        public string PageTitle { get; set; }
        public string? HelpText { get; set; }
        public string? ErrorMessage { get; set; }
        public string? SuccessMessage { get; set; }
    }
}
