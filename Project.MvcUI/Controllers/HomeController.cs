using Microsoft.AspNetCore.Mvc;
using Project.Common.Tools;
using Project.MvcUI.Models;
using System.Diagnostics;

namespace Project.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SendTestMail()
        {
            try
            {
                MailService.Send(
                    receiver: "hakanakinsu.37@gmail.com",
                    body: "Bu bir test e-postasýdýr.",
                    subject: "Test Mail",
                    sender: "testemail3172@gmail.com"
                );

                return Content("E-posta baþarýyla gönderildi!");
            }
            catch (Exception ex)
            {
                return Content($"E-posta gönderme sýrasýnda hata oluþtu: {ex.Message}");
            }
        }
    }
}
