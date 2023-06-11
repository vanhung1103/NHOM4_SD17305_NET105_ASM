using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NHOM5_NET105_SD17305.Data.Models
{
    public class ExternalLogin
    {
        [Key]
        public int ExternalId { get; set; }
        public int UserId { get; set; }
        public int ProviderId { get; set; }
        public string ProviderKey { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("ProviderId")]
        public ProviderLogin Provider { get; set; }
    }
}
