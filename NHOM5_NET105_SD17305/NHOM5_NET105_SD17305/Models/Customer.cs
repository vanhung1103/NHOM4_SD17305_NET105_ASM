using System.ComponentModel.DataAnnotations;

namespace NHOM5_NET105_SD17305.Models
{
    public class Customer
    {
        [Key]
        public int UserId { get; set; } 
        public string Gender { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public DateTime Dob { get; set; } 
        public string Phone { get; set; } 
        public string email { get; set; } 
        public string Image { get; set; } 
   
        public User users { get; set; }
        public ICollection<Address> addresses { get;}
    }
}
