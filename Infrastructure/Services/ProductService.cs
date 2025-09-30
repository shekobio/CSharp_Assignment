using Infrastructure.Interface;
using Infrastructure.Models;
using System;
using System.Xml.Linq;

namespace Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly IFileService _fileService;
    private List<Product> _productList = [];

    public ProductService(IFileService fileService)
    {
        _fileService = fileService;
    }


    public bool AddProductToList(ProductCreateRequest newProduct)
    {
        if (newProduct == null)
            return false;

        if (string.IsNullOrEmpty(newProduct.Name))
            return false;

        Product product = new Product
        {
            Id = Guid.NewGuid().ToString(),
            Price = newProduct.Price,
            Name = newProduct.Name,


        };

        _productList.Add(product);

        _fileService.SaveContentToFile(_productList);

        return true;
    }
    public Product? GetProductByName(string name)
    {
        var product = _productList.FirstOrDefault(x => x.Name == name);
        return product;
    }
    public Product? DeleteProductByName(string name)
    {
        var product = _productList.FirstOrDefault(y => string.Equals(y.Name, name, StringComparison.OrdinalIgnoreCase));

        if (product == null)
            return null;

        _productList.Remove(product);
       _fileService.SaveContentToFile(_productList);
    
            
        return product;
    }

    public IEnumerable<Product> GetProductList()
    {
        return _productList;
    }
    public void PopulateProductList(IEnumerable<Product> products)
    {
        _productList = products.ToList();
    }

   
}