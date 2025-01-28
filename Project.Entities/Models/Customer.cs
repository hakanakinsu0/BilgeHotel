using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    /// <summary>
    /// Otelin müşterilerini temsil eder.
    /// Rezervasyon ve detay bilgilerle ilişkilidir.
    /// </summary>
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; } // Müşterinin adı.
        public string LastName { get; set; } // Müşterinin soyadı.


        // Relational Properties
        public virtual ICollection<Reservation> Reservations { get; set; } // Müşteri ile ilişkili rezervasyonlar.
        public virtual CustomerDetail CustomerDetail { get; set; } // Müşteri detayları ile bire bir ilişki.
    }
}
