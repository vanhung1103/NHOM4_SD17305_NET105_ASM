using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NHOM5_NET105_SD17305.Data.Models
{
    public class BillItem
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Bill_Id")]
        public int Bill_Id { get; set; }
        [ForeignKey("ProductId")]

        public int? ProductId { get; set; }
        [ForeignKey("CombosId")]

        public int? CombosId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public Product Product { get; set; }
        public Bill Bills { get; set; }

        public Combos Combos { get; set; }
       
    }
}
