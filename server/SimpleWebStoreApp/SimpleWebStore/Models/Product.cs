namespace SimpleWebStore.Models;

internal sealed class Product
{
    public int id { get; set; }
    public string name { get; set; } = null!;
    public string? description { get; set; } = null!;
    public decimal Price { get; set; }

    // quantity per unit defaulted with 50 for testing
    public int Quantity { get; set; } = 50;

    public IEnumerable<CartItem> Items { get; set; } = null!;
}
