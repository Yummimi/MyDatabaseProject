using ClassLibrary.Repositories;
using ClassLibrary.Services;

namespace ConsoleApp.UI;

public class ConsoleUI_Categories
{
    private readonly CategoryService _categoryService;

    public ConsoleUI_Categories(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public void CreateCategory_UI()
    {
        Console.Clear();
        Console.WriteLine("----- CREATE CATEGORY -----");

        Console.Write("Categoryname: ");
        var categoryName = Console.ReadLine()!.ToUpper();
        if (categoryName != null)
        {
            if (!_categoryService.CategoryExists(categoryName))
            {
                var result = _categoryService.CreateCategory(categoryName);
                Console.WriteLine($"Category ({categoryName}) was created.");
            }
            else
            {
                Console.WriteLine("Category already exists.");
            }

        }
        Console.ReadKey();
    }

    public void GetCategories_UI()
    {
        Console.Clear();

        var categories = _categoryService.GetAllCategories();
        foreach (var category in categories)
        {
            Console.WriteLine($"Id: {category.Id} - Name: {category.CategoryName}");
        }

        Console.ReadKey();
    }

    public void UpdateCategory_UI()
    {
        Console.Clear();
        Console.Write("Enter the name of the category you want to update: ");
        var categoryName = Console.ReadLine()!;
        var category = _categoryService.GetCategoryByCategoryName(categoryName);
        if (category != null)
        {
            Console.WriteLine($"Id: {category.Id} - Name: {category.CategoryName}");

            Console.Write("Enter new category name: ");
            category.CategoryName = Console.ReadLine()!.ToUpper();

            var newCategory = _categoryService.UpdateCategory(category);

            Console.WriteLine($"Id: {category.Id} - Name: {category.CategoryName}");
            Console.WriteLine("Category is updated successfully");
        }
        else
        {
            Console.WriteLine("Category not found.");
        }
        Console.ReadKey();
    }

    public void DeleteCategory_UI()
    {
        Console.Clear();
        Console.Write("Enter the Id of the category you want to delete: ");
        int categoryToDelete = int.Parse(Console.ReadLine()!);
        var category = _categoryService.GetCategoryById(categoryToDelete);
        if (categoryToDelete > 0)
        {
            _categoryService.DeleteCategory(categoryToDelete);
            Console.WriteLine($"Product ({category.Id} - {category.CategoryName}) deleted successfully!");
        }
        else
        {
            Console.WriteLine($"Product ({categoryToDelete}) was not found.");
        }
        Console.ReadKey();
    }
}
