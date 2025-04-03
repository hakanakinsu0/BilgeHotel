using Project.Entities.Enums;
using System;

namespace Project.Bll.DtoClasses
{
    /// <summary>
    /// Kullanıcının profil bilgilerini taşıyan DTO sınıfıdır.
    /// Bu sınıf, kullanıcının ad, soyad, cinsiyet, adres, uyruğu, kimlik numarası ve ilgili AppUser ID'sini içerir.
    /// </summary>
    public class AppUserProfileDto : BaseDto
    {
        public string FirstName { get; set; }       // Kullanıcının adı
        public string LastName { get; set; }        // Kullanıcının soyadı
        public Gender Gender { get; set; }          // Kullanıcının cinsiyeti
        public string Address { get; set; }         // Kullanıcının adresi
        public string Nationality { get; set; }     // Kullanıcının uyruğu
        public string IdentityNumber { get; set; }  // Kullanıcının kimlik veya pasaport numarası
        public int? AppUserId { get; set; }         // İlgili AppUser ID'si (varsa)
    }
}
