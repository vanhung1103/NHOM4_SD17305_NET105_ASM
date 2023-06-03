using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data.Data;
using NHOM5_NET105_SD17305.Data.IServices;
using NHOM5_NET105_SD17305.Data.Models;

namespace NHOM5_NET105_SD17305.Data.Services
{
    public class BillItemServices : IBillItemServices
    {
        private readonly FastFoodDbContext _context;
        public BillItemServices(FastFoodDbContext Context)
        {
            _context = Context;
        }

        public async Task<bool> CreateBillItemAsync(BillItem p)
        {
            try
            {
                await _context.BillItems.AddAsync(p);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteBillItemAsync(int id)
        {
            try
            {
                var billItem = await _context.BillItems.FirstOrDefaultAsync(c => c.Id == id);
                _context.BillItems.Remove(billItem);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<BillItem>> GetAllBillItemAsync()
        {
            return await _context.BillItems.ToListAsync();
        }

        public async Task<BillItem> GetBillItemByIdAsync(int id)
        {
            return await _context.BillItems.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdateBillItemAsync(BillItem p)
        {
            try
            {
                _context.BillItems.Update(p);
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
