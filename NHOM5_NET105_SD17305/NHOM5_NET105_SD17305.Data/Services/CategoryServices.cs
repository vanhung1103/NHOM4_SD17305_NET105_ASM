using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data.Data;
using NHOM5_NET105_SD17305.Data.IServices;
using NHOM5_NET105_SD17305.Data.Models;

namespace NHOM5_NET105_SD17305.Data.Services
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
                await _context.Category.AddAsync(p);
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
                var category = await _context.Category.FirstOrDefaultAsync(c => c.Id == id);
                _context.Category.Remove(category);
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
            return await _context.Category.ToListAsync();
        }
        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _context.Category.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdateCategoryAsync(Category p)
        {
            try
            {
                _context.Category.Update(p);
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
