    using Microsoft.AspNetCore.Mvc;
using NHOM5_NET105_SD17305.Data.IServices;
using NHOM5_NET105_SD17305.Data.Models;
using System.Security.AccessControl;

namespace NHOM5_NET105_SD17305.Views.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ProfileController : Controller
    {
        private readonly IUserServices _userService;
        private readonly ICustomerServices _customerService;
        private readonly IAddressServices _addessService;

        public ProfileController(IUserServices userServices,ICustomerServices customerServices,IAddressServices addressServices)
        {
            _userService = userServices;
            _customerService = customerServices;
            _addessService = addressServices;
        }
        public async Task<IActionResult> Index()
        {
            int isUser = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            var a = await _customerService.GetCustomerByIdAsync(isUser);
            if (a == null)
            {
                return RedirectToAction("Home", "Home", new {area="Customer"});
            }
            return View(a);
        }

        public async Task<IActionResult> EditUser()
        {
            int isUser = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            var a = await _customerService.GetCustomerByIdAsync(isUser);
            return View(a);
        }
       

    }
}
