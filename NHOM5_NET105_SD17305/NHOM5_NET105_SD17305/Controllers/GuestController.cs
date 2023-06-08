using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data.IServices;
using NHOM5_NET105_SD17305.Data.Models;
using NHOM5_NET105_SD17305.Data.Services;
using System.Linq;

namespace NHOM5_NET105_SD17305.Views.Controllers
{
    public class GuestController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;

        public GuestController(IProductServices productServices,ICategoryServices categoryServices)
        {
            _productServices = productServices;
            _categoryServices = categoryServices;
        }
        public IActionResult Home()
        {
            return View();
        }
        public async Task<IActionResult> ListProductAsync( int?[] selectedSizes)
        { 
            ViewData["SelectedSizes"] = selectedSizes;
            var listCategory = await _categoryServices.GetAllCategoryAsync();
            ViewBag.Category = new SelectList(listCategory, "Id", "CategoryName");
            var products = await _productServices.GetAllProductAsync();
            if (selectedSizes.Length !=0)
            {
                List<Product> filteredProducts = products.Where(p => selectedSizes.Contains(p.Cate_Id)).ToList();
                return View(filteredProducts);
            }
            return View(products);
        }
        public IActionResult ListCombos()
        {
            return View();
        }

    }
}
