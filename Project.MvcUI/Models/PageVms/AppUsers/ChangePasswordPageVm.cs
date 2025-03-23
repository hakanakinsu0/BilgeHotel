using Project.MvcUI.Models.PureVms.AppUsers.RequestModels;

namespace Project.MvcUI.Models.PageVms.AppUsers
{
    public class ChangePasswordPageVm
    {
        public ChangePasswordPageVm()
        {
            PageTitle = "Şifre Değiştir";
            HelpText = "Yeni şifrenizi giriniz.";
        }

        public UserChangePasswordRequestModel ChangePasswordRequest { get; set; }
        public string PageTitle { get; set; }
        public string? HelpText { get; set; }
        public string? ErrorMessage { get; set; }
        public string? SuccessMessage { get; set; }
    }
}
