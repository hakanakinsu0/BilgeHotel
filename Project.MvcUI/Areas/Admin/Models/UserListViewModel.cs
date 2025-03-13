using System.Collections.Generic;

namespace Project.MvcUI.Areas.Admin.Models
{
    public class UserListViewModel
    {
        public List<UserViewModel> Users { get; set; } = new List<UserViewModel>();
    }
}
