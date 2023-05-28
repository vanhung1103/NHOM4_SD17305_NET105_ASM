using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data;
using NHOM5_NET105_SD17305.IServices;
using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly FastFoodDbContext _context;
        public CategoryServices(FastFoodDbContext Context)
        {
            _context = Context;
        }
        public async Task<bool> CreateCategoryAsync(Category p)
        {
            try
            {
                await _context.categories.AddAsync(p);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            try
            {
                var category = await _context.categories.FirstOrDefaultAsync(c => c.Id == id);
                _context.categories.Remove(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<Category>> GetAllCategoryAsync()
        {
            return await _context.categories.ToListAsync();
        }
        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _context.categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdateCategoryAsync(Category p)
        {
            try
            {
                _context.categories.Update(p);
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
