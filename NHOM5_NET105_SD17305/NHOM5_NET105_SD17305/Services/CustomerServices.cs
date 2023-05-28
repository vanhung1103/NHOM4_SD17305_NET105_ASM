﻿using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data;
using NHOM5_NET105_SD17305.IServices;
using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly FastFoodDbContext _context;
        public CustomerServices(FastFoodDbContext Context)
        {
            _context = Context;
        }
        public async Task<bool> CreateCustomerAsync(Customer p)
        {
            try
            {
                await _context.customers.AddAsync(p);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            try
            {
                var product = await _context.customers.FirstOrDefaultAsync(c => c.UserId == id);
                _context.customers.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<Customer>> GetAllCustomerAsync()
        {
            return await _context.customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _context.customers.FirstOrDefaultAsync(c => c.UserId == id);
        }

        public async Task<bool> UpdateCustomerAsync(Customer p)
        {
            try
            {
                _context.customers.Update(p);
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
