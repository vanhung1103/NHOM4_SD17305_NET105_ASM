using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NHOM5_NET105_SD17305.Models
{
    public class CombosItem
    {
        [Key]
        public int CombosItemId { get; set; }
        [ForeignKey("CombosId")]
        public int CombosId { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public Combos Combos { get; set; }
        public Product product { get; set; }
    }
}
