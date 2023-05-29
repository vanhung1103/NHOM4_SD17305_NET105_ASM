using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NHOM5_NET105_SD17305.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public string Passworf { get; set; }
        public Role Role { get; set; }
        public ICollection<External_Login> external_Logins { get; set; }
        public Customer customers { get; set; }
        public ICollection<Bill> Bills { get; set; }
        public ICollection<Cart> carts { get; set; }

    }
}
