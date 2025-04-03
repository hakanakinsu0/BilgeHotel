using System;

namespace Project.Bll.DtoClasses
{
    /// <summary>
    /// Otelde sunulan ekstra hizmetlerin temel bilgilerini taşıyan Data Transfer Object (DTO) sınıfıdır.
    /// Bu DTO, ekstra hizmetin adı ve fiyatı gibi bilgileri içerir.
    /// </summary>
    public class ExtraServiceDto : BaseDto
    {
        public string Name { get; set; }    // Ekstra hizmetin adı (örneğin, "Spa Kullanımı")
        public decimal Price { get; set; }  // Ekstra hizmetin fiyatı
    }
}
