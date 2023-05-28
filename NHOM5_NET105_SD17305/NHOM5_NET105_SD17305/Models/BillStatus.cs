using System.ComponentModel.DataAnnotations;

namespace NHOM5_NET105_SD17305.Models
{
    public class BillStatus
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Bill> Bills { get; set; }
    }
}
