using BlackPieShop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>();
builder.Services.AddScoped<IPieRepository, MockPieRepository>();

builder.Services.AddDbContext<BlackPieDbContext>(options => {
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:BlackPieDbContextConnection"]);
    });

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();

app.Run();
