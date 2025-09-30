using Infrastructure.Interface;
using Infrastructure.Managers;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Text.Json;
using System.Windows;

namespace Presentation.WebApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            string filePath = @"c:\data\products.json";
            var builder = Host.CreateApplicationBuilder();
            builder.Services.AddSingleton<IFileService>(_ => new JsonFileService(filePath, new JsonSerializerOptions { WriteIndented = true }));
            builder.Services.AddSingleton<IProductService, ProductService>();
            builder.Services.AddSingleton<IProductManager, ProductManager>();
            


        }
    }

}
