    using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data;
using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.Services
{
    public class AddressServices
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
                await _context.addresses.AddAsync(p);
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
                var address = await _context.addresses.FirstOrDefaultAsync(c => c.Id == id);
                _context.addresses.Remove(address);
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
            return await _context.addresses.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Address>> GetAllAddressAsync()
        {
            return await _context.addresses.ToListAsync();
        }

        public async Task<bool> UpdateAddressAsync(Address p)
        {
                try
                {
                    _context.addresses.Update(p);
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
