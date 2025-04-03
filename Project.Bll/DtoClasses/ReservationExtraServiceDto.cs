using System;

namespace Project.Bll.DtoClasses
{
    /// <summary>
    /// Rezervasyonlara eklenen ekstra hizmetlerin temel bilgilerini taşıyan DTO sınıfıdır.
    /// Bu sınıf, bir rezervasyona bağlı ekstra hizmetin ID bilgilerini içerir.
    /// </summary>
    public class ReservationExtraServiceDto : BaseDto
    {
        public int ReservationId { get; set; }  // Bağlı olduğu rezervasyon ID'si
        public int ExtraServiceId { get; set; } // Bağlı olduğu ekstra hizmet ID'si
    }
}
