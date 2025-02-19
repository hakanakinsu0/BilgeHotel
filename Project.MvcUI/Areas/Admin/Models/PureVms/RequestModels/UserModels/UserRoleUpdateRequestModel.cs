using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.PureVms.RequestModels.UserModels
{
    public class UserRoleUpdateRequestModel
    {
        [Required]
        public int Id { get; set; } // Güncellenecek kullanıcının ID'si

        [Required]
        public string NewRole { get; set; } // Yeni atanacak rol (Admin, Resepsiyonist, Müşteri)
    }
}
