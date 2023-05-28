using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.IServices
{
    public interface IBillItemServices
    {
        public Task<bool> CreateBillItemAsync(BillItem p);

        public Task<bool> UpdateBillItemAsync(BillItem p);
        public Task<bool> DeleteBillItemAsync(int id);
        public Task<BillItem> GetBillItemByIdAsync(int id);

        public Task<List<BillItem>> GetAllBillItemAsync();
    }
}
