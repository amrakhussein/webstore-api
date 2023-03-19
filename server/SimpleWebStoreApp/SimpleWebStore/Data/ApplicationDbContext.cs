using System.Diagnostics;

using Microsoft.EntityFrameworkCore;

using SimpleWebStore.Models;

namespace SimpleWebStore.Data;

internal sealed class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Rating> Ratings { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder option)
    {
        option.UseSqlServer("Data Source =.; Initial Catalog = SimpleWebStoreDatabase; Integrated Security = True; TrustServerCertificate=true")
        .LogTo(log => Debug.WriteLine(log));
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // seed dummy data
        builder.Seed();
    }
}
