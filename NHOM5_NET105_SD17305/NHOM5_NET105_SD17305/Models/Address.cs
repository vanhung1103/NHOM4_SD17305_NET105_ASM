using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NHOM5_NET105_SD17305.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Street { get; set; }

        public Customer Customer { get; set; }
    }
}
