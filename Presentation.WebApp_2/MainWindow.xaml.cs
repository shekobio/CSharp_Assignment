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

            var ok = _productManager.SaveProduct(new Infrastructure.Models.ProductCreateRequest { Product_Name = name, Product_Price = price });
            MessageBox.Show(ok ? "Product added" : "Failed to add product");
            if (ok)
            {

                Txt_Name.Text = " ";
                Txt_Price.Text = " ";

               
                           
            }

        }



                      

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {                 
            var name = Txt_Name.Text.Trim();
            while (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Enter a Product name: ");
                return; 
               

            }
            var deleted = _productService.DeleteProductByName(name);
            if (deleted != null)
            {
                MessageBox.Show($"{deleted.Prodcut_Name} was deleted successfully.");




            }

            else
            {
                MessageBox.Show("Product Not Found.");
            }


                                 
           

       



        }

        private void Btn_ViewList_Click(object sender, RoutedEventArgs e)
        {

            ProductList.Items.Clear();
            var products = _productManager.GetAllProduct();

            foreach (var product in products)
            {
                ProductList.Items.Add($"Product Name: {product.Prodcut_Name} - Product Price: {product.Product_Price} kr - Id: {product.Id}");
            }

          
 


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProductList.Items.Clear();
        }
    }
    
    
}
  