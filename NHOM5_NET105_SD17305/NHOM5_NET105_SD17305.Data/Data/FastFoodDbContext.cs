using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data.Models;

namespace NHOM5_NET105_SD17305.Data.Data
{
    public class FastFoodDbContext : IdentityDbContext<IdentityUser>
    {
        public FastFoodDbContext(DbContextOptions options) : base(options)
        {
        }

        protected FastFoodDbContext()
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            CreateRoles(builder);// chạy hàm tạo role
        }
        public void CreateRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = "Admin", NormalizedName = "ADMIN" },// create 2 role là admin và user
                new IdentityRole() { Name = "User", NormalizedName = "USER" }
                );
        }
        #region DbSet
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BillItem> BillItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<CombosItem> CombosItems { get; set; }
        public DbSet<PromotionItem> PromotionItems { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillStatus> BillStatuses { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Combos> Combos { get; set; }
        //public DbSet<External_Login> external_Logins { get; set; }
        public DbSet<Payment_Type> Payment_Types { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        //public DbSet<Provider_Login> provider_Logins { get; set; }
        //public DbSet<Role> roles { get; set; }
        //public DbSet<User> users { get; set; }
        public DbSet<Customer> Customers { get; set; }

        #endregion 
    }
}
