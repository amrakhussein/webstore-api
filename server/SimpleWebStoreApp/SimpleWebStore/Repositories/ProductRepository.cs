﻿using Microsoft.EntityFrameworkCore;

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

    internal async static Task<IEnumerable<Product>> GetProductsByIdAsync(int id)
    {
        using var db = new ApplicationDbContext();
        return await db.Products.Where(p => p.Id == id).ToListAsync();
    }

    internal async static Task<Dictionary<int, decimal>> GetProductPricesAsync(IEnumerable<int> productIds)
    {
        using var db = new ApplicationDbContext();
        var productPrices = await db.Products
            .Where(p => productIds.Contains(p.Id))
            .Select(p => new { p.Id, p.Price })
            .ToDictionaryAsync(p => p.Id, p => p.Price);
        return productPrices;
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
            if (cartItem is null)
            {
                orderSuceeded = false;
                return (false, "Error occured to cartItem. Try again later");
            }

            if (cartItem.Quantity > product.Quantity || cartItem.Quantity < 0)
            {
                orderSuceeded = false;
                return (false, $"Insufficient or invalid quantity for product: {product.Name}. Try again later");
            }

            if (cartItem.Quantity is 0)
            {
                orderSuceeded = false;
                return (false, $"Please specify quantity for product: {product.Name}. Try again later");
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
        return (true, "Your Order has confirmed successfully");
    }

}