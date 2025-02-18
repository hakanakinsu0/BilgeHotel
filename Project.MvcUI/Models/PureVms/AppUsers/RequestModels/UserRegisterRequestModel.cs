using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.AppUsers.RequestModels
{
    public class UserRegisterRequestModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
