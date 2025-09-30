using Infrastructure.Interface;
using Infrastructure.Models;
using Infrastructure.Services;

namespace Infrastructure.Managers;

public class ProductManager(IProductService productService, IFileService fileService)  : IProductManager
{

    private readonly IProductService _productService = productService;
    private readonly IFileService _fileService = fileService;
    
    public IEnumerable<Product> GetAllProduct()
    {
        var data = _fileService.GetContentFromFile<IEnumerable<Product>>();
        if (data == null)
        {
            return Enumerable.Empty<Product>();
        }
       
       _productService.PopulateProductList(data);
    

        var productList = _productService.GetProductList();
        return productList;
    }

    public bool SaveProduct(ProductCreateRequest productCreateRequest)
    {
        var Add_success = _productService.AddProductToList(productCreateRequest);
        if (Add_success)
        {
            var productList = _productService.GetProductList();

            var Save_result = _fileService.SaveContentToFile<IEnumerable<Product>>(productList);

            return Save_result;
        }
        return false;
    }
}

