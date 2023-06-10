using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace NHOM5_NET105_SD17305.Data.Models
{
    public class ProductImage
    {

        [Key]
        public int ProductId { get; set; }
        public int? Cate_Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Weight { get; set; }
        public string Descriptions { get; set; }
        public string LongDescription { get; set; }
        public IFormFile Image;
        
    }
}
