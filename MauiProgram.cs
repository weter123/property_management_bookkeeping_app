using Microsoft.Extensions.Logging;
using Microsoft.Maui.Hosting;
using RecordKeepingApp.Models;
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
            string dbPath = FileAccessHelper.GetLocalFilePath("bookKeepingTest1.db3");
            builder.Services.AddSingleton<RecordRepository>(s => ActivatorUtilities.CreateInstance<RecordRepository>(s, dbPath));
#endif
            return builder.Build();
        }
    }
}
