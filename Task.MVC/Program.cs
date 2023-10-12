using Microsoft.EntityFrameworkCore;
using Task.BLL.DTO;
using Task.BLL.Interfaces;
using Task.BLL.Services;
using Task.DAL.Data;
using Task.DAL.Entities;
using Task.DAL.Interfaces;
using Task.DAL.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Регистрация DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IRepository<Users>, UserRepository>();
builder.Services.AddScoped<IEntityService<UsersDto>, UserService>();
builder.Services.AddScoped<IRepository<Orders>, OrdersRepository>();
builder.Services.AddScoped<IEntityService<OrdersDto>, OrderService>();

builder.Services.AddSingleton<IRabbitMqService, RabbitMqService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();