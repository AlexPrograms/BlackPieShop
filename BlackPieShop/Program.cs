using BlackPieShop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();

builder.Services.AddDbContext<BlackPieDbContext>(options => {
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:BlackPieDbContextConnection"]);
    });

var app = builder.Build();

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();
DbInitializer.Seed(app);
app.Run();
