using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data;
using NHOM5_NET105_SD17305.IServices;
using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.Services
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
                await _context.cartItems.AddAsync(p);
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
                var cartItem = await _context.cartItems.FirstOrDefaultAsync(c => c.Id == id);
                _context.cartItems.Remove(cartItem);
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
            return await _context.cartItems.ToListAsync();
        }

        public async Task<CartItem> GetCartItemByIdAsync(int id)
        {
            return await _context.cartItems.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdateCartItemAsync(CartItem p)
        {
            try
            {
                _context.cartItems.Update(p);
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
