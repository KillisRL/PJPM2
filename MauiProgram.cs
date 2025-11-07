using MotoAPP.ViewModels;
using MotoAPP.Views;
using MotoAPP.Services;
using Microsoft.Extensions.Logging;

namespace MotoAPP
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

            // Registre seus Serviços
            builder.Services.AddSingleton<MotoService>();
            builder.Services.AddSingleton<UserService>();
            builder.Services.AddSingleton<MotoVM>();
            builder.Services.AddSingleton<UserVM>();


            // Registre suas Views (Páginas)
            builder.Services.AddTransient<CadMotoView>();
            builder.Services.AddTransient<VisMotoView>();
            builder.Services.AddTransient<PrincipalView>();
            builder.Services.AddTransient<LoginView>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
