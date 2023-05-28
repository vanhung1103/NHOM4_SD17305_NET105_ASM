using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.IServices
{
    public interface IExternal_LoginServices
    {
        public Task<bool> CreateExternal_LoginAsync(External_Login p);

        public Task<bool> UpdateExternal_LoginAsync(External_Login p);
        public Task<bool> DeleteExternal_LoginAsync(int id);
        public Task<External_Login> GetExternal_LoginByIdAsync(int id);

        public Task<List<External_Login>> GetAllExternal_LoginAsync();
    }
}
