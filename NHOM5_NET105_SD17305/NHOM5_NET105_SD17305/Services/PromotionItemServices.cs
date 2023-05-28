using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data;
using NHOM5_NET105_SD17305.IServices;
using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.Services
{
    public class PromotionItemServices : IPromotionItemServices
    {
        private readonly FastFoodDbContext _context;
        public PromotionItemServices(FastFoodDbContext Context)
        {
            _context = Context;
        }

        public async Task<bool> CreatePromotionItemAsync(PromotionItem p)
        {
            try
            {
                await _context.promotionItems.AddAsync(p);
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
                var address = await _context.promotionItems.FirstOrDefaultAsync(c => c.Id == id);
                _context.promotionItems.Remove(address);
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
            return await _context.promotionItems.ToListAsync();
        }

        public async Task<PromotionItem> GetPromotionItemByIdAsync(int id)
        {
            return await _context.promotionItems.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdatePromotionItemAsync(PromotionItem p)
        {
            try
            {
                _context.promotionItems.Update(p);
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
