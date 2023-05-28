using System.ComponentModel.DataAnnotations;

namespace NHOM5_NET105_SD17305.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; }
        public ICollection<User> users { get; set; }
    }
}
