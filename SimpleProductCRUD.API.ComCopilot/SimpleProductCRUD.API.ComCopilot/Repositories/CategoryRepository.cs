using Microsoft.EntityFrameworkCore;
using SimpleProductCRUD.API.ComCopilot.Context;
using SimpleProductCRUD.API.ComCopilot.Entities;
using SimpleProductCRUD.API.ComCopilot.Interfaces;

namespace SimpleProductCRUD.API.ComCopilot.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _categoryContext;

    public CategoryRepository(ApplicationDbContext categoryContext)
    {
        _categoryContext = categoryContext;
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await _categoryContext.Categories.ToListAsync();
    }

    public async Task<Category> GetCategoryByIdAsync(int? id)
    {
        return await _categoryContext.Categories.FindAsync(id);
    }

    public async Task<Category> CreateCategoryAsync(Category category)
    {
        _categoryContext.Add(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }

    public async Task<Category> UpdateCategoryAsync(Category category)
    {
        _categoryContext.Update(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }

    public async Task<Category> DeleteCategoryAsync(Category category)
    {
        _categoryContext.Remove(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }
}