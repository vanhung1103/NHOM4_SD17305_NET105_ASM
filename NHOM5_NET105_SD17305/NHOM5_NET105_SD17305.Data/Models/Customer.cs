using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NHOM5_NET105_SD17305.Data.Models
{
    public class Customer
    {
        [Key, ForeignKey("Users")]
        public string UserId { get; set; } 
        public string Gender { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public DateTime Dob { get; set; } 
        public string Phone { get; set; } 
        public string email { get; set; } 
        public string Image { get; set; } 
   
        public IdentityUser Users { get; set; }
        public ICollection<Address> Addresses { get;}
    }
}
