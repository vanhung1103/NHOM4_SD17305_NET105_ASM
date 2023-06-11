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
    public class ProviderLoginServices : IProviderLoginServices
    {
        private readonly FastFoodDbContext _context;

        public ProviderLoginServices(FastFoodDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProviderLogin>> GetAllProviderLogin()
        {
            return await _context.ProviderLogin.ToListAsync();
        }
    }
}
