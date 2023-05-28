using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data;
using NHOM5_NET105_SD17305.IServices;
using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.Services
{
    public class BillServices:IBillServices
    {

        private readonly FastFoodDbContext _context;
        public BillServices(FastFoodDbContext Context)
        {
            _context = Context;
        }

        public async Task<bool> CreateBillAsync(Bill p)
        {
            try
            {
                await _context.bills.AddAsync(p);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteBillAsync(int id)
        {
            try
            {
                var billss = await _context.bills.FirstOrDefaultAsync(c => c.Id == id);
                _context.bills.Remove(billss);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<Bill>> GetAllBillAsync()
        {
            return await _context.bills.ToListAsync();
        }

        public async Task<Bill> GetBillByIdAsync(int id)
        {
            return await _context.bills.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdateBillAsync(Bill p)
        {
            try
            {
                _context.bills.Update(p);
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
