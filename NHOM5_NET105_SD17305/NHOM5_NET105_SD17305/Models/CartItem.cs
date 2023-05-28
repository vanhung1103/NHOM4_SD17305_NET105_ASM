using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NHOM5_NET105_SD17305.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CartId")]
        public int CartId { get; set; }
        [ForeignKey("ProductId")]

        public int ProductId { get; set; }
        [ForeignKey("CombosId")]

        public int CombosId { get; set; } 
        public int Quantity { get; set; }
        public int Price { get; set; }

        public Product Product { get; set; }
        public Combos Combos { get; set; }
        public Cart Cart { get; set; }
    }
}
