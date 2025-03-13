namespace Project.MvcUI.Areas.Admin.Models.ResponseModels
{
    public class DeleteUserResponseModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
