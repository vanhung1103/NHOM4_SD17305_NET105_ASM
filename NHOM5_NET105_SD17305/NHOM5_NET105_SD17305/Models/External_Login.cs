using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NHOM5_NET105_SD17305.Models
{
    public class External_Login
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UserId")] 
        
        public int UserId { get; set; }
        [ForeignKey("ProviderId")]

        public int ProviderId { get; set; } 
        public int ProviderKey { get; set; } 
        public User User { get; set; }
        public  Provider_Login Provider_Login { get; set; }
    }
}
