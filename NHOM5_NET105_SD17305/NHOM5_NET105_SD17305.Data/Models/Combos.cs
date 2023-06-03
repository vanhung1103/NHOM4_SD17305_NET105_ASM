namespace NHOM5_NET105_SD17305.Data.Models
{
    public class Combos
    {
        public int Id { get; set; }
        public string CombosPrice { get; set; }
        public string CombosName { get; set; }
        public double Discount { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public ICollection<BillItem> BillItems { get; set; }
        public ICollection<CombosItem> CombosItems { get; set; }

    }
}
