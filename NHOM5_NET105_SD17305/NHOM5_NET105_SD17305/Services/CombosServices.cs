using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data;
using NHOM5_NET105_SD17305.IServices;
using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.Services
{
    public class CombosServices : ICombosServices
    {
        private readonly FastFoodDbContext _context;
        public CombosServices(FastFoodDbContext Context)
        {
            _context = Context;
        }
        public async Task<bool> CreateCombosAsync(Combos p)
        {
            try
            {
                await _context.combos.AddAsync(p);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteCombosAsync(int id)
        {
            try
            {
                var combos = await _context.combos.FirstOrDefaultAsync(c => c.Id == id);
                _context.combos.Remove(combos);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<Combos>> GetAllCombosAsync()
        {
            return await _context.combos.ToListAsync();
        }

        public async Task<Combos> GetCombosByIdAsync(int id)
        {
            return await _context.combos.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdateCombosAsync(Combos p)
        {
            try
            {
                _context.combos.Update(p);
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
