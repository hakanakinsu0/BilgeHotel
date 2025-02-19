using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.PureVms.RequestModels.UserModels
{
    public class UserUpdateRequestModel
    {
        [Required]
        public int Id { get; set; } // Güncellenecek kullanıcının ID'si

        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string? Role { get; set; } // Kullanıcının rolü değiştirilecekse

        public bool IsActive { get; set; } // Kullanıcı aktif/pasif durumu
    }
}
