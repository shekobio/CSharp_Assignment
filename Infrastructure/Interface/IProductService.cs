using Infrastructure.Models;

namespace Infrastructure.Interface;

public interface IProductService
{
    bool AddToProductList(ProductCreateRequest newProduct);
    IEnumerable<Product> GetProductList();
    Product? GetproductById(string id);
    Product? GetProductByName(string name);
    Product? DeleteProductByName(string name);


}