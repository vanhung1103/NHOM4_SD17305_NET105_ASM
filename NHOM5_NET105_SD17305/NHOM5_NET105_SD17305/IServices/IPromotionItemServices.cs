using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.IServices
{
    public interface IPromotionItemServices
    {
        public Task<bool> CreatePromotionItemAsync(PromotionItem p);

        public Task<bool> UpdatePromotionItemAsync(PromotionItem p);
        public Task<bool> DeletePromotionItemAsync(int id);
        public Task<PromotionItem> GetPromotionItemByIdAsync(int id);

        public Task<List<PromotionItem>> GetAllPromotionItemAsync();
    }
}
