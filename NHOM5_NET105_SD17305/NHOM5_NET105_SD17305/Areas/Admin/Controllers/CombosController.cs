using AspNetCoreHero.ToastNotification.Abstractions;
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
		public INotyfService _notyfService { get; }
		public static int _idCombo;
		public int _idProduct;
		public CombosController(ICombosServices combosServices, IProductServices productServices, ICombosItemServices combosItemServices, INotyfService notyfService)
		{
			_comboService = combosServices;
			_productService = productServices;
			_notyfService = notyfService;
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

		public async Task<IActionResult> CreateCombo(Combos combos, IFormFile imageFile)
		{
			if (imageFile != null && imageFile.Length > 0) // Kiểm tra đường dẫn phù hợp
			{
				// thực hiện việc sao chép ảnh đó vào wwwroot
				// Tạo đường dẫn tới thư mục sao chép (nằm trong root)
				var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot",
					"images", imageFile.FileName); // abc/wwwroot/images/xxx.png
				var stream = new FileStream(path, FileMode.Create); // Tạo 1 filestream để tạo mới
				imageFile.CopyTo(stream); // Copy ảnh vừa dc chọn vào đúng cái stream đó
										  // Gán lại giá trị link ảnh (lúc này đã nằm trong root cho thuộc tính description)
				combos.Image = imageFile.FileName;
				combos.CombosPrice = 0;
				
				await _comboService.CreateCombosAsync(combos);
				_notyfService.Error("Thêm Combo thành công");
				List<Product> product = await _productService.GetAllProductAsync();
				ViewBag.products = product;
				_idCombo = combos.Id;
				return RedirectToAction("DetailCombos", "Combos", new { id = _idCombo, area = "Admin" });
			}
			else
			{
				_notyfService.Error("Thêm Combo không thành công");
				return RedirectToAction("CreateCombo", "Combos", new { area = "Admin" });
			}
		}

		[HttpGet]
		public async Task<IActionResult> DetailCombos(int id)
		{
			//var check = await _comboItemService.GetAllCombosItemAsync();
			//var combos = await _comboService.GetCombosByIdAsync(id);
			//var lstComboItem = check.FindAll(c => c.CombosId == id);
			//var priceCombo = 0;
			//if (lstComboItem.Count != 0)
			//{
			//	foreach (var item in lstComboItem)
			//	{
			//		var productCombos = await _productService.GetProductByIdAsync(item.ProductId);
			//		priceCombo *= productCombos.Price;
			//	}
			//	combos.CombosPrice = priceCombo;
			//	await _comboService.UpdateCombosAsync(combos);

			//}
			var combo = await _comboService.GetCombosByIdAsync(id); //get combo by id để lấy số giá + số lượng
			var gia = combo.CombosPrice;
			var soluong = combo.Quantity;
			var AllComboitem = await _comboItemService.GetAllCombosItemAsync(); //get all comboitem để lấy id sản phẩm
			var lstComboItem = AllComboitem.FindAll(c => c.CombosId == id); //lấy ra list comboitem có id combo tương ứng
			var priceCombo = 0;
			if (lstComboItem.Count != 0)
			{
				foreach (var item in lstComboItem)
				{
					var productCombos = await _productService.GetProductByIdAsync(item.ProductId);
					priceCombo += productCombos.Price;
				}
				combo.CombosPrice = priceCombo;
				await _comboService.UpdateCombosAsync(combo);
			}

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

			_idCombo = id;

			return View(DetailCombo);
		}

		public async Task<ActionResult> AddProductToComboItem(int idSp)
		{
			var check = await _comboItemService.GetAllCombosItemAsync();
			var check2 = check.FirstOrDefault(c => c.CombosId == _idCombo && c.ProductId == idSp);
			var combos = await _comboService.GetCombosByIdAsync(_idCombo);
			var product = await _productService.GetProductByIdAsync(idSp);
			var lstComboItem = check.FindAll(c => c.CombosId == _idCombo);
			var priceCombo = 0;
			foreach (var item in lstComboItem)
			{
				var productCombos = await _productService.GetProductByIdAsync(item.ProductId);
				priceCombo += productCombos.Price;
			}
			combos.CombosPrice = priceCombo;
			await _comboService.UpdateCombosAsync(combos);
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
				var productUpdate = await _productService.GetProductByIdAsync(idSp);
				productUpdate.Quantity -= 1;
				await _productService.UpdateProductAsync(productUpdate);
				return RedirectToAction("DetailCombos", "Combos", new { id = _idCombo, area = "Admin" });
			}
		}

		public async Task<ActionResult> DeleteComboidsp(int idsp)
		{
			var check = await _comboItemService.GetAllCombosItemAsync();
			var combos = await _comboService.GetCombosByIdAsync(_idCombo);
			var lstComboItem = check.FindAll(c => c.CombosId == _idCombo);
			var priceCombo = 0;
			foreach (var item in lstComboItem)
			{
				var productCombos = await _productService.GetProductByIdAsync(item.ProductId);
				priceCombo *= productCombos.Price;
			}
			combos.CombosPrice = priceCombo;
			await _comboService.UpdateCombosAsync(combos);

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
		public async Task<IActionResult> UpdateCombo(Combos r, IFormFile imageFile) // Mở form
		{

            if (imageFile != null && imageFile.Length > 0) // Kiểm tra đường dẫn phù hợp
            {
                // thực hiện việc sao chép ảnh đó vào wwwroot
                // Tạo đường dẫn tới thư mục sao chép (nằm trong root)
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot",
                    "images", imageFile.FileName); // abc/wwwroot/images/xxx.png
                var stream = new FileStream(path, FileMode.Create); // Tạo 1 filestream để tạo mới
                imageFile.CopyTo(stream); // Copy ảnh vừa dc chọn vào đúng cái stream đó
                                          // Gán lại giá trị link ảnh (lúc này đã nằm trong root cho thuộc tính description)
                r.Image = imageFile.FileName;
                await _comboService.UpdateCombosAsync(r);
                _notyfService.Error("Edit Combo thành công");
                _idCombo = r.Id;
                return RedirectToAction("DetailCombos", "Combos", new { id = _idCombo, area = "Admin" });
            }
            else
            {
                return BadRequest();
            }
		}
		public async Task<ActionResult> Updatequantity(List<int> quantity, List<int> idsp)
		{
			var updatequantity = await _comboItemService.GetAllCombosItemAsync();

			for (int i = 0; i < idsp.Count; i++)
			{
				var sp = await _productService.GetProductByIdAsync(idsp[i]);
				int slsp = sp.Quantity;

				var a = updatequantity.FirstOrDefault(c => c.CombosId == _idCombo && c.ProductId == idsp[i]);
				a.Quantity = quantity[i];

				if (quantity[i] > slsp)
				{
					_notyfService.Error("Thay đổi số lượng sản phẩm không thành công");
					return RedirectToAction("DetailCombos", "Combos", new { id = _idCombo, area = "Admin" });
				}
				else
				{
					bool check = await _comboItemService.UpdateCombosItemAsync(a);
					// Kiểm tra giá trị của 'check' để xác định việc cập nhật đã thành công hay không
				}
			}

			_notyfService.Success("Thay đổi số lượng sản phẩm thành công");
			return RedirectToAction("DetailCombos","Combos", new { id = _idCombo, area = "Admin" });
			return RedirectToAction("DetailCombos","Combos", new { id = _idCombo, area = "Admin" });
		}
		//public async Task<ActionResult> Updatequantity(int quantity, int idsp) // Mở form
		//{
		//	var sp = await _productService.GetProductByIdAsync(idsp); // lấy all sp
		//	int slsp = sp.Quantity;
		//	var updatequantity = await _comboItemService.GetAllCombosItemAsync(); // get all combos
		//	var a = updatequantity.FirstOrDefault(c => c.CombosId == _idCombo && c.ProductId == idsp); //get sp  by id
		//	a.Quantity = quantity; // gán sl

		//	if (quantity > slsp)
		//	{
		//		_notyfService.Error("Thay đổi số lương sản phẩm không thành công");
		//		return RedirectToAction("DetailCombos", "Combos", new { id = _idCombo, area = "Admin" });
		//	}
		//	else
		//	{
		//		bool check = await _comboItemService.UpdateCombosItemAsync(a);
		//		// lỗi sản phẩm đầu thay đổi được
		//		_notyfService.Success("Thay đổi số lương sản phẩm thành công ");
		//		return RedirectToAction("DetailCombos", "Combos", new { id = _idCombo, area = "Admin" });
		//	}

		//}
		public async Task<ActionResult> DeleteCombo(int id) // Mở form
		{
			await _comboService.DeleteCombosAsync(id);
			return RedirectToAction("Index", "Combos", new { area = "Admin" });
		}
        public async Task<ActionResult> DeleteProductfromCombo(int idsp) // Mở form
        {

            var combosItem = await _comboItemService.GetAllCombosItemAsync();
            int sp = combosItem.FirstOrDefault(c => c.CombosId == _idCombo && c.ProductId == idsp).CombosItemId;
            await _comboItemService.DeleteCombosItemAsync(sp);
			var product = await _productService.GetProductByIdAsync(idsp);
			product.Price += 1;
			await _productService.UpdateProductAsync(product); // cộng lại số lượng khi xóa
            return RedirectToAction("DetailCombos", "Combos", new { id = _idCombo, area = "Admin" });
        }
    }
}

