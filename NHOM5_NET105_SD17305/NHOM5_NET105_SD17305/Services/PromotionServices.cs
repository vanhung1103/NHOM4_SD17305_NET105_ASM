using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data;
using NHOM5_NET105_SD17305.IServices;
using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.Services
{
    public class PromotionServices : IPromotionServices
    {
        private readonly FastFoodDbContext _context;
        public PromotionServices(FastFoodDbContext Context)
        {
            _context = Context;
        }
        public async Task<bool> CreatePromotionAsync(Promotion p)
        {
            try
            {
                await _context.promotions.AddAsync(p);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeletePromotionAsync(int id)
        {
            try
            {
                var address = await _context.promotions.FirstOrDefaultAsync(c => c.Id == id);
                _context.promotions.Remove(address);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<Promotion>> GetAllPromotionAsync()
        {
            return await _context.promotions.ToListAsync();
        }

        public async Task<Promotion> GetPromotionByIdAsync(int id)
        {
            return await _context.promotions.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdatePromotionAsync(Promotion p)
        {
            try
            {
                _context.promotions.Update(p);
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
