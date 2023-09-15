using AutoMapper;
using SimpleProductCRUD.API.ComCopilot.DTOs;
using SimpleProductCRUD.API.ComCopilot.Entities;
using SimpleProductCRUD.API.ComCopilot.Interfaces;

namespace SimpleProductCRUD.API.ComCopilot.Services;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public ProductService(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductDTO>> GetAllProducts()
    {
        var products = await _productRepository.GetProductsAsync();
        return _mapper.Map<IEnumerable<ProductDTO>>(products);
    }

    public async Task<ProductDTO> GetProductById(int? id)
    {
        var product = await _productRepository.GetProductByIdAsync(id);
        return _mapper.Map<ProductDTO>(product);
    }

    public async Task CreateProduct(ProductDTO product)
    {
        var newProduct = _mapper.Map<Product>(product);
        await _productRepository.CreateProductAsync(newProduct);
    }

    public async Task UpdateProduct(ProductDTO product)
    {
        var newProduct = _mapper.Map<Product>(product);
        await _productRepository.UpdateProductAsync(newProduct);
    }

    public async Task DeleteProduct(int? id)
    {
        var product = _productRepository.GetProductByIdAsync(id).Result;
        await _productRepository.DeleteProductAsync(product);
    }
}