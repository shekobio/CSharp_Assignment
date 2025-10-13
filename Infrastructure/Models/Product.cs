namespace Infrastructure.Models;

public class Product
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Prodcut_Name { get; set; } = null;
    public decimal Product_Price { get; set; }  

}

