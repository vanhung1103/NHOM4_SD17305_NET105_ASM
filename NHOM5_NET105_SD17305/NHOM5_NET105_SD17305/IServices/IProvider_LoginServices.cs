using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.IServices
{
    public interface IProvider_LoginServices
    {
        public Task<bool> CreateProvider_LoginAsync(Provider_Login p);

        public Task<bool> UpdateProvider_LoginAsync(Provider_Login p);
        public Task<bool> DeleteProvider_LoginAsync(int id);
        public Task<Provider_Login> GetProvider_LoginByIdAsync(int id);

        public Task<List<Provider_Login>> GetAllProvider_LoginAsync();
    }
}
