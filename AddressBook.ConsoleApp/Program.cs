using AddressBook.ConsoleApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared.Interfaces;
using Shared.Repositories;
using Shared.Services;



/// <summary>
/// Configures the application's services and builds the host.
/// </summary>
var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddSingleton<IPersonRepository, PersonRepository>();
    services.AddSingleton<MenuService>();
    services.AddSingleton<IFileService, FileService>();


}).Build();

/// <summary>
/// Starts the application and displays the main menu.
/// </summary>
builder.Start();
Console.Clear();

var menuService = builder.Services.GetRequiredService<MenuService>();
menuService.ShowMainMenu();
Console.ReadKey();