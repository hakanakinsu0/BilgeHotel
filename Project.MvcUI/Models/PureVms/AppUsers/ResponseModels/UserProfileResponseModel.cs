namespace Project.MvcUI.Models.PureVms.AppUsers.ResponseModels
{
    public class UserProfileResponseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public string IdentityNumber { get; set; } // **TC Kimlik No**
    }
}
