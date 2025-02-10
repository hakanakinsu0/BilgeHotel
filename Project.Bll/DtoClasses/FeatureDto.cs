using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.DtoClasses
{
    /// <summary>
    /// Oda özelliklerini taşımak için kullanılan DTO.
    /// Oteldeki odalara atanabilecek özellikleri temsil eder.
    /// </summary>
    public class FeatureDto : BaseDto
    {
        public string Name { get; set; } // Özellik adı (ör. "Klima", "Balkon")
        public string Description { get; set; } // Özellik açıklaması (opsiyonel)
    }
}
