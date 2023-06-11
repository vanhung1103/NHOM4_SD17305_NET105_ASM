using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NHOM5_NET105_SD17305.Data.Models
{
    public class PromotionItem
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("PromotionId")]
        public int PromotionId { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

        public Promotion Promotion { get; set; }
        public Product Product { get; set; }
    }
}
