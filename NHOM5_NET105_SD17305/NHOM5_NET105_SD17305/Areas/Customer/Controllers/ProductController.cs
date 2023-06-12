using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using NHOM5_NET105_SD17305.Data.IServices;
using NHOM5_NET105_SD17305.Data.Services;
using NHOM5_NET105_SD17305.Views.Models;
using System.Linq;

namespace NHOM5_NET105_SD17305.Views.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;
        private readonly ICombosServices _combosServices;
        private readonly ICombosItemServices _combosItemServices;

        public ProductController(IProductServices productServices,ICategoryServices categoryServices,ICombosServices combosServices,ICombosItemServices combosItemServices)
        {
            _productServices = productServices;
            _categoryServices = categoryServices;
            _combosServices = combosServices;
            _combosItemServices = combosItemServices;
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

            var products = await _productServices.GetAllProductAsync(); // get all product
            products = products.FindAll(c => c.Quantity >= 1);

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
            ViewBag.Categories = selectListItems;
            ViewBag.SelectedCategories = SelectedCategories;
            ViewBag.StrSearch = StrSearch;
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;

            return View(paginatedProducts);
        }
        public async Task<IActionResult> DetailProductAsync(int id)
        {
            var products = await _productServices.GetProductByIdAsync(id);
            return View(products);
        }
        public async Task<IActionResult> ShowListCombosFoodAsync([FromQuery(Name = "page")] int CurrentPage, string? StrSearch, string? orderby, int? minPrice, int? maxPrice)
        {
            int PageSize = 10; // 10 items

            var combos = await _combosServices.GetAllCombosAsync(); // get all product
            combos = combos.FindAll(c => c.Quantity >= 1);
            if (!string.IsNullOrWhiteSpace(StrSearch))
            {

                combos = combos.FindAll(c => c.CombosName.ToLower().Contains(StrSearch.ToLower()));
            }
            if (minPrice != null && minPrice != 0 && maxPrice != null && maxPrice != 0)
            {
                if (minPrice > maxPrice)
                {
                    int? temp = minPrice;
                    minPrice = maxPrice;
                    maxPrice = temp;
                }

                combos = combos.FindAll(p => p.CombosPrice >= minPrice && p.CombosPrice <= maxPrice).ToList();
            }

            if (orderby != null)
            {
                if (orderby == "ASC")
                {
                    combos = combos.OrderBy(c => c.CombosPrice).ToList();
                }
                else
                {
                    combos = combos.OrderByDescending(c => c.CombosPrice).ToList();
                }
            }
            int TotalCount = combos.Count(); // tổng số bài
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
                    minPrice = minPrice,
                    maxPrice = maxPrice,
                    orderby = orderby,
                    StrSearch = StrSearch
                })
            };
            if (TotalCount == 0)
            {
                ViewBag.Value = "No data found";
            }
            else
            {
                ViewBag.Value = TotalCount + " Items found";
            }
            var paginatedProducts = combos.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();

            ViewBag.Paging = Paging;
            ViewBag.StrSearch = StrSearch;
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;

            return View(paginatedProducts);
        }
        public async Task<IActionResult> DetailCombosAsync(int id)
        {
            var combo = await _combosServices.GetCombosByIdAsync(id);
            var comboItems = await _combosItemServices.GetAllCombosItemAsync();
            var resultComboItems = comboItems.FindAll(c => c.CombosId == id);
            var lstIdProductItem = resultComboItems.Select(c => c.ProductId).ToList();
            var products = _productServices.GetAllProductAsync().Result;
            var productInCombos = products.FindAll(c => resultComboItems.Any(p => p.ProductId == c.Id));
            ViewBag.ProductInCombos = productInCombos;
            return View(combo);
        }
    }
}
