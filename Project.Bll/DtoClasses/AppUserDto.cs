using Project.Entities.Enums;
using System;

namespace Project.Bll.DtoClasses
{
    /// <summary>
    /// Kullanıcı kimlik ve profil bilgilerini taşıyan DTO sınıfıdır.
    /// Bu sınıf; temel kullanıcı bilgilerini (UserName, Email, PhoneNumber, ActivationCode, SecurityStamp, Role, vb.) 
    /// ve kullanıcıya ait profil detaylarını (FirstName, LastName, Address, Nationality, Gender, IdentityNumber) içerir.
    /// </summary>
    public class AppUserDto : BaseDto
    {
        public string UserName { get; set; }             // Kullanıcının kullanıcı adı
        public string Email { get; set; }                // Kullanıcının e-posta adresi
        public bool EmailConfirmed { get; set; }         // E-posta adresinin onaylanıp onaylanmadığı
        public string PhoneNumber { get; set; }          // Kullanıcının telefon numarası
        public bool PhoneNumberConfirmed { get; set; }   // Telefon numarasının onaylanıp onaylanmadığı
        public Guid ActivationCode { get; set; }         // Kullanıcının aktivasyon kodu (GUID)
        public string NormalizedEmail { get; set; }      // Normalleştirilmiş e-posta adresi
        public string SecurityStamp { get; set; }        // Güvenlik damgası (Identity işlemleri için)
        public string Role { get; set; }                 // Kullanıcının rolü (örneğin, Admin veya Member)
        public string FirstName { get; set; }            // Kullanıcının adı
        public string LastName { get; set; }             // Kullanıcının soyadı
        public string Address { get; set; }              // Kullanıcının adresi
        public string Nationality { get; set; }          // Kullanıcının uyruğu
        public Gender Gender { get; set; }               // Kullanıcının cinsiyeti
        public string IdentityNumber { get; set; }       // Kullanıcının kimlik (TC kimlik veya pasaport) numarası
    }
}
