namespace SimpleWebStore.DTOs.product;

internal class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string ImageSrc { get; set; } = null!;
    public int Quantity { get; set; }
    public float Ratings { get; set; }
}
