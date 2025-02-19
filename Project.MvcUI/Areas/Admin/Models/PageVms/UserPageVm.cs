using Project.MvcUI.Areas.Admin.Models.PureVms.ResponseModels.UserModels;

namespace Project.MvcUI.Areas.Admin.Models.PageVms
{
    public class UserPageVm
    {
        public List<UserResponseModel> Users { get; set; } = new();
        public int TotalUsers { get; set; }
        public int ActiveUsers { get; set; }
        public int BannedUsers { get; set; }
    }
}
