using NHOM5_NET105_SD17305.Data.Models;

namespace NHOM5_NET105_SD17305.Data.IServices
{
    public interface ICategoryServices
    {
        public Task<bool> CreateCategoryAsync(Category p);

        public Task<bool> UpdateCategoryAsync(Category p);
        public Task<bool> DeleteCategoryAsync(int id);
        public Task<Category> GetCategoryByIdAsync(int id);

        public Task<List<Category>> GetAllCategoryAsync();
    }
}
