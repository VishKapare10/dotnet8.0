using Microsoft.EntityFrameworkCore;
using EFCoreMySQLDemo.Models;

namespace EFCoreMySQLDemo
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }
    }
}
