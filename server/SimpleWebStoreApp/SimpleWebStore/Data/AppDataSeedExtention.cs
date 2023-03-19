using Microsoft.EntityFrameworkCore;

using SimpleWebStore.Models;

namespace SimpleWebStore.Data;

internal static class AppDataSeedExtention
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(
        new Customer
        {
            Id = 1,
            FirstName = "Amr",
            LastName = "Abdelkamel",
        });


        for (int i = 1; i < 40; i++)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = i,
                    Name = ProductsDummyData.Names[new Random().Next(ProductsDummyData.Names.Length)],
                    Description = ProductsDummyData.Descriptions[new Random().Next(ProductsDummyData.Descriptions.Length)],
                    Price = ProductsDummyData.Prices[new Random().Next(ProductsDummyData.Prices.Length)],
                    ImageSrc = ProductsDummyData.ImageSrcs[new Random().Next(ProductsDummyData.ImageSrcs.Length)],
                    AverageRatings = ProductsDummyData.AverageRatings[new Random().Next(ProductsDummyData.AverageRatings.Length)]
                });
        }

        modelBuilder.Entity<Cart>().HasData(
            new Cart
            {
                Id = 1,
                Total = 20,
                CustomerId = 1,
            },
            new Cart
            {
                Id = 2,
                Total = 80,
                CustomerId = 1,
            },
            new Cart
            {
                Id = 3,
                Total = 120,
                CustomerId = 1,
            });

        var rand = new Random();
        for (int i = 1; i <= 12; i++)
        {
            var quantity = rand.Next(1, 4);
            var price = (decimal)rand.Next(1000, 10000) / 100;
            var productId = rand.Next(1, 4);
            var cartId = rand.Next(1, 4);

            modelBuilder.Entity<CartItem>().HasData(
                new CartItem
                {
                    Id = i,
                    CartId = cartId,
                    ProductId = productId,
                    Price = price,
                    Quantity = quantity
                }
            );
        }
    }
}
