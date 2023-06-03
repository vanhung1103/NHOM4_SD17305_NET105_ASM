using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data.Data;
using NHOM5_NET105_SD17305.Data.IServices;
using NHOM5_NET105_SD17305.Data.Models;

namespace NHOM5_NET105_SD17305.Data.Services
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
                await _context.Combos.AddAsync(p);
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
                var combos = await _context.Combos.FirstOrDefaultAsync(c => c.Id == id);
                _context.Combos.Remove(combos);
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
            return await _context.Combos.ToListAsync();
        }

        public async Task<Combos> GetCombosByIdAsync(int id)
        {
            return await _context.Combos.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdateCombosAsync(Combos p)
        {
            try
            {
                _context.Combos.Update(p);
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
