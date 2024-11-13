using FitTecnicoDPlus.MVVM.View;
using FitTecnicoDPlus.MVVM.ViewModel;
using FitTecnicoDPlus.Repository;
using FitTecnicoDPlus.View;
using FitTecnicoDPlus.ViewModel;
using Microsoft.Extensions.Logging;

namespace FitTecnicoDPlus
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

            builder.Services.AddTransient<ListarCliente>();
            builder.Services.AddTransient<ListarClienteViewModel>();

            builder.Services.AddTransient<CadastrarCliente>();
            builder.Services.AddTransient<CadastrarClienteViewModel>();

            builder.Services.AddTransient<EditarCliente>();
            builder.Services.AddTransient<EditarClienteViewModel>();

            builder.Services.AddSingleton<ClienteRepository>();    

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
