using ClubSocial.Repositories;
using ClubSocial.ViewModels;
using Microsoft.Extensions.Logging;

namespace ClubSocial
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

            //Guardo la base de datos en la carpeta de datos de la aplicación.
            string rutaBaseDatos = Path.Combine(FileSystem.AppDataDirectory, "clubsocial.db3");

            // Se comparte un repositorio durante toda la ejecución
            builder.Services.AddSingleton<ISocioRepository>(servicios => new SocioRepositorySQLite(rutaBaseDatos));

            builder.Services.AddSingleton<SociosViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<AppShell>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
