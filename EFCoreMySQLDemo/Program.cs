using Microsoft.EntityFrameworkCore;
using EFCoreMySQLDemo;
using EFCoreMySQLDemo.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;  // <-- Add this for Pomelo MySQL

var builder = WebApplication.CreateBuilder(args);

// Configure MySQL connection string (replace with your actual MySQL credentials)
var connectionString = "Server=localhost;Database=EFCoreDemo;User=root;Password=Know@9999#;";

// Add DbContext service to DI container
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));  // <-- Use MySQL extension method for Pomelo

var app = builder.Build();

// using (var scope = app.Services.CreateScope())
// {
//     var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    
//     // Apply migrations and create the table if not already created
//     dbContext.Database.Migrate();
    
//     // Add sample data if the Products table is empty
//     if (!dbContext.Products.Any())
//     {
//         dbContext.Products.Add(new Product { Name = "Apple", Price = 0.99m });
//         dbContext.Products.Add(new Product { Name = "Banana", Price = 1.29m });
//         dbContext.SaveChanges();
//     }
// }

// Ensure the database is created and apply migrations
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();  // Applies any pending migrations automatically
}

app.Run();
