using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.IServices
{
    public interface IUserServices
    {
        public Task<bool> CreateUserAsync(User p);

        public Task<bool> UpdateUserAsync(User p);
        public Task<bool> DeleteUserAsync(int id);
        public Task<User> GetUserByIdAsync(int id);

        public Task<List<User>> GetAllUserAsync();
    }
}
