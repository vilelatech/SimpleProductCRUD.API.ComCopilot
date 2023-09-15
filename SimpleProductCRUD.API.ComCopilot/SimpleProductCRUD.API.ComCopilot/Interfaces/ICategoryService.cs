using SimpleProductCRUD.API.ComCopilot.DTOs;

namespace SimpleProductCRUD.API.ComCopilot.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetAllCategories();
    Task<CategoryDTO> GetCategoryById(int? id);
    Task CreateCategory(CategoryDTO category);
    Task UpdateCategory(CategoryDTO category);
    Task DeleteCategory(int? id);
}