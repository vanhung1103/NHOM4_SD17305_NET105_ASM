using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using System.Security.Claims;
using TestLogin.Models;

namespace TestLogin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(string username, string password)
        {

            if (username == "1" && password == "1")
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, "Admin"),
        };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties
                {
                    RedirectUri = "/Home/Privacy", // Đường dẫn chuyển hướng sau khi đăng nhập thành công
                    IsPersistent = true, // Lưu cookie khi đăng nhập thành công
                    
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(20) // Thời gian hết hạn của cookie
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);

                var isAuthenticated = User.Identity.IsAuthenticated;
                if (isAuthenticated)
                {
                    var isAdmin = User.IsInRole("Admin");
                    if (isAdmin)
                    {
                        return RedirectToAction("Privacy");
                    }
                    else
                    {
                        return RedirectToAction("khac");
                    }
                }
                else
                {
                    return RedirectToAction("Privacy");
                }
            }

            return View();
        }


        //[Authorize(Roles = "Admin")]
        public IActionResult Privacys()
        {
            return View();
        }
        public async Task<IActionResult> SignOutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Privacy");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}