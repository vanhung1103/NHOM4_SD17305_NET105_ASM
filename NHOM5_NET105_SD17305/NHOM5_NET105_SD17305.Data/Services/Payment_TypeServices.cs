using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data.Data;
using NHOM5_NET105_SD17305.Data.IServices;
using NHOM5_NET105_SD17305.Data.Models;

namespace NHOM5_NET105_SD17305.Data.Services
{
    public class Payment_TypeServices : IPayment_TypeServices
    {
        private readonly FastFoodDbContext _context;
        public Payment_TypeServices(FastFoodDbContext Context)
        {
            _context = Context;
        }
        public async Task<bool> CreatePayment_TypeAsync(Payment_Type p)
        {
            try
            {
                await _context.Payment_Types.AddAsync(p);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeletePayment_TypeAsync(int id)
        {
            try
            {
                var payment_Type = await _context.Payment_Types.FirstOrDefaultAsync(c => c.Id == id);
                _context.Payment_Types.Remove(payment_Type);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<Payment_Type>> GetAllPayment_TypeAsync()
        {
            return await _context.Payment_Types.ToListAsync();
        }

        public async Task<Payment_Type> GetPayment_TypeByIdAsync(int id)
        {
            return await _context.Payment_Types.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdatePayment_TypeAsync(Payment_Type p)
        {
            try
            {
                _context.Payment_Types.Update(p);
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
