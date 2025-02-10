using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.DtoClasses
{
    /// <summary>
    /// Müşteri verilerini taşımak için kullanılan DTO.
    /// Otelin müşterilerini temsil eder.
    /// </summary>
    public class CustomerDto : BaseDto
    {
        public string FirstName { get; set; } // Müşterinin adı
        public string LastName { get; set; } // Müşterinin soyadı
        public int? AppUserId { get; set; } // Müşteri bir AppUser olabilir
    }
}
