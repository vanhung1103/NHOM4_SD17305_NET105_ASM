using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data.Models;
using NHOM5_NET105_SD17305.Data.Services;
using NHOM5_NET105_SD17305.Data.IServices;
using System.Security.Claims;
using Microsoft.AspNetCore.Session;

namespace NHOM5_NET105_SD17305.Views.Controllers
{
    public class SignInController : Controller
    {
        private readonly IExternalLoginServices _externalLoginServices;
        private readonly IUserServices _userServices;
        private readonly IProviderLoginServices _providerLoginServices;
        private readonly IRoleServices _roleServices;
        private readonly ICartServices _cartServices;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SignInController(IExternalLoginServices externalLoginServices,IUserServices userServices,IProviderLoginServices providerLoginServices, IRoleServices roleServices,ICartServices cartServices)
        {
            _externalLoginServices = externalLoginServices;
            _userServices = userServices;
            _providerLoginServices = providerLoginServices;
            _roleServices = roleServices;
            _cartServices = cartServices;
        }
        public IActionResult SignIn()
        {
            HttpContext.Session.SetString("UserId", "");
            HttpContext.Session.SetString("RoleId", "");
            HttpContext.Session.SetString("UserName", "");
            var a = HttpContext.Session.GetString("UserId");
            var ab = HttpContext.Session.GetString("RoleId");
            var abc = HttpContext.Session.GetString("UserName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignInAsync(string username,string password)
        {
            var users = await _userServices.GetAllUserAsync();
            var user = users.FirstOrDefault(c => c.Username.ToLower() == username.ToLower()&&c.Password== password) ?? null;
            if (user!=null)
            {
                HttpContext.Session.SetString("UserId", user.UserId.ToString());
                HttpContext.Session.SetString("UserName", user.Username);
                HttpContext.Session.SetString("RoleId", user.RoleId.ToString());

            }
            return RedirectToAction("CheckRole", "SignIn", new { Area = "" });
        }
        public async Task<IActionResult> SignOut()
        {
            HttpContext.Session.SetString("UserId", "");
           HttpContext.Session.SetString("RoleId", "");
           HttpContext.Session.SetString("UserName", "");
            var a = HttpContext.Session.GetString("UserId");
            var ab= HttpContext.Session.GetString("RoleId");
            var abc = HttpContext.Session.GetString("UserName");
            return RedirectToAction("SignIn", "SignIn", new { area = "" });
        }

        public async Task LoginWithGoogle()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties()
            {
                RedirectUri = Url.Action("GoogleResponseLogin")
            });
        }
        public async Task<IActionResult> CheckRole()
        {
            var getUserId = HttpContext.Session.GetString("UserId") ?? "";
            var getRoleID = HttpContext.Session.GetString("RoleId") ?? "";
            var GetUsser = HttpContext.Session.GetString("UserName") ?? "";
            if (getUserId!="")
            {
                var user = await _userServices.GetUserByIdAsync(Convert.ToInt32(getUserId));
                var username = user.Username;
                HttpContext.Session.SetString("UserName", username);
                if (getRoleID == "1")
                {
                   return RedirectToAction("Index","Home",new { Area = "Admin"});
                }
                if (getRoleID == "2")
                {
                    return RedirectToAction("Home", "Home",new { Area = "Customer" });
                }
            }
            return RedirectToAction("Home", "Home", new { Area = "" });
        }
        public async Task<IActionResult> GoogleResponseLogin()// trang đăng nhập google
        {

            var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
            var claims = result.Principal.Identities.FirstOrDefault().Claims.ToList();
            // 1. phải check xem có tồn tại trong externallogin không
            // 2. Nếu có thì lấy userid và login (lưu userid vào session)
            // 2.1 Nếu không có thì:
            // redirect sang trang bắt nó nhập thông tin, tạo user mới và externallogin và login (lưu userid vào session)
            var providerKey = claims?.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            var email = claims?.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
            var externals = await _externalLoginServices.GetAllExternalLoginAsync();
            var externalLogin = externals.FirstOrDefault(c => c.ProviderKey == providerKey);
            if (externalLogin != null)// nếu account tồn tại
            {
                var user = await _userServices.GetUserByIdAsync(externalLogin.UserId);
                var role = user.RoleId;
                HttpContext.Session.SetString("UserId", externalLogin.UserId.ToString()); // gán userid vào session
                HttpContext.Session.SetString("UserName", user.Username.ToString());
                HttpContext.Session.SetString("RoleId", role.ToString());
                return RedirectToAction("CheckRole", "SignIn", new { Area = "" });
            }
            else
            {
                // đáng ra là redirect sang form bắt user nhập thông tin
                var user = new User();// tạo user mới
                user.Username = email;
                user.Password = "";
                user.RoleId = 2;
                await _userServices.CreateUserAsync(user);
                var google = await _providerLoginServices.GetAllProviderLogin();
                var googleId =  google.FirstOrDefault(c => c.ProviderName.ToLower() == "google").ProviderId;

                var external = new ExternalLogin(); //tạo bản ghi external login google
                external.ProviderKey = providerKey;
                external.ProviderId = googleId;
                external.UserId = user.UserId;
                await _externalLoginServices.CreateExternalLoginAsync(external);
                HttpContext.Session.SetString("UserId", user.UserId.ToString()); // gán userid vào session
                HttpContext.Session.SetString("RoleId", user.RoleId.ToString()); 
                HttpContext.Session.SetString("UserName", user.Username.ToString());
                var cart = new Cart()
                {
                    UserId = user.UserId,
                    Description = 1,
                };
                await _cartServices.CreateCartAsync(cart);
                return RedirectToAction("CheckRole", "SignIn", new { Area = "" });
            }
        }
        public async Task ConnectWithGoogle(int id) // kết nối google
        {
            HttpContext.Session.SetString("Id", id.ToString()); // mỗi tài khoản khi đăng nhập mới cho liên kết nên có thể sửa id thành UserId
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties()
            {
                RedirectUri = Url.Action("ConnectGoogle")
            });
        }
        public async Task<IActionResult> ConnectGoogle()
        {
            var id = HttpContext.Session.GetString("Id") ?? "";
            var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
            var claims = result.Principal.Identities.FirstOrDefault().Claims.ToList();
            // phần connect
            // kiểm tra xem có đã tồn tại trong externallogin không
            // nếu có thì hiện hủy kết nối
            // nếu không thì cho sang trang kết nối
            // chọn account:
            // -nếu chọn account đã có trong externallogin thì hiện thông báo đã có
            // -nếu chọn account chưa có trong externallogin thì thêm vào externallogin


            var providerKey = claims?.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            var email = claims?.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;

            var external = await _externalLoginServices.GetAllExternalLoginAsync();
            var externalLogin = external.FirstOrDefault(c => c.ProviderKey == providerKey);
            if (externalLogin != null)
            {
                return Content("Connect false");
            }
            else
            {
                var google = await _providerLoginServices.GetAllProviderLogin();
                var googleId = google.FirstOrDefault(c => c.ProviderName.ToLower() == "google").ProviderId; // lấy id provider google
                var externals = new ExternalLogin(); //tạo bản ghi external login google
                externals.ProviderKey = providerKey;
                externals.ProviderId = googleId;
                externals.UserId = int.Parse(id);
                await _externalLoginServices.CreateExternalLoginAsync(externals);
                HttpContext.Session.SetString("UserId", id.ToString()); // gán userid vào session
                return Content("Connect true");
                //return RedirectToAction("Index", "Home");
            }
        }
    }
}
