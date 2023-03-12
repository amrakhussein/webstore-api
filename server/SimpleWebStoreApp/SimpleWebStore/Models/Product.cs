namespace SimpleWebStore.Models;

internal sealed class Product
{
    public int id { get; set; }
    public string name { get; set; } = null!;
    public string? description { get; set; } = null!;
    public decimal Price { get; set; }

    public IEnumerable<CartItem> Items { get; set; } = null!;
}
