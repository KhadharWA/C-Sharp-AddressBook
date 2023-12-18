using ConnectHub.Pages;
using ConnectHub.ViewModels;
using Microsoft.Extensions.Logging;
using Shared.Interfaces;
using Shared.Repositories;
using Shared.Services;

namespace ConnectHub
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<IPersonRepository, PersonRepository>();
            builder.Services.AddSingleton<IFileService, FileService>();
            builder.Services.AddSingleton<AddPersonPage>();
            builder.Services.AddSingleton<PersonsListPage>();
            builder.Services.AddSingleton<RemovePersonPage>();
            builder.Services.AddSingleton<ShowPersonPage>();
            builder.Services.AddSingleton<UpdatePersonPage>();
            builder.Services.AddSingleton<AddViewModel>();
            builder.Services.AddSingleton<PersonListViewModel>();



            builder.Logging.AddDebug();
            return builder.Build();
        }
    }
}
