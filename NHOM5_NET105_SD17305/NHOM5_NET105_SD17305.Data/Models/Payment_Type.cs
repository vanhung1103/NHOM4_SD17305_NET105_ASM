using System.ComponentModel.DataAnnotations;

namespace NHOM5_NET105_SD17305.Data.Models
{
    public class Payment_Type
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Bill> bills { get; set; }
    }
}
