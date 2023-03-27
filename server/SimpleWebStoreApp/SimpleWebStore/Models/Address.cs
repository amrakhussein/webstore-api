using System.ComponentModel.DataAnnotations;

namespace SimpleWebStore.Models;

internal sealed class Address
{
    public int Id { get; set; }

    [Required, StringLength(200)]
    public string StreetAddress { get; set; } = null!;

    [Required, StringLength(100)]
    public string City { get; set; } = null!;

    [Required, StringLength(15)]
    public string PostalCode { get; set; } = null!;

    [Required, StringLength(100)]
    public string Country { get; set; } = null!;

    [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Invalid phone number format. The phone number must have 10 digits.")]
    public string? Phone { get; set; } = null!;

    [Required, StringLength(256)]
    public string? Description { get; set; } = null!;

    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
}