using Project.Entities.Enums;
using System;

namespace Project.Bll.DtoClasses
{
    public class AppUserDto : BaseDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public Guid ActivationCode { get; set; }
        public string NormalizedEmail { get; set; }
        public string SecurityStamp { get; set; }

        // **AppUserProfile Alanları**
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; } // **Uyruğu**
        public Gender Gender { get; set; } // **Cinsiyet**
        public string IdentityNumber { get; set; }
    }
}
