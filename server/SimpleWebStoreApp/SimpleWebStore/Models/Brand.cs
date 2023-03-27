using System.ComponentModel.DataAnnotations;

namespace SimpleWebStore.Models;

internal sealed class Brand
{
    public int Id { get; set; }

    [Required, StringLength(256)]
    public string Name { get; set; } = null!;

    [Required, StringLength(256)]
    public string? Description { get; set; } = null!;

    public ICollection<Product> Products { get; set; } = null!;
}
