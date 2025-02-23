using Project.Entities.Enums;
using System;

namespace Project.Bll.DtoClasses
{
    public class AppUserProfileDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; } // **Cinsiyet**
        public string Address { get; set; }
        public string Nationality { get; set; } // **Uyruğu**
        public string IdentityNumber { get; set; }
        public int? AppUserId { get; set; }
    }
}
