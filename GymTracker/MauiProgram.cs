using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace GymTracker;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiCommunityToolkit();
#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddSingleton<RegisterWorkoutPage>();
        builder.Services.AddSingleton<RegisterWorkoutViewModel>();
        builder.Services.AddSingleton<ModalBoxExercisesViewModel>();
        return builder.Build();
    }
}