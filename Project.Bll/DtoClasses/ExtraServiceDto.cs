using System;

namespace Project.Bll.DtoClasses
{
    public class ExtraServiceDto : BaseDto
    {
        public string Name { get; set; } // Hizmet adı (ör. Spa Kullanımı)
        public string Description { get; set; } // Açıklama
        public decimal Price { get; set; } // Fiyat
    }
}
