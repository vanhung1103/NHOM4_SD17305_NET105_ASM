using Microsoft.AspNetCore.Mvc;
using NHOM5_NET105_SD17305.Data.Data;
using NHOM5_NET105_SD17305.Data.IServices;
using NHOM5_NET105_SD17305.Data.Models;
using NHOM5_NET105_SD17305.Data.Services;
using NHOM5_NET105_SD17305.Views.Areas.Customer.Models.ViewModel;
using System.Net.WebSockets;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace NHOM5_NET105_SD17305.Views.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        public readonly FastFoodDbContext _context;
        public readonly IcartItemServices _cartItemServices;
        public readonly IProductServices _productServices;
        public readonly ICombosItemServices _combosItemServices;
        public readonly ICombosServices _combosServices;
        private readonly ICartServices _cartServices;

        public CartController(FastFoodDbContext dbContext, IcartItemServices icartItemServices, IProductServices productServices, ICombosServices combosServices,ICartServices cartServices) { 
            _context = dbContext;
            _cartItemServices = icartItemServices;
            _productServices = productServices;
            _combosServices = combosServices;
            _cartServices = cartServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var userId = HttpContext.Session.GetString("UserId") ?? ""; // get userid
            var AllCart = await _cartServices.GetAllCartAsync(); // get cart
            var myCart = AllCart.FirstOrDefault(x => x.UserId == Convert.ToInt32(userId)); // get cart by userid
            var AllCartItems = await _cartItemServices.GetAllCartItemAsync(); // get cartitem
            var myCartItems = AllCartItems.Where(x => x.CartId == myCart.Id); // get cartitem by cartid
            int total = 0;
            foreach (var item in myCartItems)
            {
                total += item.Quantity * item.Price;
            }
            ViewBag.Total = total;
            return View(myCartItems);
        }
        public async Task<IActionResult> Index()
        {
            var cart = await _cartItemServices.GetAllCartItemAsync();
            //List<CartItem> cartItems = HttpContext.Session.GetComplexData<List<CartItem>>("Cart") ?? new List<CartItem>();
            //List<CartItem1> cartItems1 = HttpContext.Session.GetComplexData<List<CartItem1>>("Cart") ?? new List<CartItem1>();
            //var gt = cartItems.Sum(x => x.Quantity * x.Price);
            //var gtt = gt + cartItems1.Sum(x => x.CombosQuantity * x.CombosPrice);
            //CartViewModel cartViewModel = new CartViewModel()
            //{
            //    CartItems = cartItems,
            //    CartItems1 = cartItems1,
            //    GrandTotal = gtt
            //};
            var carts = await _cartItemServices.GetAllCartItemAsync();
            var combos = await _combosServices.GetAllCombosAsync();
            var products = SissionServices.GetObjFromSession(HttpContext.Session, "Cart");
            var combo = SessionCombo.GetObjFromSession(HttpContext.Session, "Cart1");
            ViewBag.Combo = combo;

            return View(products);
            //var comid = cart.FindAll();
        }

        [HttpPost]
        public async Task<IActionResult> Add(int id, int quantity)
        {
            if (quantity!=0||quantity!=null)
            {
                var product = await _productServices.GetProductByIdAsync(id); // get product    
                var userId = HttpContext.Session.GetString("UserId") ?? ""; // get userid
                var AllCart = await _cartServices.GetAllCartAsync(); // get cart
                var myCart = AllCart.FirstOrDefault(x => x.UserId == Convert.ToInt32(userId)); // get cart by userid
                var AllCartItems = await _cartItemServices.GetAllCartItemAsync(); // get cartitem
                var myCartItems = AllCartItems.Where(x => x.CartId == myCart.Id); // get cartitem by cartid
                var myCartItem = myCartItems.FirstOrDefault(x => x.ProductId == product.Id); // get cartitem by productid
                if (myCartItem == null)
                {
                    var cart = new CartItem()
                    {
                        CartId = myCart.Id,
                        ProductId = product.Id,
                        Quantity = quantity,
                        Price = product.Price,
                        Image = product.Image,
                        ProductName = product.ProductName
                    };
                    await _cartItemServices.CreateCartItemAsync(cart);
                }
                else
                {
                    var cartupdate = await _cartItemServices.GetCartItemByIdAsync(myCartItem.Id);
                    cartupdate.Quantity += quantity;
                    await _cartItemServices.UpdateCartItemAsync(myCartItem);
                }
            }
            return RedirectToAction("GetAll");
        }
        public async Task<IActionResult> AddCombos(int id, int quantity)
        {
            if (quantity != 0 || quantity != null)
            {
                var combo = await _combosServices.GetCombosByIdAsync(id); // get combo   
                var userId = HttpContext.Session.GetString("UserId") ?? ""; // get userid
                var AllCart = await _cartServices.GetAllCartAsync(); // get cart
                var myCart = AllCart.FirstOrDefault(x => x.UserId == Convert.ToInt32(userId)); // get cart by userid
                var AllCartItems = await _cartItemServices.GetAllCartItemAsync(); // get cartitem
                var myCartItems = AllCartItems.Where(x => x.CartId == myCart.Id); // get cartitem by cartid
                var myCartItem = myCartItems.FirstOrDefault(x => x.CombosId == combo.Id); // get cartitem by productid
                if (myCartItem == null)
                {
                    var cart = new CartItem()
                    {
                        CartId = myCart.Id,
                        CombosId = combo.Id,
                        Quantity = quantity,
                        Price = combo.CombosPrice,
                        Image = combo.Image,
                        ProductName = combo.CombosName
                    };
                    await _cartItemServices.CreateCartItemAsync(cart);
                }
                else
                {
                    var cartupdate = await _cartItemServices.GetCartItemByIdAsync(myCartItem.Id);
                    cartupdate.Quantity += quantity;
                    await _cartItemServices.UpdateCartItemAsync(myCartItem);
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> minus(int id)
        {

            var product = await _productServices.GetProductByIdAsync(id); // get product    
            var combos = await _combosItemServices.GetCombosItemByIdAsync(id); // get product    
            var userId = HttpContext.Session.GetString("UserId") ?? ""; // get userid
            var AllCart = await _cartServices.GetAllCartAsync(); // get cart
            var myCart = AllCart.FirstOrDefault(x => x.UserId == Convert.ToInt32(userId)); // get cart by userid
            var AllCartItems = await _cartItemServices.GetAllCartItemAsync(); // get cartitem
            var myCartItems = AllCartItems.Where(x => x.CartId == myCart.Id); // get cartitem by cartid
            var myCartItem = myCartItems.FirstOrDefault(x => x.ProductId == product.Id || x.ProductId == combos.CombosId); // get cartitem by productid
            if (myCartItem.Quantity > 1)
            {
                --myCartItem.Quantity;
                _cartItemServices.UpdateCartItemAsync(myCartItem);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> plus(int id)
        {
            
            var product = await _productServices.GetProductByIdAsync(id); // get product    
            var combos = await _combosItemServices.GetCombosItemByIdAsync(id); // get product    
            var userId = HttpContext.Session.GetString("UserId") ?? ""; // get userid
            var AllCart = await _cartServices.GetAllCartAsync(); // get cart
            var myCart = AllCart.FirstOrDefault(x => x.UserId == Convert.ToInt32(userId)); // get cart by userid
            var AllCartItems = await _cartItemServices.GetAllCartItemAsync(); // get cartitem
            var myCartItems = AllCartItems.Where(x => x.CartId == myCart.Id); // get cartitem by cartid
            var myCartItem = myCartItems.FirstOrDefault(x => x.ProductId == product.Id||  x.ProductId == combos.CombosId); // get cartitem by productid
            if (product.Quantity > 1||combos.Quantity>1)
            {
                myCartItem.Quantity++;
                _cartItemServices.UpdateCartItemAsync(myCartItem);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DecreaseCombo(int id)
        {
            var pro = await _context.Combos.FindAsync(id);

            var combos = SessionCombo.GetObjFromSession(HttpContext.Session, "Cart1");

            var cartItem = combos.Where(p => p.Id == id).FirstOrDefault();
            if (cartItem.Quantity > 1)
            {
                --cartItem.Quantity;
            }
            else
            {
                combos.RemoveAll(p => p.Id == id);
            }
            if (combos.Count == 0)
            {
                HttpContext.Session.Remove("Cart1");
            }
            else
            {
                SessionCombo.SetObjToSession(HttpContext.Session, combos, "Cart1");

            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Remove(int id)
        {
            var vc = await _cartItemServices.DeleteCartItemAsync(id);
            return RedirectToAction("GetAll");
        }
        public async Task<IActionResult> RemoveCombo(int id)
        {
            var pro = await _context.Combos.FindAsync(id);

            var combos = SessionCombo.GetObjFromSession(HttpContext.Session, "Cart1");

            combos.RemoveAll(p => p.Id == id);

            if (combos.Count == 0)
            {
                HttpContext.Session.Remove("Cart1");

            }
            else
            {
                SessionCombo.SetObjToSession(HttpContext.Session, combos, "Cart1");

            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Clear()
        {
                HttpContext.Session.Remove("Cart");
                HttpContext.Session.Remove("Cart1");
                return RedirectToAction("Index");

        }

        public IActionResult UpadateCart(int id, int quantity)
        {

            var products = SissionServices.GetObjFromSession(HttpContext.Session, "Cart");


            var cartItem = products.Where(p => p.Id == id).FirstOrDefault();

            if (cartItem != null)
            {

                cartItem.Quantity = quantity;
            }
            SissionServices.SetObjToSession(HttpContext.Session, products, "Cart");

            return RedirectToAction("Index");

        }
     
    }
}
