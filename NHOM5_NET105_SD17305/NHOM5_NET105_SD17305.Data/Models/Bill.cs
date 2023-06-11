using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NHOM5_NET105_SD17305.Data.Models
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UserId")]

        public int UserId { get; set; }
        [ForeignKey("BillStatus_Id")]
        public int BillStatus_Id { get; set; }
        [ForeignKey("Payment_Type_Id")]

        public int Payment_Type_Id { get; set; }
        public string RecipientAddress { get; set; }
        public string RecipientName { get; set; }
        public string RecipientPhone { get; set; }
        public float Discount { get; set; }
        public string ShippingFee { get; set; }
        public int TotalAmount { get; set; }
        public DateTime Create_Date { get; set; }
        public DateTime Payment_date { get; set; }
        public DateTime Delivery_date { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public BillStatus BillStatus { get; set; }
        public ICollection<BillItem> BillItem { get; set; }
        public Payment_Type Payment_Type { get; set; }
    }
}
