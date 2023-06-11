using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NHOM5_NET105_SD17305.Data.Data;
using NHOM5_NET105_SD17305.Data.IServices;
using NHOM5_NET105_SD17305.Data.Models;
using System.Data;

namespace NHOM5_NET105_SD17305.Data.Services
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
                await _context.Users.AddAsync(p);
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
                var payment_Type = await _context.Users.FirstOrDefaultAsync(c => c.UserId == id);
                _context.Users.Remove(payment_Type);
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
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(c => c.UserId == id);

        }

        public async Task<bool> UpdateUserAsync(User p)
        {
            try
            {
                _context.Users.Update(p);
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
