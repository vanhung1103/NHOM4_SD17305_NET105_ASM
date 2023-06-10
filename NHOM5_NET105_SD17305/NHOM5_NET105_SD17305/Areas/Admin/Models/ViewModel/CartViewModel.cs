using NHOM5_NET105_SD17305.Data.Models;

namespace NHOM5_NET105_SD17305.Views.Areas.Admin.Models.ViewModel
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
