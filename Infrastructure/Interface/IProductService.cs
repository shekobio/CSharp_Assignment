using Infrastructure.Models;

namespace Infrastructure.Interface;

public interface IProductService
{
    bool AddProductToList(ProductCreateRequest newProduct);
    IEnumerable<Product> GetProductList();
    Product? DeleteProductByName(string name);
    void PopulateProductList(IEnumerable<Product> products);

}
   