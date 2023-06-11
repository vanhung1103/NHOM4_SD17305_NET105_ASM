using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data.Models;

namespace NHOM5_NET105_SD17305.Data.Data
{
    public class FastFoodDbContext : DbContext
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
            modelBuilder.Entity<Role>().HasData(
                new Role() {Id=1, Name = "Admin" },// create 2 role là admin và user
                new Role() { Id = 2, Name = "User" }
                );
            modelBuilder.Entity<ProviderLogin>().HasData(
                new ProviderLogin() { ProviderId = 1, ProviderName = "Google" },// create google
                new ProviderLogin() { ProviderId = 2, ProviderName = "Facebook" }
                );
            modelBuilder.Entity<Payment_Type>().HasData(
                new Payment_Type() {Id=1, Name = "Khi nhận hàng" },
                new Payment_Type() {Id=2, Name = "Online" }
                );
            modelBuilder.Entity<BillStatus>().HasData(
                new BillStatus() {Id=1, Name = "Chờ thanh toán" },
                new BillStatus() {Id=2, Name = "Chờ xác nhận" },
                new BillStatus() {Id=3, Name = "Đang giao hàng" },
                new BillStatus() {Id=4, Name = "Đã nhận hàng" },
                new BillStatus() {Id=5, Name = "Hủy đơn" },
                new BillStatus() {Id=6, Name = "Trả hàng" }
                );
        }
        #region DbSet
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<BillItem> BillItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<CombosItem> CombosItems { get; set; }
        public DbSet<PromotionItem> PromotionItems { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillStatus> BillStatus { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Combos> Combos { get; set; }
        public DbSet<ExternalLogin> ExternalLogin { get; set; }
        public DbSet<Payment_Type> Payment_Types { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<ProviderLogin> ProviderLogin { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }

        #endregion 
    }
}
