namespace Infrastructure.Models;

public class Product
{
    public string Id = new Guid().ToString();
    public string Name { get; set; } = null!; 
    public decimal Price { get; set; }  

}

