using Microsoft.EntityFrameworkCore;

using SimpleWebStore.Data;
using SimpleWebStore.DTOs;
using SimpleWebStore.Models;

namespace SimpleWebStore.Repositories;

internal static class ProductRepository
{
    internal async static Task<IEnumerable<Product>> GetProductsAsync()
    {
        using var db = new ApplicationDbContext();
        return await db.Products.ToListAsync();
    }

    internal async static Task<(bool success, string message)> UpdateProductsQuantityAsync(IEnumerable<int> productIds, CartDto customerCart)
    {
        using var db = new ApplicationDbContext();
        var products = await db.Products.Where(p => productIds.Contains(p.Id)).ToListAsync();

        var productQuantity = 0;
        var orderSuceeded = true;

        foreach (var product in products)
        {
            var cartItem = customerCart.CartItems.FirstOrDefault(ci => ci.Id == product.Id);

            // return false when there is not sufficient producst or cart item doesnot exist
            if (cartItem is null && cartItem.Quantity > product.Quantity)
            {
                orderSuceeded = false;
                return (false, $"Insufficient quantity for product with Id: {product.Id}, try again later");
            }


            productQuantity += cartItem.Quantity;

            // decrement product quantity records according per customer items
            product.Quantity -= cartItem.Quantity;
        }

        // Undo product quantity records update when order failed
        if (!orderSuceeded)
        {
            foreach (var product in products)
            {
                product.Quantity += productQuantity;
            }
        }

        await db.SaveChangesAsync();
        return (true, "Product quantities updated successfully");
    }

}
