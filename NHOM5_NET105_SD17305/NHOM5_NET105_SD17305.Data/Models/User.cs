using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NHOM5_NET105_SD17305.Data.Models
{
    public class User
    {
        // thêm các cái khác
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
