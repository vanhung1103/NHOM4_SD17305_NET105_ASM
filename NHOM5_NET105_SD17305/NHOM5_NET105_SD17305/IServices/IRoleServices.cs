using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.IServices
{
    public interface IRoleServices
    {
        public Task<bool> CreateRoleAsync(Role p);

        public Task<bool> UpdateRoleAsync(Role p);
        public Task<bool> DeleteRoleAsync(int id);
        public Task<Role> GetRoleByIdAsync(int id);

        public Task<List<Role>> GetAllRoleAsync();
    }
}
