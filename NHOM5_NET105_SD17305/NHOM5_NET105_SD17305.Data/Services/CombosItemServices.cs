using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data.Data;
using NHOM5_NET105_SD17305.Data.IServices;
using NHOM5_NET105_SD17305.Data.Models;

namespace NHOM5_NET105_SD17305.Data.Services
{
    public class CombosItemServices: ICombosItemServices
    {
        private readonly FastFoodDbContext _context;
        public CombosItemServices(FastFoodDbContext Context)
        {
            _context = Context;
        }

        public async Task<bool> CreateCombosItemAsync(CombosItem p)
        {
            try
            {
                await _context.CombosItems.AddAsync(p);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteCombosItemAsync(int id)
        {
            try
            {
                var combosItem = await _context.CombosItems.FirstOrDefaultAsync(c => c.CombosItemId == id);
                _context.CombosItems.Remove(combosItem);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<CombosItem>> GetAllCombosItemAsync()
        {
            return await _context.CombosItems.ToListAsync();
        }

        public async Task<CombosItem> GetCombosItemByIdAsync(int id)
        {
            return await _context.CombosItems.FirstOrDefaultAsync(c => c.CombosItemId == id);
        }

        public async Task<bool> UpdateCombosItemAsync(CombosItem p)
        {
            try
            {
                _context.CombosItems.Update(p);
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
