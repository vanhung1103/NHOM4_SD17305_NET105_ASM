using Microsoft.AspNetCore.Mvc;
using NHOM5_NET105_SD17305.Data.Data;
using NHOM5_NET105_SD17305.Data.IServices;
using NHOM5_NET105_SD17305.Data.Models;
using NHOM5_NET105_SD17305.Views.Areas.Admin.Models.ViewModel;

namespace NHOM5_NET105_SD17305.Views.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CartController : Controller
    {
        public readonly FastFoodDbContext _context;
        public readonly IcartItemServices _cartItemServices;
        public readonly IProductServices _productServices;
        public CartController(FastFoodDbContext dbContext, IProductServices productServices, IcartItemServices cartItemServices)
        {
            _context = dbContext;
            _productServices = productServices;
            _cartItemServices = cartItemServices;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<CartItem> cartItems = HttpContext.Session.GetComplexData<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartViewModel cartViewModel = new CartViewModel()
            {
                CartItems = cartItems,
                GrandTotal = cartItems.Sum(x => x.Quantity * x.Price)
            };
            return View(cartViewModel);
        }
     
        public async Task<IActionResult> Add(int id)
        {
            var pro = await _context.Products.FindAsync(id);
            
            List<CartItem> cart = HttpContext.Session.GetComplexData<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartItem cartItem = cart.Where(p => p.ProductId == id).FirstOrDefault();
            if (cartItem == null)
            {
                cart.Add(new CartItem(pro)) ;
            }
            else
            {
                cartItem.Quantity++;
            }
            HttpContext.Session.SetComplexData("Cart", cart);
            return RedirectToAction("GetAll");
        }
        public async Task<IActionResult> Decrease(int id)
        {
            var pro = await _context.Products.FindAsync(id);

            List<CartItem> cart = HttpContext.Session.GetComplexData<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartItem cartItem = cart.Where(p => p.ProductId == id).FirstOrDefault();
            if (cartItem.Quantity > 1)
            {
                --cartItem.Quantity;
            }
            else
            {
                cart.RemoveAll( p => p.ProductId == id);
            }
            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetComplexData("Cart", cart);
            }
            return RedirectToAction("GetAll");
        }
        public async Task<IActionResult> Remove(int id)
        {
            var pro = await _context.Products.FindAsync(id);

            List<CartItem> cart = HttpContext.Session.GetComplexData<List<CartItem>>("Cart") ?? new List<CartItem>();
            cart.RemoveAll(p => p.ProductId == id);

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");

            }
            else
            {
                HttpContext.Session.SetComplexData("Cart", cart);
            }
            return RedirectToAction("GetAll");
        }
        public async Task<IActionResult> Clear()
        {
                HttpContext.Session.Remove("Cart");
            return RedirectToAction("GetAll");

        }
    }
}
