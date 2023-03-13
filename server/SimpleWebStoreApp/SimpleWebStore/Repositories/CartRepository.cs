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


    internal async static Task<CartDto> PurchaseOrderAsync(CartDto customerCart)
    {

        if (customerCart == null)
            throw new ArgumentNullException(nameof(customerCart));

        // fetch user record from database
        using var db = new ApplicationDbContext();
        var mockUserId = 1;
        var MockedCustomer = db.Customers.FirstOrDefault(c => c.Id == mockUserId);

        // update cartItemsDto however many times were added by the user
        var cartItemsDto = customerCart.CartItems.Select(item => new CartItemDto
        {
            Id = item.Id,
            Price = item.Price,
            Quantity = item.Quantity
        }).ToList();
        customerCart.CartItems = cartItemsDto;

        // create customer Order (Cart) updating the cart items ready for the database schema
        var cart = new Cart
        {
            CustomerId = mockUserId,
            Items = cartItemsDto.Select(ci => new CartItem
            {
                ProductId = ci.Id,
                Price = ci.Price,
                Quantity = ci.Quantity,
            }).ToList(),
            Total = cartItemsDto.Sum(c => c.TotalPrice)
        };


        // update products quantity
        // TODO: handle proper user response
        var productIds = customerCart.CartItems.Select(ci => ci.Id).ToList();
        var quantitiyUpdated = await ProductRepository.UpdateProductsQuantityAsync(productIds, customerCart);

        if (quantitiyUpdated.success)
        {
            // update database with customer Order
            db.Carts.Add(cart);
            await db.SaveChangesAsync();
        }
        return customerCart;
    }
}
