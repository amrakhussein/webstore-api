using System.Diagnostics;

using Microsoft.EntityFrameworkCore;

using SimpleWebStore.Models;

namespace SimpleWebStore.Data;

internal sealed class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Rating> Ratings { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder option)
    {
        option.UseSqlServer("Data Source =.; Initial Catalog = SimpleWebStoreDatabase; Integrated Security = True; TrustServerCertificate=true")
        .LogTo(log => Debug.WriteLine(log));
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Wishlist>()
        .HasMany(wl => wl.Products)
        .WithOne(p => p.Wishlist)
        .HasForeignKey(p => p.WishlistId)
        .OnDelete(DeleteBehavior.Restrict);
        // seed dummy data
        builder.Seed();
    }
}
