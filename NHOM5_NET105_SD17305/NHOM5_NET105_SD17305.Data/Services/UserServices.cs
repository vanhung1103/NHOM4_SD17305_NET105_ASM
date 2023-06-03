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
        private readonly UserManager<IdentityUser> _userManager;
        public UserServices(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<bool> CreateUserAsync(User p,string role)
        {
            try
            {
                IdentityUser identityUser = new IdentityUser()
                {
                    Email = p.UserName.ToLower(),
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                var result = await _userManager.CreateAsync(identityUser, p.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(identityUser, role);
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<IdentityUser>> GetAllUserAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<IdentityUser> GetUserByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<bool> UpdateUserAsync(User p)
        {
            try
            {
                // thêm các trường khác
                var user = await _userManager.FindByNameAsync(p.UserName);
                if (user != null)
                {
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
                    await _userManager.UpdateAsync(user);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
