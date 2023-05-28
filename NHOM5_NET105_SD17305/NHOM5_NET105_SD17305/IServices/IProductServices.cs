using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.IServices
{
    public interface IProductServices
    {
        public Task<bool> CreateProductAsync(Product p);

        public Task<bool> UpdateProductAsync(Product p);
        public Task<bool> DeleteProductAsync(int id);
        public Task<Product> GetProductByIdAsync(int id);

        public Task<List<Product>> GetAllProductAsync();
    }
}
