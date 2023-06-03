using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data.Data;
using NHOM5_NET105_SD17305.Data.IServices;
using NHOM5_NET105_SD17305.Data.Models;

namespace NHOM5_NET105_SD17305.Data.Services
{
    public class PromotionItemservices : IPromotionItemServices
    {
        private readonly FastFoodDbContext _context;
        public PromotionItemservices(FastFoodDbContext Context)
        {
            _context = Context;
        }

        public async Task<bool> CreatePromotionItemAsync(PromotionItem p)
        {
            try
            {
                await _context.PromotionItems.AddAsync(p);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeletePromotionItemAsync(int id)
        {
            try
            {
                var address = await _context.PromotionItems.FirstOrDefaultAsync(c => c.Id == id);
                _context.PromotionItems.Remove(address);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<PromotionItem>> GetAllPromotionItemAsync()
        {
            return await _context.PromotionItems.ToListAsync();
        }

        public async Task<PromotionItem> GetPromotionItemByIdAsync(int id)
        {
            return await _context.PromotionItems.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdatePromotionItemAsync(PromotionItem p)
        {
            try
            {
                _context.PromotionItems.Update(p);
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
