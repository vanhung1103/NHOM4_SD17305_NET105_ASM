using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data;
using NHOM5_NET105_SD17305.IServices;
using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.Services
{
    public class UserServices : IUserServices
    {
        private readonly FastFoodDbContext _context;
        public UserServices(FastFoodDbContext Context)
        {
            _context = Context;
        }
        public async Task<bool> CreateUserAsync(User p)
        {
            try
            {
                await _context.users.AddAsync(p);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            try
            {
                var address = await _context.users.FirstOrDefaultAsync(c => c.Id == id);
                _context.users.Remove(address);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            return await _context.users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.users.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdateUserAsync(User p)
        {
            try
            {
                _context.users.Update(p);
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
