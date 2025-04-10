using Project.Entities.Enums;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Kullanıcı düzenleme işlemleri için kullanılan modeldir.
/// Hem kullanıcı hesabı bilgileri hem de kullanıcı profili bilgilerini içerir.
/// Admin tarafından kullanıcı bilgilerini düzenlemek için kullanılır.
/// </summary>
public class UpdateUserRequestModel
{
    [Display(Name = "Kullanıcı ID")]
    public int Id { get; set; }

    // Kullanıcı adı ve soyadı
    [Display(Name = "Ad")]
    [Required(ErrorMessage = "{0} gereklidir.")]
    public string FirstName { get; set; }

    [Display(Name = "Soyad")]
    [Required(ErrorMessage = "{0} gereklidir.")]
    public string LastName { get; set; }

    // İletişim bilgileri
    [Display(Name = "E-posta Adresi")]
    [Required(ErrorMessage = "{0} gereklidir.")]
    [EmailAddress(ErrorMessage = "Geçerli bir {0} giriniz.")]
    public string Email { get; set; }

    [Display(Name = "Telefon Numarası")]
    [Required(ErrorMessage = "{0} gereklidir.")]
    [RegularExpression(@"^05\d{9}$", ErrorMessage = "Telefon numarası 05 ile başlamalı ve 11 haneli olmalıdır.")]
    public string PhoneNumber { get; set; }

    // Profil bilgileri
    [Display(Name = "Adres")]
    public string Address { get; set; }

    [Display(Name = "Uyruğu")]
    public string Nationality { get; set; }

    [Display(Name = "Kimlik Numarası")]
    [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "T.C. Kimlik Numarası 11 rakamdan oluşmalıdır.")]
    public string IdentityNumber { get; set; }

    [Display(Name = "Cinsiyet")]
    [Required(ErrorMessage = "{0} seçilmelidir.")]
    public Gender Gender { get; set; }

    // Yetkilendirme
    [Display(Name = "Kullanıcı Rolü")]
    [Required(ErrorMessage = "{0} seçilmelidir.")]
    public string Role { get; set; }

    // Aktiflik durumu
    [Display(Name = "Aktif/Pasif Durum")]
    public bool IsActive { get; set; }
}
