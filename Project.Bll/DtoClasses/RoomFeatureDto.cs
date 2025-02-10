using Project.Bll.DtoClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.DtoClasses
{
    /// <summary>
    /// Oda ve özellikler arasındaki ilişkiyi taşımak için kullanılan DTO.
    /// Bir odanın hangi özelliklere sahip olduğunu temsil eder.
    /// </summary>
    public class RoomFeatureDto : BaseDto
    {
        public bool IsActive { get; set; } // Özelliğin aktif olup olmadığını belirten alan
        public int RoomId { get; set; } // İlişkili oda ID'si
        public int FeatureId { get; set; } // İlişkili özellik ID'si
        public string RoomNumber { get; set; } // Odanın numarası
        public string FeatureName { get; set; } // Özellik adı (ör. "Klima", "Balkon")
    }
}