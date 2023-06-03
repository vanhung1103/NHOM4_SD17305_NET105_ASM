using System.ComponentModel.DataAnnotations;

namespace NHOM5_NET105_SD17305.Data.Models
{
    public class Promotion
    {
        [Key]
        public int Id { get; set; }
        public int PromotionName { get; set; }
        public DateTime Create_Date { get; set; }
        public DateTime End_Date { get; set; }
        public ICollection<PromotionItem> promotionItems { get; set; }

    }
}
