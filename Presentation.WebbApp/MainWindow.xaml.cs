using Infrastructure.Interface;
using Infrastructure.Managers;
using Infrastructure.Models;
using Infrastructure.Services;
using System.Text;
using System.Windows;


namespace Presentation.WebbApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IFileService _fileService;
        private readonly IProductService _productService;
        private readonly IProductManager _productManager;
      
        

        public MainWindow()
        {
            InitializeComponent();
            string filePath = @"c:\data\products.json "; 
            _fileService = new JsonFileService(filePath);
            _productService = new ProductService(_fileService);
            _productManager = new ProductManager(_productService, _fileService);

            LoadProducts();
        }
        private void LoadProducts()
        {
            ProductList.Items.Clear();
            var products = _productManager.GetAllProduct();

            foreach (var product in products)
            {
                ProductList.Items.Add($"{product.Name} - {product.Price} kr");
            }

        }


        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            string name = Txt_Name.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Name is required");

                return; 
            }

            if (decimal.TryParse(Txt_Price.Text.Trim(), out var price))
            {
                MessageBox.Show("Invalid Price. ");
                return; 
            }

            var request = new ProductCreateRequest
            {
                
                Name = name, 
                Price = price

            };

            var ok = _productManager.SaveProduct(request);
            if(ok)
            {
                MessageBox.Show("Product added successfully");
          
                LoadProducts();

            }
            else
            {
                MessageBox.Show("Failed to add product.");
            }
            


        }

     
    }

    
}