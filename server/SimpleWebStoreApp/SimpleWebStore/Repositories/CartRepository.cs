using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SimpleWebStore.Data;
using SimpleWebStore.DTOs;
using SimpleWebStore.Models;

namespace SimpleWebStore.Repositories;

internal static class CartRepository
{
    internal async static Task<Cart> GetCartByIdAsync(int cartId)
    {
        using var db = new ApplicationDbContext();


        return await db.Carts
            .Include(c => c.Items)
            .ThenInclude(ci => ci.Product)
            .FirstOrDefaultAsync(c => c.Id == cartId);
    }


    internal async static Task<Cart> CheckoutOrderAsync([FromBody] CartDto customerCart)
    {

        // fetch user record from database
        using var db = new ApplicationDbContext();
        var mockUserId = 1;
        var MockedCustomer = db.Customers.FirstOrDefault(c => c.Id == mockUserId);

        // intialize cartDto
        var cartDto = new CartDto
        {
            CustomerId = mockUserId,
            CartItems = new List<CartItemsDto>()
        };

        // update cartItemsDto however many times were added by the user
        var cartItems = cartDto.CartItems.Select(item => new CartItemsDto
        {
            Id = item.Id,
            Name = item.Name,
            Price = item.Price,
            Quantity = item.Quantity
        }).ToList();
        cartDto.CartItems = cartItems;

        // create customer Order (Cart) updating the cart items ready for the database schema
        var cart = new Cart
        {
            CustomerId = mockUserId,
            Items = cartDto.CartItems.Select(ci => new CartItem
            {
                ProductId = ci.Id,
                CartId = MockedCustomer.Id,
                Price = ci.Price,
                Quantity = ci.Quantity,
            }).ToList(),
        };

        // update database with customer Order
        db.Carts.Add(cart);
        await db.SaveChangesAsync();

        return cart;
    }
}
