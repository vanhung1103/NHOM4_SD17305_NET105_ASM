using NHOM5_NET105_SD17305.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHOM5_NET105_SD17305.Data.IServices
{
    public interface IProviderLoginServices
    {
        public Task<List<ProviderLogin>> GetAllProviderLogin();
    }
}
