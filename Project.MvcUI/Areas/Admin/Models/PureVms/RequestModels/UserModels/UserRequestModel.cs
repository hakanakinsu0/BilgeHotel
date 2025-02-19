using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.PureVms.RequestModels.UserModels
{
    public class UserRequestModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; } // Admin, Resepsiyonist, Müşteri

        [Required]
        public string Password { get; set; }

        public bool IsActive { get; set; } = true; // Kullanıcı aktif mi?
    }
}
