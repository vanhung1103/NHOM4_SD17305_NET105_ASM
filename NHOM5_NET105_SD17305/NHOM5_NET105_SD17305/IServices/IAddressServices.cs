﻿using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.IServices
{
    public interface IAddressServices
    {
        public Task<bool> CreateAddressAsync(Address p);

        public Task<bool> UpdateAddressAsync(Address p);
        public Task<bool> DeleteAddressAsync(int id);
        public Task<Address> GetAddressByIdAsync(int id);
       
        public Task<List<Address>> GetAllAddressAsync();
    }
}
