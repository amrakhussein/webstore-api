using System.ComponentModel.DataAnnotations;

namespace SimpleWebStore.Models;

internal sealed class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;

    [Range(0.01, double.MaxValue, ErrorMessage = "The value must be greater than zero.")]
    public decimal Price { get; set; }
    public string ImageSrc { get; set; } = null!;

    public int AvailableQuantity { get; set; } = 1000;
    public float AverageRatings { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public int BrandId { get; set; }
    public Brand Brand { get; set; } = null!;
    public int WishlistId { get; set; }
    public Wishlist Wishlist { get; set; } = null!;

    public ICollection<OrderItem> Items { get; set; } = null!;
    public ICollection<Rating> Ratings { get; set; } = null!;
}
