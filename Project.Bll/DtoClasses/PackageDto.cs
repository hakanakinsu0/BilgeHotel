using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.DtoClasses
{
    /// <summary>
    /// Otelde sunulan paket verilerini taşımak için kullanılan DTO.
    /// Örnek: Tam Pansiyon, Her Şey Dahil vb.
    /// </summary>
    public class PackageDto : BaseDto
    {
        public string Name { get; set; } // Paket adı (ör. "Tam Pansiyon")
    }
}
