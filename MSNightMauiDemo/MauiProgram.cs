using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MSNightMauiDemo.Pages;
using MSNightMauiDemo.ViewModels;

namespace MSNightMauiDemo;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .RegisterPages()
            .RegisterViewModels()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    private static MauiAppBuilder RegisterPages(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<ShoppingListPage>();
        mauiAppBuilder.Services.AddSingleton<ShoppingListDetailPage>();
        return mauiAppBuilder;
    }
    
    private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<ShoppingListViewModel>();
        mauiAppBuilder.Services.AddSingleton<ShoppingListDetailViewModel>();
        return mauiAppBuilder;
    }
}