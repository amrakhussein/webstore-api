using Microsoft.EntityFrameworkCore;

using SimpleWebStore.Data;
using SimpleWebStore.Models;

namespace SimpleWebStore.Repositories;

internal static class ProductRepository
{
    internal async static Task<IEnumerable<Product>> GetProductsAsync()
    {
        using var db = new ApplicationDbContext();
        return await db.Products.ToListAsync();
    }

}
