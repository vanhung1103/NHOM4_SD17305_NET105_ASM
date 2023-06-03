using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NHOM5_NET105_SD17305.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; } 
        public int? Cate_Id { get; set; } 
        public string ProductName { get; set; } 
        public int Quantity { get; set; } 
        public int Price { get; set; } 
        public int Weight { get; set; } 
        public string Image { get; set; } 
        public string Descriptions { get; set; } 
        public string LongDescription { get; set; }
        [ForeignKey("Cate_Id")]
        [Required] 
        
        public Category Category { get; set; }
        public  ICollection<CombosItem> CombosItem { get; set; }
        public ICollection<PromotionItem> promotionItems { get; set; }
        public ICollection<CartItem> cartItems { get; set; }
        public ICollection<BillItem> billItems { get; set; }
    }
}
