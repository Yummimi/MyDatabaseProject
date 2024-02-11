using ClassLibrary.Entities;
using ClassLibrary.Services;
using System.Diagnostics;

namespace ConsoleApp.UI;

public class ConsoleUI_Products
{
    private readonly ProductService _productService;

    public ConsoleUI_Products(ProductService productService)
    {
        _productService = productService;
    }

    public void CreateProduct_UI()
    {
        Console.Clear();
        Console.WriteLine("----- CREATE PRODUCT -----");

        Console.Write("Product Articlenumber: ");
        var articleNumber = Console.ReadLine()!;

        Console.Write("Product Title: ");
        var title = Console.ReadLine()!;

        Console.Write("Product Description: ");
        var description = Console.ReadLine();

        Console.Write("Product Price: ");
        var price = decimal.Parse(Console.ReadLine()!);

        Console.Write("Product Category: ");
        var categoryName = Console.ReadLine()!;

        var result = _productService.CreateProduct(articleNumber, title, description, price, categoryName);
        if (result != null)
        {
            Console.WriteLine("Product was created.");
        }
        Console.ReadKey();
    }

    public void GetProducts_UI()
    {
        Console.Clear();

        var products = _productService.GetAllProducts();
        foreach (var product in products)
        {
            Console.WriteLine($"Id: {product.Id} - Articlenumber: {product.ArticleNumber} - Title: {product.Title} - Description: {product.Description} - Price: {product.Price}");
        }

        Console.ReadKey();
    }

    public void UpdateProduct_UI()
    {
        Console.Clear();
        Console.Write("Enter the Id of the product you want to update: ");
        int id = int.Parse(Console.ReadLine()!);
        var product = _productService.GetProductById(id);
        if (product != null)
        {
            Console.WriteLine($"Articlenumber: {product.ArticleNumber} - Title: {product.Title} - Description: {product.Description} - Price: {product.Price}");
            Console.WriteLine("What would you like to update with this product?");
            Console.WriteLine("Articlenumber, Title, Description or Price?");
            var toUpdate = Console.ReadLine()!;

            if (toUpdate.ToLower() == "articlenumber")
            {
                Console.Write("Enter new articlenumber: ");
                product.ArticleNumber = Console.ReadLine()!.ToUpper();

                var newProduct = _productService.UpdateProduct(product);

                Console.WriteLine($"Articlenumber: {product.ArticleNumber} - Title: {product.Title} - Description: {product.Description} - Price: {product.Price}");
                Console.WriteLine("Product is updated successfully");
            }

            else if (toUpdate.ToLower() == "title")
            {
                Console.Write("Enter new title: ");
                product.Title = Console.ReadLine()!.ToUpper();

                var newProduct = _productService.UpdateProduct(product);
            }

            else if (toUpdate.ToLower() == "description")
            {
                Console.Write("Enter new title: ");
                product.Description = Console.ReadLine().ToUpper();

                var newProduct = _productService.UpdateProduct(product);
            }

            else if (toUpdate.ToLower() == "price")
            {
                Console.Write("Enter new price: ");
                product.Price = decimal.Parse(Console.ReadLine()!);

                var newProduct = _productService.UpdateProduct(product);
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }

            Console.WriteLine($"Articlenumber: {product.ArticleNumber} - Title: {product.Title} - Description: {product.Description} - Price: {product.Price}");
            Console.WriteLine("Product was updated successfully");

        }
        else
        {
            Console.WriteLine("Product not found.");
        }
        Console.ReadKey();
    }

    public void DeleteProduct_UI()
    {
        Console.Clear();
        Console.Write("Enter the Id of the product you want to delete: ");
        int productToDelete = int.Parse(Console.ReadLine()!);
        var product = _productService.GetProductById(productToDelete);
        if (productToDelete > 0)
        {
            _productService.DeleteProduct(productToDelete);
            Console.WriteLine($"Product ({product.Id} - {product.Title}) deleted successfully!");
        }
        else
        {
            Console.WriteLine($"Product ({productToDelete}) was not found.");
        }
        Console.ReadKey();
    }
}
