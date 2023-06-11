using Microsoft.AspNetCore.Mvc;
using NHOM5_NET105_SD17305.Data.IServices;
using NHOM5_NET105_SD17305.Data.Models;
using NHOM5_NET105_SD17305.Data.Services;

namespace NHOM5_NET105_SD17305.Views.Controllers
{
    public class SignUpController : Controller
    {
        private IUserServices _userServices;
        private readonly ICartServices _cartServices;

        public SignUpController(IUserServices userServices,ICartServices cartServices)
        {
            _userServices = userServices;
            _cartServices = cartServices;
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUpAsync(string username,string password,string repassword)
        {
            if (!string.IsNullOrWhiteSpace(username)&& !string.IsNullOrWhiteSpace(password) && !string.IsNullOrWhiteSpace(repassword))
            {
                var users = await _userServices.GetAllUserAsync();
                var user = users.FirstOrDefault(c => c.Username.ToLower() == username.ToLower()) ?? null;
                if (user==null)
                {
                    if (password == repassword)
                    {          var usercreate = new User()
                            {
                                Username = username,
                                Password = password,
                                RoleId = 2
                            };
                             
                            if (await _userServices.CreateUserAsync(usercreate))
                            {
                            var cart = new Cart()
                            {
                                UserId = usercreate.UserId,
                                Description = 1
                            };
                           await _cartServices.CreateCartAsync(cart);
                                HttpContext.Session.SetString("UserId", usercreate.ToString());
                                HttpContext.Session.SetString("UserName", usercreate.Username);
                                HttpContext.Session.SetString("RoleId", "2");
                            return RedirectToAction("SignIn", "SignIn", new { Area = "" });
                        }
                    }
                }
            }
            return View();
        }

    }
}
