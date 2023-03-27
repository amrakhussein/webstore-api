using System.ComponentModel.DataAnnotations;

namespace SimpleWebStore.Models;

internal sealed class Discount
{
    public int Id { get; set; }

    [Range(0.0, 100.0, ErrorMessage = "The value must be between 0 and 100.")]
    public decimal PercentageOff { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
}
