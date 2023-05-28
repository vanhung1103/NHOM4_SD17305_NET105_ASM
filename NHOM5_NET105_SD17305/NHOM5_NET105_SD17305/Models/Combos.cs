namespace NHOM5_NET105_SD17305.Models
{
    public class Combos
    {
        public int Id { get; set; }
        public string CombosPrice { get; set; }
        public string CombosName { get; set; }
        public double Discount { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string longDescription { get; set; }
        public ICollection<CartItem> cartItems { get; set; }
        public ICollection<BillItem> billItems { get; set; }
        public ICollection<CombosItem> combositem { get; set; }

    }
}
