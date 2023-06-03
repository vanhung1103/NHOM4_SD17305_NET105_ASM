using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data.Data;
using NHOM5_NET105_SD17305.Data.IServices;
using NHOM5_NET105_SD17305.Data.Models;

namespace NHOM5_NET105_SD17305.Data.Services
{
    public class CartItemServices : IcartItemServices
    {
        private readonly FastFoodDbContext _context;
        public CartItemServices(FastFoodDbContext Context)
        {
            _context = Context;
        }
        public async Task<bool> CreateCartItemAsync(CartItem p)
        {
            try
            {
                await _context.CartItems.AddAsync(p);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteCartItemAsync(int id)
        {
            try
            {
                var cartItem = await _context.CartItems.FirstOrDefaultAsync(c => c.Id == id);
                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<CartItem>> GetAllCartItemAsync()
        {
            return await _context.CartItems.ToListAsync();
        }

        public async Task<CartItem> GetCartItemByIdAsync(int id)
        {
            return await _context.CartItems.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdateCartItemAsync(CartItem p)
        {
            try
            {
                _context.CartItems.Update(p);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
