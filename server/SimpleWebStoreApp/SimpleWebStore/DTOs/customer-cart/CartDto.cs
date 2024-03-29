﻿namespace SimpleWebStore.DTOs.customerCart;

internal class CartDto
{
    public int CustomerId { get; set; }
    public decimal Total { get; set; }

    public List<CartItemDto> CartItems { get; set; } = null!;
}