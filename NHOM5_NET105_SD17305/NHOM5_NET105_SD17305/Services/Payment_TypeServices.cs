using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data;
using NHOM5_NET105_SD17305.IServices;
using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.Services
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
                await _context.payment_Types.AddAsync(p);
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
                var payment_Type = await _context.payment_Types.FirstOrDefaultAsync(c => c.Id == id);
                _context.payment_Types.Remove(payment_Type);
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
            return await _context.payment_Types.ToListAsync();
        }

        public async Task<Payment_Type> GetPayment_TypeByIdAsync(int id)
        {
            return await _context.payment_Types.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdatePayment_TypeAsync(Payment_Type p)
        {
            try
            {
                _context.payment_Types.Update(p);
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
