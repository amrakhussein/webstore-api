using Microsoft.EntityFrameworkCore;

using SimpleWebStore.Data;
using SimpleWebStore.DTOs.customerCart;
using SimpleWebStore.Models;

namespace SimpleWebStore.Repositories;

internal static class CartRepository
{
    internal async static Task<Order> GetCartByIdAsync(int cartId)
    {
        using var db = new ApplicationDbContext();

        return await db.Orders
            .Include(c => c.Items)
            .ThenInclude(ci => ci.Product)
            .FirstOrDefaultAsync(c => c.Id == cartId);
    }


    internal async static Task<(bool success, string message)> PurchaseOrderAsync(CartDto customerCart)
    {

        if (customerCart == null)
            throw new ArgumentNullException(nameof(customerCart));

        // fetch user record from database
        using var db = new ApplicationDbContext();

        // fetch productIds needed for product prices & handling product quantity in stock
        var productIds = customerCart.CartItems.Select(ci => ci.Id).ToList();


        var itemPrice = await ProductRepository.GetProductPricesAsync(productIds);
        // update cartItemsDto however many times were added by the user
        var cartItemsDto = customerCart.CartItems.Select(item => new CartItemDto
        {
            Id = item.Id,
            Price = itemPrice[item.Id],
            Quantity = item.Quantity
        }).ToList();
        customerCart.CartItems = cartItemsDto;

        // create customer Order (Cart) updating the cart items ready for the database schema
        var cart = new Order
        {
            CustomerId = customerCart.CustomerId,
            Items = cartItemsDto.Select(ci => new OrderItem
            {
                ProductId = ci.Id,
                Price = ci.Price,
                Quantity = ci.Quantity,
            }).ToList(),
            Total = cartItemsDto.Sum(c => c.TotalPrice)
        };


        // update products quantity
        var productUpdated = await ProductRepository.UpdateProductsQuantityAsync(productIds, customerCart);

        if (productUpdated.success)
        {
            // update database with customer Order
            db.Orders.Add(cart);
            await db.SaveChangesAsync();
        }

        return productUpdated;
    }
}
