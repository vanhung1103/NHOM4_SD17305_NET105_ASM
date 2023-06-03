using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data.Data;
using NHOM5_NET105_SD17305.Data.IServices;
using NHOM5_NET105_SD17305.Data.Models;

namespace NHOM5_NET105_SD17305.Data.Services
{
    public class Promotionservices : IPromotionServices
    {
        private readonly FastFoodDbContext _context;
        public Promotionservices(FastFoodDbContext Context)
        {
            _context = Context;
        }
        public async Task<bool> CreatePromotionAsync(Promotion p)
        {
            try
            {
                await _context.Promotions.AddAsync(p);
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
                var address = await _context.Promotions.FirstOrDefaultAsync(c => c.Id == id);
                _context.Promotions.Remove(address);
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
            return await _context.Promotions.ToListAsync();
        }

        public async Task<Promotion> GetPromotionByIdAsync(int id)
        {
            return await _context.Promotions.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdatePromotionAsync(Promotion p)
        {
            try
            {
                _context.Promotions.Update(p);
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
