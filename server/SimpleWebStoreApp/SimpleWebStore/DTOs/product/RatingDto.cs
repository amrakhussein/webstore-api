namespace SimpleWebStore.DTOs.product;

internal class RatingDto
{
    public int Stars { get; set; }
    public string? Review { get; set; } = null!;
}