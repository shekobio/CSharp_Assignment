namespace Infrastructure.Models;

public class Product
{
    public string Id =  Guid.NewGuid().ToString();
    public string? Name { get; set; } = null;
    public decimal Price { get; set; }  

}

