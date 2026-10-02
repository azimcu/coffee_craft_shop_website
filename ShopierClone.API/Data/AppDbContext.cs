using Microsoft.EntityFrameworkCore;
using ShopierClone.API.Entities;

namespace ShopierClone.API.Data;

public class AppDbContext : DbContext
{
    // Options parametresine <AppDbContext> tipini açıkça belirttik:
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
}