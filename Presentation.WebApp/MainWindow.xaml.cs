using Infrastructure.Interface;
using Infrastructure.Managers;
using Infrastructure.Models;
using Infrastructure.Services;
using System.Globalization;
using System.Text;
using System.Windows;


namespace Presentation.WebApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IProductService _productService;
        private readonly IProductManager _productmanager;

        public MainWindow(IProductService _productService)
        {
            InitializeComponent();

            _productManager = new ProductManager();

            foreach (var product in _productService.GetProductList()

            {

                
            }
        }


        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            var name = ProductName.Text?.Trim();
            if (!string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter a product name: ");

                return; 
            }
            if(!decimal.TryParse(ProductPrice.Text, System.Globalization.NumberStyles.Number, CultureInfo.InvariantCulture, out var Price))
            {
                MessageBox.Show("Please enter a valid number: ");
                return; 
            }

            
            var product_1 = new ProductCreateRequest()
            {
                Name = name!,
                Price = Price,
              

                
            };

            ProductList.Items.Add(product_1);

           

        }

        private void Deleteproduct_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}