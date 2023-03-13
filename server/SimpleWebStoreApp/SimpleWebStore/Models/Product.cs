namespace SimpleWebStore.Models;

internal sealed class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public decimal Price { get; set; }

    // quantity per unit defaulted with 50 for testing
    public int Quantity { get; set; } = 50;

    public IEnumerable<CartItem> Items { get; set; } = null!;
}
