using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.DtoClasses
{
    /// <summary>
    /// Kullanıcı ve rol ilişkisini taşımak için kullanılan DTO.
    /// Kullanıcıların hangi rollere sahip olduğunu temsil eder.
    /// </summary>
    public class AppUserRoleDto : BaseDto
    {
        public int UserId { get; set; } // Kullanıcının ID'si
        public int RoleId { get; set; } // Rolün ID'si
        public string UserName { get; set; } // Kullanıcının adı
        public string RoleName { get; set; } // Rolün adı
    }
}
