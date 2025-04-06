using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.AppUsers
{
    /// <summary>
    /// Kullanıcı listeleme (Index) ekranındaki filtre parametrelerini taşıyan model.
    /// </summary>
    public class UserIndexRequestModel
    {
        [Display(Name = "Arama")]
        public string Search { get; set; }

        [Display(Name = "Rol")]
        public string Role { get; set; }

        [Display(Name = "Durum")]
        public string Status { get; set; }
    }
}
