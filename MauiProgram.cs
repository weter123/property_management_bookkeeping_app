using Microsoft.Extensions.Logging;
using Microsoft.Maui.Hosting;
using RecordKeepingApp.Models;
using RecordKeepingApp.ViewModels;
//using RecordKeepingApp.Service;
namespace RecordKeepingApp
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

#if DEBUG
            
            string dbPath = FileAccessHelper.GetLocalFilePath("bookKeepingTest4.db3");
            builder.Services.AddSingleton<RecordRepository>(s => ActivatorUtilities.CreateInstance<RecordRepository>(s, dbPath));

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<PropertyListPage>();
            builder.Services.AddTransient<PropertyListViewModel>();

#endif
            return builder.Build();
        }
    }
}
