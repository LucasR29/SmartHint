using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using SmartHint.Data;
using SmartHint.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var config = builder.Configuration;

var serverVersion = new MySqlServerVersion(new Version(8, 0, 33));

builder.Services.AddEntityFrameworkMySql()
    .AddDbContext<SmartHintContext>(n => n
    .UseMySql(config.GetConnectionString("Default"), serverVersion)
    .LogTo(Console.WriteLine, LogLevel.Information)
    );

builder.Services.AddScoped<IClientsRepository, ClientsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
