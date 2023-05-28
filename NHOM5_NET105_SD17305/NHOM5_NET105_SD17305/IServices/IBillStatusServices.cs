﻿using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.IServices
{
    public interface IBillStatusServices
    {
        public Task<bool> CreateBillStatusAsync(BillStatus p);

        public Task<bool> UpdateBillStatusAsync(BillStatus p);
        public Task<bool> DeleteBillStatusAsync(int id);
        public Task<BillStatus> GetBillStatusByIdAsync(int id);

        public Task<List<BillStatus>> GetAllBillStatusAsync();
    }
}
