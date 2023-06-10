using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NHOM5_NET105_SD17305.Data.Models;
using System.Text;

namespace NHOM5_NET105_SD17305.Views.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        HttpClient _client;
      
        public ProductController()
        {
            _client = new HttpClient();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ShowListProduct()
        {
            string apiurl = "https://localhost:7003/api/Product/get-all";
            var response = await _client.GetAsync(apiurl);
            var data = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Product>>(data);
            return View(result);
            
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id) {

            string apiurl = "https://localhost:7003/api/Product/";
            var response = await _client.GetAsync(apiurl +id);
            var data = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Product>(data);
            return View(result);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
         [HttpPost]
        public async Task<IActionResult> Create(Product product, IFormFile imageFile )
        {

            if (imageFile != null && imageFile.Length > 0) // Kiểm tra đường dẫn phù hợp
            {
                // thực hiện việc sao chép ảnh đó vào wwwroot
                // Tạo đường dẫn tới thư mục sao chép (nằm trong root)
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot",
                    "images","items", imageFile.FileName); // abc/wwwroot/images/xxx.png
                var stream = new FileStream(path, FileMode.Create); // Tạo 1 filestream để tạo mới
                imageFile.CopyTo(stream); // Copy ảnh vừa dc chọn vào đúng cái stream đó
                // Gán lại giá trị link ảnh (lúc này đã nằm trong root cho thuộc tính description)
                product.Image = imageFile.FileName;
            }
            string apiurl = "https://localhost:7003/api/Product/Post";
            var data = JsonConvert.SerializeObject(product);
            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(apiurl, stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowListProduct");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            string apiurl = "https://localhost:7003/api/Product/";
            var response = await _client.GetAsync(apiurl + id);
            var data = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Product>(data);
            return View(result);


        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {

            string apiurl = "https://localhost:7003/api/Product/";
            var data = JsonConvert.SerializeObject(product);
            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(apiurl + product.Id, stringContent);
          
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowListProduct");
            }
            return View();
        }

        //[HttpGet]
        //public async Task<IActionResult> Delete(int id)
        //{

        //    string apiurl = "https://localhost:7003/api/Product/";
        //    var response = await _client.GetAsync(apiurl + id);
        //    var data = await response.Content.ReadAsStringAsync();
        //    var result = JsonConvert.DeserializeObject<Product>(data);
        //    return View(result);
        //}
        //[HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            string apiurl = "https://localhost:7003/api/Product/";
            var response = await _client.DeleteAsync(apiurl + id);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowListProduct");
            }
            return View();
        }
    }
}
