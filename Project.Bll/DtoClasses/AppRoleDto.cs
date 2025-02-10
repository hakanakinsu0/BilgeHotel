using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.DtoClasses
{
    /// <summary>
    /// Rol verilerini taşımak için kullanılan DTO.
    /// Sistemdeki rolleri temsil eder.
    /// </summary>
    public class AppRoleDto : BaseDto
    {
        public string Name { get; set; } // Rol adı
        public string NormalizedName { get; set; } // Normalize edilmiş rol adı
    }
}
