using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.PureVms.RequestModels.UserModels
{
    public class UserStatusUpdateRequestModel
    {
        [Required]
        public int Id { get; set; } // Güncellenecek kullanıcının ID'si

        [Required]
        public string Status { get; set; } // Aktif, Pasif, Banlı
    }
}
