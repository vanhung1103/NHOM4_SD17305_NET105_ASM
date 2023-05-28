using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.IServices
{
    public interface IPromotionServices
    {
        public Task<bool> CreatePromotionAsync(Promotion p);

        public Task<bool> UpdatePromotionAsync(Promotion p);
        public Task<bool> DeletePromotionAsync(int id);
        public Task<Promotion> GetPromotionByIdAsync(int id);

        public Task<List<Promotion>> GetAllPromotionAsync();
    }
}
