using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data;
using NHOM5_NET105_SD17305.IServices;
using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.Services
{
    public class BillStatusServices: IBillStatusServices
    {
        private readonly FastFoodDbContext _context;
        public BillStatusServices(FastFoodDbContext Context)
        {
            _context = Context;
        }

        public async Task<bool> CreateBillStatusAsync(BillStatus p)
        {
            try
            {
                await _context.billStatuses.AddAsync(p);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteBillStatusAsync(int id)
        {
            try
            {
                var billStatus = await _context.billStatuses.FirstOrDefaultAsync(c => c.Id == id);
                _context.billStatuses.Remove(billStatus);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<BillStatus>> GetAllBillStatusAsync()
        {
            return await _context.billStatuses.ToListAsync();
        }

        public async Task<BillStatus> GetBillStatusByIdAsync(int id)
        {
            return await _context.billStatuses.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdateBillStatusAsync(BillStatus p)
        {
            try
            {
                _context.billStatuses.Update(p);
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
