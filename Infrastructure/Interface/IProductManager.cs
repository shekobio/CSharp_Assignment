using Infrastructure.Models;

namespace Infrastructure.Interface;

public interface IProductManager
{
    bool SaveProduct(ProductCreateRequest productCreateRequest);

    IEnumerable<Product> GetAllProduct();
}
