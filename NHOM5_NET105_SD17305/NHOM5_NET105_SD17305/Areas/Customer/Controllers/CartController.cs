using Microsoft.AspNetCore.Mvc;
using NHOM5_NET105_SD17305.Data.Data;
using NHOM5_NET105_SD17305.Data.IServices;
using NHOM5_NET105_SD17305.Data.Models;
using NHOM5_NET105_SD17305.Data.Services;
using NHOM5_NET105_SD17305.Views.Areas.Customer.Models.ViewModel;
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
        public CartController(FastFoodDbContext dbContext, IcartItemServices icartItemServices, IProductServices productServices, ICombosServices combosServices) { 
            _context = dbContext;
            _cartItemServices = icartItemServices;
            _productServices = productServices;
            _combosServices = combosServices;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<CartItem> cartItems = HttpContext.Session.GetComplexData<List<CartItem>>("Cart") ?? new List<CartItem>();
            List<CartItem1> cartItems1 = HttpContext.Session.GetComplexData<List<CartItem1>>("Cart") ?? new List<CartItem1>();
            var gt = cartItems.Sum(x => x.Quantity * x.Price);
            var gtt = gt + cartItems1.Sum(x => x.CombosQuantity * x.CombosPrice);
            CartViewModel cartViewModel = new CartViewModel()
            {
                CartItems = cartItems,
                CartItems1 = cartItems1,
                GrandTotal = gtt
            };
            return View(cartViewModel);
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

        public async Task<IActionResult> Add(int id)
        {
            var pro = await _productServices.GetProductByIdAsync(id);
            // đọc từ session danh sách sản phẩm trong giỏ hàng
            var products = SissionServices.GetObjFromSession(HttpContext.Session, "Cart");

            if (products.Count == 0)
            {
                products.Add(pro);// nếu cart rỗng thì thêm mảng vào luôn
                                  // đưa lại dữ liệu vào sesion
                 SissionServices.SetObjToSession(HttpContext.Session, products, "Cart");

            }
            else
            {
                if (SissionServices.CheckExistProduct(id, products))
                {
                    var pros = products.Find(p => p.Id == id);
                    pro.Quantity++;
                    SissionServices.SetObjToSession(HttpContext.Session, products, "Cart");


                }
                else
                {
                    products.Add(pro);// nếu cart rỗng thì thêm mảng vào luôn
                                      // đưa lại dữ liệu vào sesion
                    SissionServices.SetObjToSession(HttpContext.Session, products, "Cart");


                }
            }
            //var pro = await _productServices.GetProductByIdAsync(id);
            //if (pro == null)
            //{
            //    CartItem cart1 = new CartItem()
            //    {
            //        ProductId = pro.Id,
            //        ProductName = pro.ProductName,
            //        Quantity = pro.Quantity,
            //        Price = pro.Price,
            //        Image = pro.Image,
            //        CartId = 3,
            //        CombosId = 1
            //    };
            //    _cartItemServices.CreateCartItemAsync(cart1);
            //}
            //else
            //{
            //    pro.Quantity++;
            //}
            
            //List<CartItem> cart = HttpContext.Session.GetComplexData<List<CartItem>>("Cart") ?? new List<CartItem>();
            //CartItem cartItem = cart.Where(p => p.ProductId == id).FirstOrDefault();
            //if (cartItem == null)
            //{

            //    cart.Add(new CartItem(pro)) ;
            //}
            //else
            //{
            //    cartItem.Quantity++;
            //}
            //HttpContext.Session.SetComplexData("Cart", cart);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> AddCombos(int id)
        {
            //if (combo == null)
            //{
            //    CartItem cart1 = new CartItem()
            //    {
            //        ProductId= 2,
            //        ProductName = combo.CombosName,
            //        Quantity = combo.Quantity,
            //        Price = combo.CombosPrice,
            //        Image = combo.Image,
            //        CartId = 3,
            //        CombosId = combo.Id
            //    };
            //    _cartItemServices.CreateCartItemAsync(cart1);
            //}
            //else
            //{
            //    combo.Quantity++;
            //}
            var combo = await _combosServices.GetCombosByIdAsync(id);

            var combos = SessionCombo.GetObjFromSession(HttpContext.Session, "Cart1");

            if (combos.Count == 0)
            {

                combos.Add(combo);// nếu cart rỗng thì thêm mảng vào luôn
                                  // đưa lại dữ liệu vào sesion
                SessionCombo.SetObjToSession(HttpContext.Session, combos, "Cart1");

            }
            else
            {
                if (SessionCombo.CheckExistProduct(id, combos))
                {
                    var cb = combos.Find(p => p.Id == id);
                    cb.Quantity++;
                    SessionCombo.SetObjToSession(HttpContext.Session, combos, "Cart1");


                }
                else
                {
                    combos.Add(combo);// nếu cart rỗng thì thêm mảng vào luôn
                                      // đưa lại dữ liệu vào sesion
                    SessionCombo.SetObjToSession(HttpContext.Session, combos, "Cart1");


                }
            }
            //var pro = await _p
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Decrease(int id)
        {
            var pro = await _context.Products.FindAsync(id);

            var products = SissionServices.GetObjFromSession(HttpContext.Session, "Cart");

            var cartItem = products.Where(p => p.Id == id).FirstOrDefault();
            if (cartItem.Quantity > 1)
            {
                --cartItem.Quantity;
            }
            else
            {
                products.RemoveAll( p => p.Id == id);
            }
            if (products.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                SissionServices.SetObjToSession(HttpContext.Session, products, "Cart");

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
            var pro = await _context.Products.FindAsync(id);

            var products = SissionServices.GetObjFromSession(HttpContext.Session, "Cart");

            products.RemoveAll(p => p.Id == id);

            if (products.Count == 0)
            {
                HttpContext.Session.Remove("Cart");

            }
            else
            {
                SissionServices.SetObjToSession(HttpContext.Session, products, "Cart");

            }
            return RedirectToAction("Index");
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
