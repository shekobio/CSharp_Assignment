using Infrastructure.Interface;
using Infrastructure.Managers;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace Presentation.WebApp_2
{
    public partial class App : Application
    {
        public static IHost HostApp { get; set; } = null!;

        protected override void OnStartup(StartupEventArgs e)

        {
            base.OnStartup(e);

            var filePath = @"c:\data\products.json";
            Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

            HostApp = Host.CreateDefaultBuilder().ConfigureServices(service =>
            {
                service.AddSingleton<IFileService>(_ => new JsonFileService
                (filePath, new JsonSerializerOptions
                { WriteIndented = true }));
                service.AddSingleton<IProductService, ProductService>();
                service.AddSingleton<IProductManager, ProductManager>();

                service.AddSingleton<MainWindow>();

            }).Build();

            var main = HostApp.Services.GetRequiredService<MainWindow>();
            main.Show();

        }
        protected override void OnExit(ExitEventArgs e)
        {
            HostApp?.Dispose();
            base.OnExit(e);
        }
    }

}
