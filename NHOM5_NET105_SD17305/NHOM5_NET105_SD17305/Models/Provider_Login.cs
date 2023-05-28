using System.ComponentModel.DataAnnotations;

namespace NHOM5_NET105_SD17305.Models
{
    public class Provider_Login
    {
        [Key]
        public int Id { get; set; }
        public string ProviderName { get; set; }
        public ICollection<External_Login> ExternalLogin { get; set; }
    }
}
