using BlackPieShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BlackPieDbContextConnection") ?? throw new InvalidOperationException("Connection string 'BlackPieDbContextConnection' not found.");

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<BlackPieDbContext>(options => {
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:BlackPieDbContextConnection"]);
    });

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<BlackPieDbContext>();

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();
app.UseAuthentication();

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US"),
    SupportedCultures = new List<CultureInfo> { new CultureInfo("en-US") },
    SupportedUICultures = new List<CultureInfo> { new CultureInfo("en-US") },
});

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();
app.MapRazorPages();


DbInitializer.Seed(app);
app.Run();
