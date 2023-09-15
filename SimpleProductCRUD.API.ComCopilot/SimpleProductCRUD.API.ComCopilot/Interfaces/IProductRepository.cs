﻿using SimpleProductCRUD.API.ComCopilot.Entities;

namespace SimpleProductCRUD.API.ComCopilot.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product> GetProductByIdAsync(int? id);
    Task<Product> CreateProductAsync(Product product);
    Task<Product> UpdateProductAsync(Product product);
    Task<Product> DeleteProductAsync(Product product);
}