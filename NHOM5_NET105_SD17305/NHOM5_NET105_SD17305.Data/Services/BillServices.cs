using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data.Data;
using NHOM5_NET105_SD17305.Data.IServices;
using NHOM5_NET105_SD17305.Data.Models;

namespace NHOM5_NET105_SD17305.Data.Services
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
                await _context.Bills.AddAsync(p);
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
                var billss = await _context.Bills.FirstOrDefaultAsync(c => c.Id == id);
                _context.Bills.Remove(billss);
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
            return await _context.Bills.ToListAsync();
        }

        public async Task<Bill> GetBillByIdAsync(int id)
        {
            return await _context.Bills.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdateBillAsync(Bill p)
        {
            try
            {
                _context.Bills.Update(p);
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
