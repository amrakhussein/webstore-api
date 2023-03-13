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
                Name = "Product One",
                Description = " simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.",
                ImageSrc = "https://images.unsplash.com/photo-1523275335684-37898b6baf30?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1099&q=80",
                Price = 20,
            },
             new Product
             {
                 Id = 2,
                 Name = "Product Two",
                 Description = " simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.",
                 ImageSrc = "https://images.unsplash.com/photo-1546868871-7041f2a55e12?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=764&q=80",
                 Price = 40,
             },
              new Product
              {
                  Id = 3,
                  Name = "Product Three",
                  Description = " simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.",
                  ImageSrc = "https://plus.unsplash.com/premium_photo-1675431443185-9d40521c8d5c?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=751&q=80",
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
