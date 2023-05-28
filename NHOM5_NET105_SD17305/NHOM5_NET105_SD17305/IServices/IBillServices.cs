using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.IServices
{
    public interface IBillServices
    {
        public Task<bool> CreateBillAsync(Bill p);

        public Task<bool> UpdateBillAsync(Bill p);
        public Task<bool> DeleteBillAsync(int id);
        public Task<Bill> GetBillByIdAsync(int id);

        public Task<List<Bill>> GetAllBillAsync();
    }
}
