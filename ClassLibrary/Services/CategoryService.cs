using ClassLibrary.Contexts;
using ClassLibrary.Entities;
using ClassLibrary.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Linq;
using System.Linq.Expressions;

namespace ClassLibrary.Services;

public class CategoryService
{
    private readonly CategoryRepository _categoryRepository;
    private readonly DataContext _dataContext;

    public CategoryService(CategoryRepository categoryRepository, DataContext dataContext)
    {
        _categoryRepository = categoryRepository;
        _dataContext = dataContext;
    }

    public CategoryEntity CreateCategory(string categoryName)
    {
        var categoryEntity = _categoryRepository.GetOne(x => x.CategoryName == categoryName);
        categoryEntity ??= _categoryRepository.Create(new CategoryEntity { CategoryName = categoryName });

        return categoryEntity;
    }

    public CategoryEntity GetCategoryByCategoryName(string categoryName)
    {
        var categoryEntity = _categoryRepository.GetOne(x => x.CategoryName == categoryName);
        return categoryEntity;
    }

    public CategoryEntity GetCategoryById(int id)
    {
        var categoryEntity = _categoryRepository.GetOne(x => x.Id == id);
        return categoryEntity;
    }

    public IEnumerable<CategoryEntity> GetAllCategories()
    {
        var categories = _categoryRepository.GetAll();
        return categories;
    }

    public CategoryEntity UpdateCategory(CategoryEntity categoryEntity)
    {
        var updatedCategoryEntity = _categoryRepository.Update(x => x.Id == categoryEntity.Id, categoryEntity);
        return updatedCategoryEntity;
    }

    public void DeleteCategory(int id) 
    {
        _categoryRepository.Delete(x => x.Id == id);
    }

    public bool CategoryExists(string categoryName)
    {
        return _dataContext.Categories.Any(c => c.CategoryName == categoryName);
    }
}
