using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data;
using NHOM5_NET105_SD17305.IServices;
using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.Services
{
    public class ProductServices : IProductServices
    {
        private readonly FastFoodDbContext _context;
        public ProductServices(FastFoodDbContext Context)
        {
            _context = Context;
        }
        public async Task<bool> CreateProductAsync(Product p)
        {
            try
            {
                await _context.products.AddAsync(p);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            try
            {
                var product = await _context.products.FirstOrDefaultAsync(c => c.Id == id);
                _context.products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<Product>> GetAllProductAsync()
        {
            return await _context.products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.products.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdateProductAsync(Product p)
        {
            try
            {
                _context.products.Update(p);
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
