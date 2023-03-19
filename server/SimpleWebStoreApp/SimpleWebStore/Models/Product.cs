namespace SimpleWebStore.Models;

internal sealed class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string ImageSrc { get; set; } = null!;

    // quantity per unit defaulted with 50 for testing
    public int Quantity { get; set; } = 500;
    public double AverageRatings { get; set; }

    public IEnumerable<CartItem> Items { get; set; } = null!;
    public IEnumerable<Rating> Ratings { get; set; } = null!;
}
