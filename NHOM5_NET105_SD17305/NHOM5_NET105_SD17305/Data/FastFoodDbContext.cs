using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Models;

namespace NHOM5_NET105_SD17305.Data
{
    public class FastFoodDbContext : DbContext
    {
        public FastFoodDbContext(DbContextOptions options) : base(options)
        {
        }

        protected FastFoodDbContext()
        {
        }
        #region // 1 con ga
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<BillItem> billItems { get; set; }
        public DbSet<CartItem> cartItems { get; set; }
        public DbSet<CombosItem> combositems { get; set; }
        public DbSet<PromotionItem> promotionItems { get; set; }
        public DbSet<Bill> bills { get; set; }
        public DbSet<BillStatus> billStatuses { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<Combos> combos { get; set; }
        public DbSet<External_Login> external_Logins { get; set; }
        public DbSet<Payment_Type> payment_Types { get; set; }
        public DbSet<Promotion> promotions { get; set; }
        public DbSet<Provider_Login> provider_Logins { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Customer> customers { get; set; }

        #endregion 
    }
}
