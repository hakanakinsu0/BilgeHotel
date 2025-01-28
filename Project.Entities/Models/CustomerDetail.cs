using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class CustomerDetail : BaseEntity
    {
        /// <summary>
        /// Müşterilerin detaylı bilgilerini temsil eder.
        /// Customer tablosu ile bire bir ilişkilidir.
        /// </summary>
        public string Address { get; set; } // Müşterinin adresi.
        public string Nationality { get; set; } // Müşterinin vatandaşlık bilgisi.
        public string IdentityNumber { get; set; } // Müşterinin kimlik numarası (TC veya Pasaport).
        public string Email { get; set; } // Müşterinin e-posta adresi.
        public string PhoneNumber { get; set; } // Müşterinin telefon numarası.

        // Foreign Keys
        public int CustomerId { get; set; } // Müşteri ile ilişki için foreign key.

        // Relational Properties
        public virtual Customer Customer { get; set; } // Müşteri ile bire bir ilişki.
    }
}
