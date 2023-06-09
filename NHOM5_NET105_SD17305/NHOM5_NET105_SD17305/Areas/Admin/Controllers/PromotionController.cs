using Microsoft.AspNetCore.Mvc;

namespace NHOM5_NET105_SD17305.Views.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PromotionController : Controller
    {
        public IActionResult ShowListPromotion()
        {
            return View();
        }
        public IActionResult ShowListProductForAdd()
        {
            return View();
        }
    }
}
