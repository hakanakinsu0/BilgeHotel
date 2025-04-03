using Project.Bll.DtoClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.DtoClasses
{
    /// <summary>
    /// Oda türü verilerini taşımak için kullanılan DTO.
    /// Oteldeki odaların türlerini temsil eder.
    /// </summary>
    public class RoomTypeDto : BaseDto
    {
        public string Name { get; set; }        // Oda türünün adı (ör. "Tek Kişilik", "Çift Kişilik")
        public string Description { get; set; } // Oda türünün açıklaması (opsiyonel)
    }
}
