using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data;
using NHOM5_NET105_SD17305.IServices;
using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.Services
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
                await _context.billItems.AddAsync(p);
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
                var billItem = await _context.billItems.FirstOrDefaultAsync(c => c.Id == id);
                _context.billItems.Remove(billItem);
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
            return await _context.billItems.ToListAsync();
        }

        public async Task<BillItem> GetBillItemByIdAsync(int id)
        {
            return await _context.billItems.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdateBillItemAsync(BillItem p)
        {
            try
            {
                _context.billItems.Update(p);
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
