namespace SimpleWebStore.DTOs;

internal class CustomerDto
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}
