using AddressBook.ConsoleApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared.Interfaces;
using Shared.Repositories;
using Shared.Services;




var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddSingleton<IPersonRepository, PersonRepository>();
    services.AddSingleton<MenuService>();
    services.AddSingleton<IFileService, FileService>();


}).Build();

builder.Start();
Console.Clear();

var menuService = builder.Services.GetRequiredService<MenuService>();
menuService.ShowMainMenu();
Console.ReadKey();