using Project.Entities.Enums;

namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.Inventory
{
    /// <summary>
    /// Inventory listesi sayfasında her bir satırı temsil eden model.
    /// </summary>
    public class InventoryItemListItemResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string EmployeeFullName { get; set; }
        public DataStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string EmployeePosition { get; set; }

    }
}