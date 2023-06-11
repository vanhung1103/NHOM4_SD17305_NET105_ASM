using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NHOM5_NET105_SD17305.Data.Data;
using NHOM5_NET105_SD17305.Data.IServices;
using NHOM5_NET105_SD17305.Data.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddNotyf(config => { config.DurationInSeconds = 3; config.IsDismissable = true; config.Position = NotyfPosition.TopRight; });
// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<FastFoodDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("FastFood"), c => c.MigrationsAssembly("NHOM5_NET105_SD17305.Views"));
});
// Add Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<FastFoodDbContext>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<ICombosServices, CombosServices>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<IPromotionServices, Promotionservices>();
builder.Services.AddScoped<IPromotionItemServices, PromotionItemservices>();
builder.Services.AddScoped<CombosServices>();
builder.Services.AddScoped<IcartItemServices, CartItemServices>();
builder.Services.AddScoped<CartItemServices>();


builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<ProductServices>();

builder.Services.AddScoped<ICombosItemServices, CombosItemServices>();
builder.Services.AddScoped<CombosItemServices>();
builder.Services.AddHttpClient();
// add session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(1);
});
//add httpcontextaccessor
builder.Services.AddHttpContextAccessor();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseNotyf();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
   name: "default",
    pattern: "{controller=Home}/{action=Home}/{id?}");
});
app.Run();
