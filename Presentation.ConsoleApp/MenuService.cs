using Infrastructure.Interface;
using Infrastructure.Models;

namespace Presemtation;

public class MenuService(IProductManager productManager, IProductService productService)
{
    private readonly IProductManager _productManager = productManager;
    private readonly IProductService _productService = productService; 

    private void AddMenuOption()
    {
        var product = new ProductCreateRequest();

        Console.Write("Product Name: ");
        var name = Console.ReadLine()!;
        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("You must enter a valid product name. ");
            Console.Write("Product Name: ");
            name = Console.ReadLine()!;
            
        }

        product.Product_Name = name;

        Console.Write("Product Price: ");
        product.Product_Price = decimal.Parse( Console.ReadLine()!);

        var result = _productManager.SaveProduct(product);
        if (result)
        {
            Console.WriteLine("Product was created successfully");

        }
        else
        {
            Console.WriteLine("Something went wrong! Please try again later.");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }


    private void ViewMenuOption()
    {
        Console.WriteLine("****************** PRODUCT LIST ******************");
        var products = _productManager.GetAllProduct();
        foreach (var product in products)
        {
            Console.WriteLine($"{"Product Name: "}{product.Prodcut_Name}{"\nID:"}  {product.Id}{"\nProduct Price:"}{product.Product_Price}\n");

            Console.WriteLine("=================================================");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private void DeleteProduct()

    {

        Console.Write("Enter a Product name: ");
       var  name = Console.ReadLine()!;
        while (string.IsNullOrEmpty(name))
        {
            Console.Write("Enter a Product name: ");
            name = Console.ReadLine()!;

        }
        var deleted = _productService.DeleteProductByName(name);
        if (deleted != null)
        {
            Console.WriteLine($"{deleted.Prodcut_Name} was deleted successfully.");

           
            
        }

        else
        {
            Console.WriteLine("Product Not Found.");
        }
        Console.ReadKey();

        Console.Clear();
        
    }
    private void MainMenu()
    {
        while (true)
        {
            Console.WriteLine("##### MENU OPTIONS #####");
            Console.WriteLine("1. \t NEW PRODUCT");
            Console.WriteLine("2. \t VIEW PRODUCT LIST");
            Console.WriteLine("3. \t DELETE PRODUCT BY NAME");
            Console.WriteLine("4. \t AVSLUTA APPLICATION.");

            Console.Write("SELECT MENU OPTION: ");
            var option = Console.ReadLine();

            Console.Clear();

            switch (option)

            {
                case "1":
                    AddMenuOption();

                    Console.Clear();
                    break;

                case "2":
                    ViewMenuOption();

                    Console.Clear();
                    break;

                case "3":
                    DeleteProduct();
                    break;

                case "4":
                    Environment.Exit(0);
                    break;
            }

        }

    }
    public void Run()
    {
        _productManager.GetAllProduct();
       

        MainMenu();

    }
}
