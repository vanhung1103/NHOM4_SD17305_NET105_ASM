using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data;
using NHOM5_NET105_SD17305.IServices;
using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.Services
{
    public class RoleServices: IRoleServices
    {
        private readonly FastFoodDbContext _context;
        public RoleServices(FastFoodDbContext Context)
        {
            _context = Context;
        }

        public async Task<bool> CreateRoleAsync(Role p)
        {
            try
            {
                await _context.roles.AddAsync(p);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            try
            {
                var address = await _context.roles.FirstOrDefaultAsync(c => c.Id == id);
                _context.roles.Remove(address);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<Role>> GetAllRoleAsync()
        {
            return await _context.roles.ToListAsync();
        }

        public async Task<Role> GetRoleByIdAsync(int id)
        {
            return await _context.roles.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdateRoleAsync(Role p)
        {
            try
            {
                _context.roles.Update(p);
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
