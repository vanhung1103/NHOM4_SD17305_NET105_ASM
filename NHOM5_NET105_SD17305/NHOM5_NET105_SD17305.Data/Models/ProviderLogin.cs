using System.ComponentModel.DataAnnotations;

namespace NHOM5_NET105_SD17305.Data.Models
{
    public class ProviderLogin
    {
        [Key]
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public ICollection<ExternalLogin> ExternalLogin { get; set; }

    }
}
