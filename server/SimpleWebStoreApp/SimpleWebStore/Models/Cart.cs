namespace SimpleWebStore.Models;

internal sealed class Cart
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public decimal Total { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public IEnumerable<CartItem> Items { get; set; } = null!;
}
