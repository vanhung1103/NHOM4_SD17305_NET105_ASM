using Microsoft.AspNetCore.Mvc;
using NHOM5_NET105_SD17305.Data.IServices;
using NHOM5_NET105_SD17305.Data.Models;
using NHOM5_NET105_SD17305.Data.Services;
using System.Data;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace NHOM5_NET105_SD17305.Views.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CombosController : Controller
	{
		private readonly ICombosServices _comboService;
		private readonly IProductServices _productService;
		private readonly ICombosItemServices _comboItemService;
		public static int _idCombo;

		public int _idProduct;
		public CombosController(ICombosServices combosServices, IProductServices productServices, ICombosItemServices combosItemServices)
		{
			_comboService = combosServices;
			_productService = productServices;
			_comboItemService = combosItemServices;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
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

			_idCombo = combos.Id;
			return RedirectToAction("DetailCombos", "Combos", new { id = _idCombo, area = "Admin" });
		}

		[HttpGet]
		public async Task<IActionResult> DetailCombos(int id)
		{
			_idCombo = id;
			var DetailCombo = await _comboService.GetCombosByIdAsync(id);
			if (DetailCombo == null)
			{
				// Xử lý khi không tìm thấy Combo với ID tương ứng
				return NotFound();
			}

			List<Product> allProduct = await _productService.GetAllProductAsync();
			ViewBag.allproduct = allProduct;
			List<CombosItem> combosItem = await _comboItemService.GetAllCombosItemAsync();
			List<CombosItem> comboProduct = combosItem.FindAll(c => c.CombosId == id);
			ViewBag.combos = comboProduct;
			var comboItem = await _comboItemService.GetAllCombosItemAsync();
			var comboProduc = comboItem.FindAll(c => c.CombosId == id);
			List<Product> products = await _productService.GetAllProductAsync();
			var productsss = products.Where(c => !comboProduc.Any(b => b.ProductId == c.Id));
			ViewBag.productss = productsss;
			return View(DetailCombo);
		}

		public async Task<ActionResult> AddProductToComboItem(int idSp)
		{
			var check = await _comboItemService.GetAllCombosItemAsync();
			var check2 = check.FirstOrDefault(c => c.CombosId == _idCombo && c.ProductId == idSp);
			if (check2 != null)
			{
				check2.Quantity++;
				await _comboItemService.UpdateCombosItemAsync(check2);
				return RedirectToAction("Index", "Combos", new { area = "Admin" });
			}
			else
			{
				var addProduct = new CombosItem();
				addProduct.Quantity = 1;
				addProduct.CombosId = _idCombo;
				addProduct.ProductId = idSp;
				await _comboItemService.CreateCombosItemAsync(addProduct);
				return RedirectToAction("DetailCombos", "Combos", new { id = _idCombo, area = "Admin" });
			}
		}

		public async Task<ActionResult> DeleteComboidsp(int idsp)
		{
			var combosItem = await _comboItemService.GetAllCombosItemAsync();
			int idsps = combosItem.FirstOrDefault(c => c.CombosId == _idCombo && c.ProductId == idsp).CombosItemId;
			await _comboItemService.DeleteCombosItemAsync(idsps);
			return RedirectToAction("DetailCombos", "Combos", new { id = _idCombo, area = "Admin" });
		}

		[HttpGet]
		public async Task<IActionResult> UpdateCombo(int id) // Mở form, truyền luôn sang form
		{
			var role = await _comboService.GetCombosByIdAsync(id);
			return View(role);
		}
		[HttpPost]
		public async Task<IActionResult> UpdateCombo(Combos r) // Mở form
		{
			if (await _comboService.UpdateCombosAsync(r))
			{
				return RedirectToAction("DetailCombos", "Combos", new { id = _idCombo, area = "Admin" });
			}
			else
			{
				return BadRequest();
			}
		}
		public async Task<ActionResult> Updatequantity(int quantity,int idsp) // Mở form
		{
			var quantitysp = await _productService.GetProductByIdAsync(idsp);
			int slsp = quantitysp.Quantity;
			var updatequantity = await _comboItemService.GetAllCombosItemAsync();
			var a = updatequantity.FirstOrDefault(c=>c.CombosId==_idCombo&&c.ProductId==idsp);
			a.Quantity = quantity;

			if (quantity > slsp)
			{

				return RedirectToAction("DetailCombos", "Combos", new { id = _idCombo, area = "Admin" });
			}
			else
			{
				_comboItemService.UpdateCombosItemAsync(a);
				return RedirectToAction("DetailCombos", "Combos", new { id = _idCombo, area = "Admin" });
			}
		
		}
	}
}
