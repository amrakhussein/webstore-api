namespace SimpleWebStore.DTOs;

internal class CartItemsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    // total price per an item
    public decimal TotalPrice => Price * Quantity;
}
