using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data;
using NHOM5_NET105_SD17305.IServices;
using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.Services
{
    public class Provider_LoginServices : IProvider_LoginServices
    {
        private readonly FastFoodDbContext _context;
        public Provider_LoginServices(FastFoodDbContext Context)
        {
            _context = Context;
        }
        public async Task<bool> CreateProvider_LoginAsync(Provider_Login p)
        {
            try
            {
                await _context.provider_Logins.AddAsync(p);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteProvider_LoginAsync(int id)
        {
            try
            {
                var address = await _context.provider_Logins.FirstOrDefaultAsync(c => c.Id == id);
                _context.provider_Logins.Remove(address);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<Provider_Login>> GetAllProvider_LoginAsync()
        {
            return await _context.provider_Logins.ToListAsync();
        }

        public async Task<Provider_Login> GetProvider_LoginByIdAsync(int id)
        {
            return await _context.provider_Logins.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdateProvider_LoginAsync(Provider_Login p)
        {
            try
            {
                _context.provider_Logins.Update(p);
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
