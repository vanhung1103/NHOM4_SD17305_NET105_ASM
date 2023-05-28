using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data;
using NHOM5_NET105_SD17305.IServices;
using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.Services
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
                await _context.combositems.AddAsync(p);
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
                var combosItem = await _context.combositems.FirstOrDefaultAsync(c => c.CombosItemId == id);
                _context.combositems.Remove(combosItem);
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
            return await _context.combositems.ToListAsync();
        }

        public async Task<CombosItem> GetCombosItemByIdAsync(int id)
        {
            return await _context.combositems.FirstOrDefaultAsync(c => c.CombosItemId == id);
        }

        public async Task<bool> UpdateCombosItemAsync(CombosItem p)
        {
            try
            {
                _context.combositems.Update(p);
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
