using Microsoft.AspNetCore.Mvc;

namespace NHOM5_NET105_SD17305.Views.Areas.Customer.Controllers
{

    [Area("Customer")]
    public class HomeController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Introduce()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

    }
}
