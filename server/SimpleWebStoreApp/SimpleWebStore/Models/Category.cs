namespace SimpleWebStore.Models;

internal sealed class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<Product> Products { get; set; } = null!;
}
