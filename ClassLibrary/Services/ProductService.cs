﻿using ClassLibrary.Entities;
using ClassLibrary.Repositories;

namespace ClassLibrary.Services;

public class ProductService
{
    private readonly ProductRepository _productRepository;
    private readonly CategoryService _categoryService;

    public ProductService(ProductRepository productRepository, CategoryService categoryService)
    {
        _productRepository = productRepository;
        _categoryService = categoryService;
    }

    public ProductEntity CreateProduct(string articleNumber, string title, string description, decimal price, string categoryName)
    {
        var categoryEntity = _categoryService.CreateCategory(categoryName);
        var productEntity = new ProductEntity
        {
            ArticleNumber = articleNumber,
            Title = title,
            Description = description,
            Price = price,
            CategoryId = categoryEntity.Id
        };
       productEntity = _productRepository.Create(productEntity);
        return productEntity;
    }

    public ProductEntity GetProductById(int id)
    {
        var productEntity = _productRepository.GetOne(x => x.Id == id);
        return productEntity;
    }

    public IEnumerable<ProductEntity> GetAllProducts()
    {
        var products = _productRepository.GetAll();
        return products;
    }

    public ProductEntity UpdateProduct(ProductEntity productEntity)
    {
        var updatedProductEntity = _productRepository.Update(x => x.Id == productEntity.Id, productEntity);
        return updatedProductEntity;
    }

    public void DeleteProduct(int id)
    {
        _productRepository.Delete(x => x.Id == id);
    }
}
