using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data.Data;
using NHOM5_NET105_SD17305.Data.IServices;
using NHOM5_NET105_SD17305.Data.Models;

namespace NHOM5_NET105_SD17305.Data.Services
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
                await _context.BillStatus.AddAsync(p);
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
                var billStatus = await _context.BillStatus.FirstOrDefaultAsync(c => c.Id == id);
                _context.BillStatus.Remove(billStatus);
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
            return await _context.BillStatus.ToListAsync();
        }

        public async Task<BillStatus> GetBillStatusByIdAsync(int id)
        {
            return await _context.BillStatus.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdateBillStatusAsync(BillStatus p)
        {
            try
            {
                _context.BillStatus.Update(p);
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
