using Infrastructure.Interface;
using Infrastructure.Managers;
using Infrastructure.Models;
using Infrastructure.Services;
using System.IO;
using System.Text;
using System.Windows;


namespace Presentation.WebApp_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IProductService _productService;
        private readonly IProductManager _productManager;
        public MainWindow(IProductManager productManager, IProductService productService)
        {
            InitializeComponent();
            
            _productManager = productManager; 
            _productService = productService;   
            LoadProducts();
        }
        private void LoadProducts()  
        {
            ProductList.Items.Clear();
            var products = _productManager.GetAllProduct();

            foreach (var product in products)
            {
                ProductList.Items.Add($"Product Name: {product.Name} - Product Price: {product.Price} kr - Id: {product.Id}");
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

            if (!decimal.TryParse(Txt_Price.Text.Trim(), out var price))
            {
                MessageBox.Show("Invalid Price. ");
                return;
            }

            var ok = _productManager.SaveProduct(new Infrastructure.Models.ProductCreateRequest { Name = name, Price = price});
            MessageBox.Show(ok ? "Product added" : "Failed to add product");
            if (ok)
            {
                
                Txt_Name.Text = " ";
                Txt_Price.Text = " ";

                LoadProducts();

            }
        
        }

    }
}