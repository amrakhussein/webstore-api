using System.ComponentModel.DataAnnotations;

namespace SimpleWebStore.Models;

internal sealed class OrderItem
{
    public int Id { get; set; }
    [Range(0.0, 7000000.0, ErrorMessage = "The value must be between 0 and 7000000.")]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "The value must be a positive integer.")]
    public int Quantity { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
}