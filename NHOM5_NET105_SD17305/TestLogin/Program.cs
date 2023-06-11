using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NHOM5_NET105_SD17305.Data.Data;
using NHOM5_NET105_SD17305.Data.IServices;
using NHOM5_NET105_SD17305.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<FastFoodDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("FastFood"), c => c.MigrationsAssembly("NHOM5_NET105_SD17305.Views"));
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Home/Index";
        options.AccessDeniedPath = "/SignIn/AccessDenied";
        options.Cookie.Name = "SignInCookie";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    });

builder.Services.AddTransient<ICombosServices, CombosServices>();
builder.Services.AddTransient<ICategoryServices, CategoryServices>();
builder.Services.AddTransient<IPromotionServices, Promotionservices>();
builder.Services.AddTransient<IPromotionItemServices, PromotionItemservices>();
builder.Services.AddTransient<IcartItemServices, CartItemServices>();
builder.Services.AddTransient<IProductServices, ProductServices>();
builder.Services.AddTransient<ICombosItemServices, CombosItemServices>();
//builder.Services.AddTransient<IUserServices, UserServices>();
//builder.Services.AddIdentity<IdentityUser, IdentityRole>()
//    .AddEntityFrameworkStores<FastFoodDbContext>()
//    .AddDefaultTokenProviders();
////Đăng ký UserManager<IdentityUser>
//builder.Services.AddScoped<UserManager<IdentityUser>>();
//builder.Services.AddScoped<SignInManager<IdentityUser>>();

builder.Services.AddHttpClient();

// add session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
});

// Add HttpContextAccessor
builder.Services.AddHttpContextAccessor();

// Add Notyf
builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 3;
    config.IsDismissable = true;
    config.Position = NotyfPosition.TopRight;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseAuthentication();
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
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
