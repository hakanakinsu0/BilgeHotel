namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.Employees
{
    public class EmployeeListResponseModel
    {
        public List<EmployeeListItemResponseModel> Employees { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
