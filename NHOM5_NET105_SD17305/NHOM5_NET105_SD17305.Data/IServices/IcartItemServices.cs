using NHOM5_NET105_SD17305.Data.Models;

namespace NHOM5_NET105_SD17305.Data.IServices
{
    public interface IcartItemServices
    {
        public Task<bool> CreateCartItemAsync(CartItem p);

        public Task<bool> UpdateCartItemAsync(CartItem p);
        public Task<bool> DeleteCartItemAsync(int id);
        public Task<CartItem> GetCartItemByIdAsync(int id);

        public Task<List<CartItem>> GetAllCartItemAsync();
    }
}
