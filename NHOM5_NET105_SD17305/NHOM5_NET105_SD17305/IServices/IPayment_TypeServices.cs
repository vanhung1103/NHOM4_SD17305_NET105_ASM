using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.IServices
{
    public interface IPayment_TypeServices
    {
        public Task<bool> CreatePayment_TypeAsync(Payment_Type p);

        public Task<bool> UpdatePayment_TypeAsync(Payment_Type p);
        public Task<bool> DeletePayment_TypeAsync(int id);
        public Task<Payment_Type> GetPayment_TypeByIdAsync(int id);

        public Task<List<Payment_Type>> GetAllPayment_TypeAsync();
    }
}
