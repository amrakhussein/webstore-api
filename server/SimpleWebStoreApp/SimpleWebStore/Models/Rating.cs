using System.ComponentModel.DataAnnotations;

namespace SimpleWebStore.Models;

internal sealed class Rating
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    private int _stars;
    public int Stars
    {
        get => _stars;
        set
        {
            if (value < 1 || value > 5) throw new ArgumentException("ratings should be within 1-5 range");
            _stars = value;
        }
    }

    [Required, StringLength(256)]
    public string? Review { get; set; } = null!;

    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
}