using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data.Data;
using NHOM5_NET105_SD17305.Data.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHOM5_NET105_SD17305.Data.Services
{
    public class RoleServices : IRoleServices
    {
        private readonly FastFoodDbContext _context;

        public RoleServices(FastFoodDbContext context)
        {
            _context = context;
        }
        public async Task<string> GetRoleName(int id)
        {
              var role =  await _context.Roles.FirstOrDefaultAsync(c => c.Id == id);
            var roleName = role.Name;
            return roleName;
        }             

    }
}
