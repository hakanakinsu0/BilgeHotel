using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.AppUsers.RequestModels
{
    public class UserLoginRequestModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
