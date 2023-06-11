using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NHOM5_NET105_SD17305.Data.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<Role> Role { get; set; }


    }
}
