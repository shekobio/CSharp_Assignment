using Infrastructure.Interface;
using Infrastructure.Models;


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

        if (string.IsNullOrEmpty(newProduct.Product_Name))
            return false;

        if (_productList.Any(x => x.Prodcut_Name == newProduct.Product_Name.ToUpper()))
           return false;

        Product product = new Product
        {
            Id = Guid.NewGuid(),
           Product_Price = newProduct.Product_Price,
           Prodcut_Name = newProduct.Product_Name,



        };

        _productList.Add(product);

        _fileService.SaveContentToFile(_productList);

        return true;
    }
   
    public Product? DeleteProductByName(string name)
    {
        var product = _productList.FirstOrDefault(y => string.Equals(y.Prodcut_Name, name, StringComparison.OrdinalIgnoreCase));

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