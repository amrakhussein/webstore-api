using SimpleWebStore.Models;

namespace SimpleWebStore.DTOs;

internal class CartDto
{
    public int Id { get; set; }
    public DateTime CreateOn { get; set; }

    public CustomerDto Customer { get; set; } = null!;
    public IEnumerable<CartItem> cartItems { get; set; } = null!;
}