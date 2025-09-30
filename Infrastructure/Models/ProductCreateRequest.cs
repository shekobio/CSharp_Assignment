namespace Infrastructure.Models;

public class ProductCreateRequest
{
   
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
}
