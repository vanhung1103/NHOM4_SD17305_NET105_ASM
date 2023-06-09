using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using NHOM5_NET105_SD17305.Data.IServices;
using NHOM5_NET105_SD17305.Data.Services;
using NHOM5_NET105_SD17305.Views.Models;
using System.Linq;

namespace NHOM5_NET105_SD17305.Views.Controllers
{
    public class ProductController : Controller
    {
        private IProductServices _productServices;
        private ICategoryServices _categoryServices;

        public ProductController(IProductServices productServices,ICategoryServices categoryServices)
        {
            _productServices = productServices;
            _categoryServices = categoryServices;
        }
        
        public async Task<IActionResult> ShowListFastFoodAsync([FromQuery(Name = "page")] int CurrentPage,string? StrSearch, int?[] SelectedCategories, string? orderby,int?minPrice,int?maxPrice)
        {
            int PageSize = 10; // 10 items

            var categories = await _categoryServices.GetAllCategoryAsync(); // get all category
            List<SelectListItem> selectListItems = categories.Select(category => new SelectListItem
            {
                Value = category.Id.ToString(),
                Text = category.CategoryName
            }).ToList();
            ViewBag.Categories = selectListItems;
            ViewBag.SelectedCategories = SelectedCategories;
            ViewBag.StrSearch = StrSearch;
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;
            var products = await _productServices.GetAllProductAsync(); // get all product
            if (!string.IsNullOrWhiteSpace(StrSearch))
            {

                products = products.FindAll(c => c.ProductName.ToLower().Contains(StrSearch.ToLower()));
            }
                if (SelectedCategories.Length > 0)
                {
                    products = products.FindAll(p => SelectedCategories.Contains(p.Cate_Id)).ToList();
                }
                if (minPrice != null && minPrice != 0 && maxPrice != null && maxPrice != 0)
                {
                    if (minPrice > maxPrice)
                    {
                        int? temp = minPrice;
                        minPrice = maxPrice;
                        maxPrice = temp;
                    }
                    
                    products = products.FindAll(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
                }
            
            if (orderby!=null)
            {
                if (orderby=="ASC")
                {
                    products =  products.OrderBy(c=>c.Price).ToList();
                }
                else
                {
                    products = products.OrderByDescending(c => c.Price).ToList();
                }
            }
            int TotalCount = products.Count(); // tổng số bài
            int CountPages = (int)Math.Ceiling((double)TotalCount / PageSize);
            if (CurrentPage > CountPages)
            {
                CurrentPage = CountPages;
            }
            if (CurrentPage < 1)
            {
                CurrentPage = 1;
            }
            var Paging = new Paging()
            {
                CurrentPage = CurrentPage,
                CountPage = CountPages,
                GeneralUrl = (pageNumber) => Url.Action("ShowListFastFood", new
                {
                    page = pageNumber,
                    SelectedCategories = SelectedCategories,
                    minPrice = minPrice,
                    maxPrice = maxPrice,
                    orderby= orderby,
                    StrSearch = StrSearch
                })
            };
            if (TotalCount==0)
            {
                ViewBag.Value = "No data found";
            }
            else
            {
                ViewBag.Value = TotalCount + " Items found";
            }
            var paginatedProducts = products.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
            ViewBag.Paging = Paging;

            return View(paginatedProducts);
        }
        public IActionResult ShowListCombosFood()
        {
            return View();
        }
        public async Task<IActionResult> DetailProductAsync(int id)
        {
            var products = await _productServices.GetProductByIdAsync(id);
            return View(products);
        }

    }
}
