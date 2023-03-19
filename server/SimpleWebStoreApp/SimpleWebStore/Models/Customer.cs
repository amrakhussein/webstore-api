namespace SimpleWebStore.Models;

internal sealed class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public IEnumerable<Cart> Orders { get; set; } = null!;
    public IEnumerable<Rating> Ratings { get; set; } = null!;
}
