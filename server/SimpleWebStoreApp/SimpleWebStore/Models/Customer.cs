using System.ComponentModel.DataAnnotations;

namespace SimpleWebStore.Models;

internal sealed class Customer
{
    public int Id { get; set; }

    [Required, StringLength(256)]
    public string FirstName { get; set; } = null!;

    [Required, StringLength(256)]
    public string LastName { get; set; } = null!;

    public ICollection<Order> Orders { get; set; } = null!;
    public ICollection<Address> Addresses { get; set; } = null!;
    public ICollection<Wishlist> Wishlists { get; set; } = null!;
    public ICollection<Rating> Ratings { get; set; } = null!;
}
