using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHOM5_NET105_SD17305.Data.Models
{
    public class CartItem1
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CartId")]
        public int CartId { get; set; }


        [ForeignKey("ProductId")]

        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        [ForeignKey("CombosId")]

        public int? CombosId { get; set; }
        public string CombosName { get; set; }
        public int CombosPrice { get; set; }
        public int CombosQuantity { get; set; }
        public string CombosImage { get; set; }
        public Product Product { get; set; }
        public Combos Combos { get; set; }
        public Cart Cart { get; set; }
        public CartItem1()
        {
        }
        public CartItem1(Combos combos)
        {
            CombosId = combos.Id;
            CombosName = combos.CombosName;
            CombosPrice = combos.CombosPrice;
            CombosQuantity = 1;
            CombosImage = combos.Image;
        }
    }
}
