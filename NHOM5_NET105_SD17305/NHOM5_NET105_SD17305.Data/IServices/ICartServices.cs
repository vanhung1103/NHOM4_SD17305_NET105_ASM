using NHOM5_NET105_SD17305.Data.Models;

namespace NHOM5_NET105_SD17305.Data.IServices
{
    public interface ICartServices
    {
        public Task<bool> CreateCartAsync(Cart p);

        public Task<bool> UpdateCartAsync(Cart p);
        public Task<bool> DeleteCartAsync(int id);
        public Task<Cart> GetCartByIdAsync(int id);
        
        public Task<List<Cart>> GetAllCartAsync();
    }
}
