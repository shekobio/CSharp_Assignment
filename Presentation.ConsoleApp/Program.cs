using Infrastructure.Interface;
using Infrastructure.Managers;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presemtation;
using System.Text.Json;

string filePath = @"c:\data\products.json";
var builder = Host.CreateApplicationBuilder();
builder.Services.AddSingleton<IFileService>(_ => new JsonFileService(filePath, new JsonSerializerOptions { WriteIndented = true }));
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IProductManager, ProductManager>();
builder.Services.AddSingleton<MenuService>();


var app = builder.Build();

var menuService = app.Services.GetRequiredService<MenuService>();
menuService.Run();