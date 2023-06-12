using Microsoft.AspNetCore.Mvc;
using NHOM5_NET105_SD17305.Data.IServices;

namespace NHOM5_NET105_SD17305.Views.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProfileAdminController : Controller
    {
        private readonly IUserServices _userService;
        private readonly ICustomerServices _customerService;
        private readonly IAddressServices _addessService;

        public ProfileAdminController(IUserServices userServices, ICustomerServices customerServices, IAddressServices addressServices)
        {
            _userService = userServices;
            _customerService = customerServices;
            _addessService = addressServices;
        }
        public async Task<IActionResult> IndexAdmin()
        {
            int isUser = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            var a = await _customerService.GetCustomerByIdAsync(isUser);
            if (a == null)
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return View(a);
        }

        public async Task<IActionResult> Edit()
        {
            int isUser = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            var a = await _customerService.GetCustomerByIdAsync(isUser);
            return View(a);
        }

    } 
}
