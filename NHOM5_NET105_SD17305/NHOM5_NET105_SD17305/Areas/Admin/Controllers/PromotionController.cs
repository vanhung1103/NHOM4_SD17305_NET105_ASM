using Microsoft.AspNetCore.Mvc;
using NHOM5_NET105_SD17305.Data.IServices;
using NHOM5_NET105_SD17305.Data.Services;

namespace NHOM5_NET105_SD17305.Views.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PromotionController : Controller
    {
        private readonly IPromotionServices _promotionServices;
        private readonly IPromotionItemServices _promotionItemServices;

        public PromotionController(IPromotionServices promotionServices,IPromotionItemServices promotionItemServices)
        {
            _promotionServices = promotionServices;
            _promotionItemServices = promotionItemServices;
        }
        public async Task<IActionResult> ShowListPromotionAsync()
        {
            var promotions = await _promotionServices.GetAllPromotionAsync();
            return View(promotions);
        }
        public IActionResult ShowListProductForAdd()
        {
            return View();
        }
    }
}
