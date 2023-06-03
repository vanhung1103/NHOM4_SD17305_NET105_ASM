using Microsoft.AspNetCore.Mvc;

namespace NHOM5_NET105_SD17305.Views.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
