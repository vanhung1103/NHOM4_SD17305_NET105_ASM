using System.ComponentModel.DataAnnotations.Schema;

namespace NHOM5_NET105_SD17305.Models
{
    public class Cart
    {
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public int Description { get; set; }
        public ICollection<CartItem> Items { get; set;}
        public User User { get; set; }
    }
}
