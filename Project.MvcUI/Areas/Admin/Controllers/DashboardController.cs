using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project.MvcUI.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        [Area("Admin")]
        [Authorize(Roles = "Admin")] // Sadece Admin erişebilir
        public IActionResult Index()
        {
            return View();
        }
    }
}
