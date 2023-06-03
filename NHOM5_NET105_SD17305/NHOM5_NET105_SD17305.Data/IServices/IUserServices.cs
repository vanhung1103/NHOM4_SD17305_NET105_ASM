using Microsoft.AspNetCore.Identity;
using NHOM5_NET105_SD17305.Data.Models;

namespace NHOM5_NET105_SD17305.Data.IServices
{
    public interface IUserServices
    {
        public Task<bool> CreateUserAsync(User p, string role);

        public Task<bool> UpdateUserAsync(User p);
        public Task<bool> DeleteUserAsync(string id);
        public Task<IdentityUser> GetUserByIdAsync(string id);

        public Task<List<IdentityUser>> GetAllUserAsync();
    }
}
