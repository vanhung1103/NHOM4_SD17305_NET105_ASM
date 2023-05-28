using System.ComponentModel.DataAnnotations;

namespace NHOM5_NET105_SD17305.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }  
    }
}
