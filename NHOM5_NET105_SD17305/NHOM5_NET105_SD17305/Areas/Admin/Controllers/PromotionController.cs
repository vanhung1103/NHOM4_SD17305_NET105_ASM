using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NHOM5_NET105_SD17305.Data.IServices;
using NHOM5_NET105_SD17305.Data.Models;
using NHOM5_NET105_SD17305.Data.Services;

namespace NHOM5_NET105_SD17305.Views.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PromotionController : Controller
    {
        public INotyfService _notyfService { get; }
        private readonly IProductServices _productServices;
        private readonly IPromotionServices _promotionServices;
        private readonly IPromotionItemServices _promotionItemServices;
        public static  int _combosId;

        public PromotionController(IPromotionServices promotionServices,IPromotionItemServices promotionItemServices,IProductServices productServices, INotyfService notyfService)
        {
            _notyfService = notyfService;
            _productServices = productServices;
            _promotionServices = promotionServices;
            _promotionItemServices = promotionItemServices;

        }
        public async Task<IActionResult> ShowListPromotionAsync()
        {
            var promotions = await _promotionServices.GetAllPromotionAsync();
            return View(promotions);
        }
        //  1 list để add sp
        //  1 list show ds items trong mgg
        public async Task<IActionResult> ShowListProductToAddAsync(int id) // list sp chưa được add
        {
            _combosId = id;
            var products = await _productServices.GetAllProductAsync(); // get products
            var promotionItems = await _promotionItemServices.GetAllPromotionItemAsync(); // get productitems
            var promotionItemsSeleted = promotionItems.FindAll(c => c.PromotionId == id); // list productitems in promotion
            var productotNotInPromotion = products.Where(c => !promotionItemsSeleted.Any(x => x.ProductId == c.Id)).ToList(); // list product not in promotion
            return View(productotNotInPromotion);
        }
        public async Task<IActionResult> ShowListPromotionItemsAsync(int id) // ShowList items trong mgg
        {
            _combosId = id;
            var products = await _productServices.GetAllProductAsync(); // get products
            var promotionItems = await _promotionItemServices.GetAllPromotionItemAsync(); // get all productitems
            var itemsInPromotionSelected = promotionItems.Where(c=>c.PromotionId==id).ToList(); // get all productitems in promotion
            var itemProducts = products.Where(c=> itemsInPromotionSelected.Any(x=>x.ProductId==c.Id)).ToList(); // get all products in promotion
            return View(itemProducts);
        }
        public async Task<IActionResult> AddProductItemAsync(int idsp)
        {
            var products = await _productServices.GetAllProductAsync(); // get products
            var productSelected = products.Find(c => c.Id == idsp); // get product selected
            if (productSelected!=null)
            {
                var promotionItem = new PromotionItem()
                {
                    ProductId = productSelected.Id,
                    PromotionId = _combosId,
                };
                var check = await _promotionItemServices.CreatePromotionItemAsync(promotionItem);
                if (check)
                {
                    _notyfService.Success("Success");
                    return RedirectToAction("ShowListProductToAdd", "Promotion", new { id = _combosId });
                }
            }
            _notyfService.Error("Failed");
            return RedirectToAction("ShowListProductToAdd", "Promotion", new { id = _combosId });

        }
        public async Task<IActionResult> RemoveProductItemAsync(int idsp)
        {

            var products = await _productServices.GetAllProductAsync(); // get products
            var productSelected = products.FirstOrDefault(c => c.Id == idsp); // get product selected
            if (productSelected != null)
            {
                var promotionItem = await _promotionItemServices.GetAllPromotionItemAsync();
                var promotionItemSelected = promotionItem.FirstOrDefault(c => c.ProductId == productSelected.Id && c.PromotionId == _combosId).Id;
                if (await _promotionItemServices.DeletePromotionItemAsync(promotionItemSelected))
                {
                    _notyfService.Success("Success");
                    return RedirectToAction("ShowListPromotionItems", "Promotion", new { id = _combosId });
                }
            }
            _notyfService.Error("Failed");
            return RedirectToAction("ShowListPromotionItems", "Promotion", new { id = _combosId });
        }
        public IActionResult CreatePromotion()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePromotionAsync(Promotion promotion)
        {
            if (promotion.Create_Date<=DateTime.Now)
            {
                _notyfService.Warning("Date must be greater than today");
                return View();
            }
            if (promotion.Create_Date>=promotion.End_Date)
            {
                _notyfService.Warning("End date must be greater than start date");
                return View();
            }
          var create =  await _promotionServices.CreatePromotionAsync(promotion);
            if (create)
            {
                _notyfService.Success("Success");
                return RedirectToAction("ShowListPromotion");
            }
            _notyfService.Error("Failed");
            return RedirectToAction("ShowListPromotion");
        }

        public async Task<IActionResult> EditPromotionAsync(int id)
        {
            var promotion = await _promotionServices.GetPromotionByIdAsync(id);
            return View(promotion);
        }
        [HttpPost]
        public async Task<IActionResult> EditPromotionAsync(Promotion promotion)
        {
            if (promotion.Create_Date <= DateTime.Now)
            {
                _notyfService.Warning("Date must be greater than today");
                return View();
            }
            if (promotion.Create_Date >= promotion.End_Date)
            {
                _notyfService.Warning("End date must be greater than start date");
                return View();
            }
            var update = await _promotionServices.UpdatePromotionAsync(promotion);
            if (update)
            {
                _notyfService.Success("Success");
                return RedirectToAction("ShowListPromotion");
            }
            _notyfService.Error("Failed");
            return RedirectToAction("ShowListPromotion");
        }

        public async Task<IActionResult> RemovePromotionAsync(int id)
        {
            try
            {
                var promotion = await _promotionServices.DeletePromotionAsync(id);
                _notyfService.Success("Success");
                return RedirectToAction("ShowListPromotion");
            }
            catch (Exception)
            {
                _notyfService.Error("Failed");
                return RedirectToAction("ShowListPromotion");
            }
            
        }

    }
}