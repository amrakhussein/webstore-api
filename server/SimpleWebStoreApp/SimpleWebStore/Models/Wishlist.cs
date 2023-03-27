namespace SimpleWebStore.Models;

internal sealed class Wishlist
{
    public int Id { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public ICollection<Product> Products { get; set; } = null!;
}