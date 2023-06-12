    using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data.Data;
using NHOM5_NET105_SD17305.Data.IServices;
using NHOM5_NET105_SD17305.Data.Models;

namespace NHOM5_NET105_SD17305.Data.Services
{
    public class AddressServices:IAddressServices
    {

        private readonly FastFoodDbContext _context;
        public AddressServices(FastFoodDbContext Context)
        {
            _context = Context;
        }
        public async Task<bool> CreateAddressAsync(Address p)
        {
            try
            {
                await _context.Addresses.AddAsync(p);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteAddressAsync(int id)
        {
            try
            {
                var address = await _context.Addresses.FirstOrDefaultAsync(c => c.Id == id);
                _context.Addresses.Remove(address);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<Address> GetAddressByIdAsync(int id)
        {
            return await _context.Addresses.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Address>> GetAllAddressAsync()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<bool> UpdateAddressAsync(Address p)
        {
                try
                {
                    _context.Addresses.Update(p);
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
