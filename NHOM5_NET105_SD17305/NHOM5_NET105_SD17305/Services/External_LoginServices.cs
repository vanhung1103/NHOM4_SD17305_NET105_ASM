using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data;
using NHOM5_NET105_SD17305.IServices;
using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.Services
{
    public class External_LoginServices: IExternal_LoginServices
    {
        private readonly FastFoodDbContext _context;
        public External_LoginServices(FastFoodDbContext Context)
        {
            _context = Context;
        }

        public async Task<bool> CreateExternal_LoginAsync(External_Login p)
        {
            try
            {
                await _context.external_Logins.AddAsync(p);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteExternal_LoginAsync(int id)
        {
            try
            {
                var external_Login = await _context.external_Logins.FirstOrDefaultAsync(c => c.Id == id);
                _context.external_Logins.Remove(external_Login);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<External_Login>> GetAllExternal_LoginAsync()
        {
            return await _context.external_Logins.ToListAsync();
        }

        public async Task<External_Login> GetExternal_LoginByIdAsync(int id)
        {
            return await _context.external_Logins.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdateExternal_LoginAsync(External_Login p)
        {
            try
            {
                _context.external_Logins.Update(p);
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
