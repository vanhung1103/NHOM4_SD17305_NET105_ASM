using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHOM5_NET105_SD17305.Data.IServices;
using NHOM5_NET105_SD17305.Data.Models;

namespace NHOM5_NET105_SD17305.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _iproductServices;
        public ProductController(IProductServices productServices) { 

            _iproductServices = productServices;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var pro = await _iproductServices.GetAllProductAsync();
            return Ok(pro);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var pro = await _iproductServices.GetProductByIdAsync(id);
            return Ok(pro);
        }


        [HttpPost("Post")]
       
        public async Task<IActionResult> Post(Product product, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0) // Kiểm tra đường dẫn phù hợp
            {
                // thực hiện việc sao chép ảnh đó vào wwwroot
                // Tạo đường dẫn tới thư mục sao chép (nằm trong root)
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot",
                    "images", imageFile.FileName); // abc/wwwroot/images/xxx.png
                var stream = System.IO.File.Create(path);
               /* var stream = new FileStream(path, FileMode.Create);*/ // Tạo 1 filestream để tạo mới
                await imageFile.CopyToAsync(stream); // Copy ảnh vừa dc chọn vào đúng cái stream đó
                // Gán lại giá trị link ảnh (lúc này đã nằm trong root cho thuộc tính description)
                product.Image = imageFile.FileName;
            }
            await _iproductServices.CreateProductAsync(product);
            return Ok();
        }
        [HttpPost("them-anh")]

        public async Task<IActionResult> PostImage([FromForm] ProductImage p)
        {
            var pro = await _iproductServices.GetProductByIdAsync(p.ProductId);
            if (pro != null)
            {
                return Ok("Product exist");
            }
            else
            {
                var product = new Product
                {
                    Id = p.ProductId,
                    ProductName = p.ProductName,
                    Cate_Id = p.Cate_Id,
                    Price = p.Price,
                    Weight = p.Weight,
                    Quantity = p.Quantity,
                    Descriptions = p.Descriptions,
                    LongDescription = p.LongDescription

                };
                if (p.Image.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images","items", p.Image.FileName);
                    using (var stream = System.IO.File.Create(path))
                    {
                        await p.Image.CopyToAsync(stream);
                    }
                    product.Image = "/images/items" + p.Image.FileName;
                }

                await _iproductServices.CreateProductAsync(product);
                return Ok(product);
            }
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> Put(Product pro)
        {
        
            var pros =  await _iproductServices.UpdateProductAsync(pro);
            return Ok(pros);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            await _iproductServices.DeleteProductAsync(id);
            return Ok();
        }

    }
}
