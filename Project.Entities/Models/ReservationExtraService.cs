using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class ReservationExtraService : BaseEntity
    {
        public int ReservationId { get; set; }
        public int ExtraServiceId { get; set; }

        public virtual Reservation Reservation { get; set; }
        public virtual ExtraService ExtraService { get; set; }
    }

}
