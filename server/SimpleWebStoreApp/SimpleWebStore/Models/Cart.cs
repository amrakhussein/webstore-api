namespace SimpleWebStore.Models;

internal sealed class Cart
{
    public int Id { get; set; }

    public decimal Total { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public List<CartItem> Items { get; set; } = null!;
}
