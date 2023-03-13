namespace SimpleWebStore.DTOs;

internal class CartDto
{
    public int CustomerId { get; set; }

    public List<CartItemsDto> CartItems { get; set; } = null!;
}