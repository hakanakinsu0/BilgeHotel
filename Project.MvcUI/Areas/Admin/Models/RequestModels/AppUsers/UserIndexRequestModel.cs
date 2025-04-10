using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.AppUsers
{
    /// <summary>
    /// Kullanıcıları listeleme ekranında filtreleme işlemleri için kullanılan modeldir.
    /// Arama, rol seçimi ve durum gibi kriterleri taşır.
    /// </summary>
    public class UserIndexRequestModel
    {
        [Display(Name = "Arama")]
        public string Search { get; set; } // Ad, soyad veya e-posta üzerinden arama

        [Display(Name = "Rol")]
        public string Role { get; set; } // Örneğin: Admin, Member

        [Display(Name = "Durum")]
        public string Status { get; set; } // Aktif, Pasif, Silinmiş gibi metin bazlı durum
    }

}
