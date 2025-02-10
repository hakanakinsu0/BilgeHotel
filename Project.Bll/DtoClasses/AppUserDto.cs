using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.DtoClasses
{
    /// <summary>
    /// Kullanıcı verilerini taşımak için kullanılan DTO.
    /// Sistemdeki kullanıcıları temsil eder.
    /// </summary>
    public class AppUserDto : BaseDto
    {
        public string UserName { get; set; } // Kullanıcı adı
        public string Email { get; set; } // E-posta adresi
        public bool EmailConfirmed { get; set; } // E-posta doğrulandı mı?
        public string PhoneNumber { get; set; } // Telefon numarası
        public bool PhoneNumberConfirmed { get; set; } // Telefon numarası doğrulandı mı?
        public Guid ActivationCode { get; set; } // E-posta doğrulama kodu
    }
}
