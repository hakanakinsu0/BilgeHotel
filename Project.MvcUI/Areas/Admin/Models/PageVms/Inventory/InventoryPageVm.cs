using Project.MvcUI.Areas.Admin.Models.ResponseModels.Inventory;

namespace Project.MvcUI.Areas.Admin.Models.PageVms.Inventory
{
    /// <summary>
    /// Inventory listesi sayfasında kullanılacak view model.
    /// </summary>
    public class InventoryPageVm
    {
        public List<InventoryItemListItemResponseModel> InventoryItems { get; set; } = new();
        public string PageTitle { get; set; } = "💻 Donanım Envanteri";
        public string? HelpText { get; set; } = "Otele ait donanımların listesi aşağıdadır.";
    }
}
