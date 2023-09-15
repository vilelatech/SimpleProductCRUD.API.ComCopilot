using SimpleProductCRUD.API.ComCopilot.DTOs;

namespace SimpleProductCRUD.API.ComCopilot.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetAllProducts();
    Task<ProductDTO> GetProductById(int? id);
    Task CreateProduct(ProductDTO product);
    Task UpdateProduct(ProductDTO product);
    Task DeleteProduct(int? id);
}