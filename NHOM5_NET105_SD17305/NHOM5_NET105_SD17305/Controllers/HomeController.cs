using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace NHOM5_NET105_SD17305.Views.Controllers
{
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
        [Authorize(Roles = "Admin")]
        public IActionResult Contact()
        {
            return View();
        }

    }
}
