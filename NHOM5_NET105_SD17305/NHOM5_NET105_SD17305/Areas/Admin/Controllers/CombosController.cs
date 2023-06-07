    using Microsoft.AspNetCore.Mvc;
using NHOM5_NET105_SD17305.Data.IServices;
using NHOM5_NET105_SD17305.Data.Models;
using NHOM5_NET105_SD17305.Data.Services;

namespace NHOM5_NET105_SD17305.Views.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CombosController : Controller
    {
        private readonly ICombosServices _comboService;
        private readonly IProductServices _productService;

        public CombosController(ICombosServices combosServices,IProductServices productServices)
        {
            _comboService = combosServices;
            _productService = productServices;
        }
        [HttpGet]
        public  async Task<IActionResult> Index()
        {
            var a = await _comboService.GetAllCombosAsync();
            return View(a);
        }

        [HttpGet]
        public async Task<IActionResult> CreateCombo()
        {
            List<Product> product = await _productService.GetAllProductAsync();
            ViewBag.products = product;
            return View();  
        }

        [HttpPost]

        public async Task<IActionResult> CreateCombo(Combos combos)
        {
            //bool isproduct = productServices.GetAllProducts().Any(c => c.Name == product.Name && c.Supplier == product.Supplier);
            //if (!isproduct)
            //{
            //    return Content("Hoc lai");
            //}

            await _comboService.CreateCombosAsync(combos);
            List<Product> product = await _productService.GetAllProductAsync();
            ViewBag.products = product;


            return RedirectToAction("Index", "Combos", new { area = "Admin" });
        }
    }
}
