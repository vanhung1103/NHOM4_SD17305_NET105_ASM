using NHOM5_NET105_SD17305.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHOM5_NET105_SD17305.Data.IServices
{
    public interface IExternalLoginServices
    {
        public Task<bool> CreateExternalLoginAsync(ExternalLogin p);

        public Task<bool> UpdateExternalLoginAsync(ExternalLogin p);
        public Task<bool> DeleteExternalLoginAsync(int id);
        public Task<ExternalLogin> GetExternalLoginByIdAsync(int id);

        public Task<List<ExternalLogin>> GetAllExternalLoginAsync();

    }
}
