using DWOW.Repositories;
using DWOW.Services;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.Logging;
using Radzen;

namespace DWOW;

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
            });
        //var config = new TypeAdapterConfig();
        //var mapperConfig = new Mapper(config);
        //builder.Services.AddSingleton<IMapper>(mapperConfig);
        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddRadzenComponents();
        builder.Services.AddScoped<INotif, Notif>();
        builder.Services.AddScoped<IQuestService,QuestService>();
        builder.Services.AddScoped<IEmployeeService,EmployeeService>();
        builder.Services.AddScoped<IRewardsService,RewardsService>();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif


        return builder.Build();
    }
}
