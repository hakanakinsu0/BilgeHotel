using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    /// <summary>
    /// Rezervasyon ile Ekstra Hizmetler arasındaki çoktan çoğa (N-N) ilişkiyi yöneten Junction Table'dır.
    /// Bu tablo, bir rezervasyonun birden fazla ekstra hizmet alabilmesini, bir ekstra hizmetinde birden fazla rezervasyonda olabilmesini sağlar.
    /// </summary>
    public class ReservationExtraService : BaseEntity
    {
        //Composite Keys
        public int ReservationId { get; set; }  //Hangi rezervasyona ekstra hizmetin eklendiğini belirtir.
        public int ExtraServiceId { get; set; } //Rezervasyona hangi ekstra hizmetin eklendiğini belirtir.

        // Relational Properties
        public virtual Reservation Reservation { get; set; }    // 1 Reservation N ReservationExtraService, 1 ReservationExtraService 1 Reservation
        public virtual ExtraService ExtraService { get; set; }  // 1 ExtraService N ReservationExtraService, 1 ReservationExtraService 1 ExtraService
    }
}
