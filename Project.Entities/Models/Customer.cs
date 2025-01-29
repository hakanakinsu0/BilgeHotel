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

        //Foreign Keys
        public int? AppUserId { get; set; } // Müşteri bir AppUser olabilir

        // Relational Properties
        public virtual ICollection<Reservation> Reservations { get; set; } // 1 Customer N Reservation, 1 Reservation 1 Customer
        public virtual CustomerDetail CustomerDetail { get; set; } // 1 Customer 1 CustomerDetail, 1 CustomerDetail 1 Customer
        public virtual AppUser AppUser { get; set; } // 1 Customer 1 AppUser, 1 AppUser 1 Customer
    }
}
