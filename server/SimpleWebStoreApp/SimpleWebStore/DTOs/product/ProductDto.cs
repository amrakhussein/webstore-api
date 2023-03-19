namespace SimpleWebStore.DTOs.product;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string ImageSrc { get; set; } = null!;
    public int Quantity { get; set; }
    public double Ratings { get; set; }
}
