using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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
builder.Services.AddHttpClient();
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
	.AddEntityFrameworkStores<FastFoodDbContext>().AddDefaultTokenProviders();
builder.Services.AddScoped<IExternalLoginServices, ExternalLoginServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IRoleServices, RoleServices>();
builder.Services.AddScoped<IProviderLoginServices, ProviderLoginServices>();
builder.Services.AddScoped<ICombosServices, CombosServices>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<IPromotionServices, Promotionservices>();
builder.Services.AddScoped<IPromotionItemServices, PromotionItemservices>();
builder.Services.AddScoped<IcartItemServices, CartItemServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<ICombosItemServices, CombosItemServices>();
builder.Services.AddScoped<ICartServices, CartServices>();
builder.Services.AddScoped<IBillServices, BillServices>();
builder.Services.AddScoped<IBillStatusServices, BillStatusServices>();
builder.Services.AddScoped<IBillItemServices, BillItemServices>();
builder.Services.AddScoped<IPayment_TypeServices, Payment_TypeServices>();
builder.Services.AddScoped<IVnPayService, VnPayService>();
builder.Services.AddHttpClient();
// add session
builder.Services.AddHttpContextAccessor();
// add session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.IdleTimeout = TimeSpan.FromDays(1);
});
builder.Services.AddAuthentication(options => {
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme =GoogleDefaults.AuthenticationScheme;
})
    .AddCookie(options =>
    {
        options.LoginPath = "/SignIn/SignIn";
        options.AccessDeniedPath = "/SignIn/AccessDenied";
        options.Cookie.Name = "SignInCookie";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    })
  .AddGoogle(options =>
  {     // Đọc thông tin Authentication:Google
      IConfigurationSection googleAuthNSection = builder.Configuration.GetSection("Authentication:Google");
      // Thiết lập ClientID và ClientSecret để truy cập API google
      options.ClientId = googleAuthNSection["ClientId"];
      options.ClientSecret = googleAuthNSection["ClientSecret"];
      // Cấu hình Url callback lại từ Google (không thiết lập thì mặc định là /signin-google)
      options.CallbackPath = "/signin-google";
  });
//add httpcontextaccessor
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
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
   name: "default",
    pattern: "{controller=SignIn}/{action=SignIn}/{id?}");
});
app.Run();
