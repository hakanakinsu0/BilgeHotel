namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.Employees
{
    public class EmployeeListItemResponseModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Status { get; set; }

        // ✅ Ad ve Soyadı birleştirerek FullName olarak döner
        public string FullName => $"{FirstName} {LastName}";
    }
}
