using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data;
using NHOM5_NET105_SD17305.IServices;
using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.Services
{
    public class CartServices: ICartServices
    {
        private readonly FastFoodDbContext _context;
        public CartServices(FastFoodDbContext Context)
        {
            _context = Context;
        }

        public async Task<bool> CreateCartAsync(Cart p)
        {
            try
            {
                await _context.carts.AddAsync(p);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteCartAsync(int id)
        {
            try
            {
                var cart = await _context.carts.FirstOrDefaultAsync(c => c.Id == id);
                _context.carts.Remove(cart);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<Cart>> GetAllCartAsync()
        {
            return await _context.carts.ToListAsync();
        }

        public async Task<Cart> GetCartByIdAsync(int id)
        {
            return await _context.carts.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdateCartAsync(Cart p)
        {
            try
            {
                _context.carts.Update(p);
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
