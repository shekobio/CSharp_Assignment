using Infrastructure.Interface;
using Infrastructure.Models;
using System.Xml.Linq;

namespace Infrastructure.Services;

public class ProductService : IProductService
{
    private List<Product> _productList = [];
    public bool AddToProductList(ProductCreateRequest newProduct)
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

        return true;

    }

    public Product? GetproductById(string id)
    {
        var product = _productList.FirstOrDefault(x => x.Id == id);
        return product;
    }

    public Product? GetProductByName(string name)
    {
        var product = _productList.FirstOrDefault(x => x.Name == name);
        return product;
    }
    public Product? DeleteProductByName(string name)
    {
        var product = _productList.FirstOrDefault(y => y.Name == name);

        if (product == null)
            return null;

        _productList.Remove(product);
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