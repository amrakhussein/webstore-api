namespace SimpleWebStore.DTOs.customerCart;

internal class CartItemDto
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public string Name { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal TotalPrice => Price * Quantity;
}
