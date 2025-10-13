namespace Infrastructure.Models;

public class ProductCreateRequest
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Product_Name { get; set; } = null!;
    public decimal Product_Price { get; set; }
}
