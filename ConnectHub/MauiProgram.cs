﻿using ConnectHub.ViewModels;
using Microsoft.Extensions.Logging;
using Shared.Interfaces;
using Shared.Repositories;

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


    		builder.Logging.AddDebug();
            return builder.Build();
        }
    }
}