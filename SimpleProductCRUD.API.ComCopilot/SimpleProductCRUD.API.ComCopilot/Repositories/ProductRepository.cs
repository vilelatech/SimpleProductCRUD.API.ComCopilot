using Microsoft.EntityFrameworkCore;
using SimpleProductCRUD.API.ComCopilot.Context;
using SimpleProductCRUD.API.ComCopilot.Entities;
using SimpleProductCRUD.API.ComCopilot.Interfaces;

namespace SimpleProductCRUD.API.ComCopilot.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _productContext;

    public ProductRepository(ApplicationDbContext productContext)
    {
        _productContext = productContext;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _productContext.Products.ToListAsync();
    }

    public async Task<Product> GetProductByIdAsync(int? id)
    {
        return await _productContext.Products.FindAsync(id);
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        _productContext.Add(product);
        await _productContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateProductAsync(Product product)
    {
        _productContext.Update(product);
        await _productContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product> DeleteProductAsync(Product product)
    {
        _productContext.Remove(product);
        await _productContext.SaveChangesAsync();
        return product;
    }
}