using Project.Bll.DtoClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.DtoClasses
{
    /// <summary>
    /// Müşteri detay verilerini taşımak için kullanılan DTO.
    /// Otelin müşterilerine ait ek bilgileri temsil eder.
    /// </summary>
    public class CustomerDetailDto : BaseDto
    {
        public string Address { get; set; } // Müşterinin adresi
        public string Nationality { get; set; } // Müşterinin vatandaşlık bilgisi
        public string IdentityNumber { get; set; } // Müşterinin kimlik numarası (TC veya Pasaport)
        public string Email { get; set; } // Müşterinin e-posta adresi
        public string PhoneNumber { get; set; } // Müşterinin telefon numarası
        public int CustomerId { get; set; } // Müşteri ile ilişki için foreign key
    }
}

