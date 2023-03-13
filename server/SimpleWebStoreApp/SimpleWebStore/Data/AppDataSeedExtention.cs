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


        modelBuilder.Entity<Product>().HasData(

            new Product
            {
                Id = 1,
                Description = "Some random description",
                Name = "Product One",
                Price = 20,
            },
             new Product
             {
                 Id = 2,
                 Description = "Some random description",
                 Name = "Product Two",
                 Price = 40,
             },
              new Product
              {
                  Id = 3,
                  Description = "Some random description",
                  Name = "Product Three",
                  Price = 60,
              });



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
