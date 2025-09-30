using Infrastructure.Interface;
using Infrastructure.Managers;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace Presentation.WebbApp
{
    
    public partial class App : Application
    {
        public static IHost HostApp { get; set; } = null!;

        protected override void OnStartup(StartupEventArgs e)
        {
                base.OnStartup(e);

            string filePath = @"c:\data\products.json";
            Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

            HostApp = Host.CreateDefaultBuilder().ConfigureServices(service =>
            {
                service.AddSingleton<IFileService>(_ => new JsonFileService
                (filePath, new JsonSerializerOptions 
                { WriteIndented = true }));   
                service.AddSingleton<IProductService, ProductService>();
                service.AddSingleton<IProductManager, ProductManager>();
                

            }).Build();

            HostApp.Services.GetRequiredService<MainWindow>().Show();

        }
        protected override void OnExit(ExitEventArgs e)
        {
            HostApp?.Dispose(); 
            base.OnExit(e);
        }


    }

}
