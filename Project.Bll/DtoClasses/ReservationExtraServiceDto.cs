using System;

namespace Project.Bll.DtoClasses
{
    public class ReservationExtraServiceDto : BaseDto
    {
        public int ReservationId { get; set; } // Bağlı olduğu rezervasyon ID'si
        public int ExtraServiceId { get; set; } // Bağlı olduğu ekstra hizmet ID'si
    }
}
