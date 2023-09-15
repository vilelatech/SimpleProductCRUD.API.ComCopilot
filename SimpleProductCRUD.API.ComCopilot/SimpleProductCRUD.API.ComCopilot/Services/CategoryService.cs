using AutoMapper;
using SimpleProductCRUD.API.ComCopilot.DTOs;
using SimpleProductCRUD.API.ComCopilot.Entities;
using SimpleProductCRUD.API.ComCopilot.Interfaces;

namespace SimpleProductCRUD.API.ComCopilot.Services;

public class CategoryService : ICategoryService
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<CategoryDTO>> GetAllCategories()
    {
        var categories = await _categoryRepository.GetCategoriesAsync();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
    }

    public async Task<CategoryDTO> GetCategoryById(int? id)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(id);
        return _mapper.Map<CategoryDTO>(category);
    }

    public async Task CreateCategory(CategoryDTO category)
    {
        var categoryEntity = _mapper.Map<Category>(category);
        await _categoryRepository.CreateCategoryAsync(categoryEntity);
    }

    public async Task UpdateCategory(CategoryDTO category)
    {
        var categoryEntity = _mapper.Map<Category>(category);
        await _categoryRepository.UpdateCategoryAsync(categoryEntity);
    }

    public async Task DeleteCategory(int? id)
    {
        var categoryEntity = _categoryRepository.GetCategoryByIdAsync(id).Result;
        await _categoryRepository.DeleteCategoryAsync(categoryEntity);
    }
}