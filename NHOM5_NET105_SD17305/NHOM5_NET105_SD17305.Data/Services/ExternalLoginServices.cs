using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data.Data;
using NHOM5_NET105_SD17305.Data.IServices;
using NHOM5_NET105_SD17305.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHOM5_NET105_SD17305.Data.Services
{
    public class ExternalLoginServices : IExternalLoginServices
    {
        private readonly FastFoodDbContext _context;
        public ExternalLoginServices(FastFoodDbContext Context)
        {
            _context = Context;
        }
        public async Task<bool> CreateExternalLoginAsync(ExternalLogin p)
        {
            try
            {
                await _context.ExternalLogin.AddAsync(p);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteExternalLoginAsync(int id)
        {
            try
            {
                var payment_Type = await _context.ExternalLogin.FirstOrDefaultAsync(c => c.ExternalId == id);
                _context.ExternalLogin.Remove(payment_Type);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<ExternalLogin>> GetAllExternalLoginAsync()
        {
            return await _context.ExternalLogin.ToListAsync();
        }

        public async Task<ExternalLogin> GetExternalLoginByIdAsync(int id)
        {
            return await _context.ExternalLogin.FirstOrDefaultAsync(c => c.ExternalId == id);
        }

        public async Task<bool> UpdateExternalLoginAsync(ExternalLogin p)
        {
            try
            {
                _context.ExternalLogin.Update(p);
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
