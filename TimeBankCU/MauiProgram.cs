using Microsoft.Extensions.Logging;
using TimeBankCU.Services;
using TimeBankCU.Views;
using TimeBankCU.ViewModels;

namespace TimeBankCU;

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
        builder.Logging.AddDebug();
#endif

        // ✅ Inject Views & ViewModels (set ViewModels as Transient)
        
        // Register Views (Singleton is fine for Views, but should be Transient for ViewModels)
        builder.Services.AddTransient<MainPage>(); // MainPage is transient as a new instance is created for each navigation
        builder.Services.AddTransient<MePage>();
        builder.Services.AddTransient<CalendarPage>();
        builder.Services.AddTransient<TaskPage>();
        builder.Services.AddTransient<CreateTaskPage>();

        // Register ViewModels as Transient (a new instance per page navigation)
        builder.Services.AddTransient<MainViewModel>();  // MainViewModel should be transient
        builder.Services.AddTransient<MeViewModel>();
        builder.Services.AddTransient<CalendarViewModel>();
        builder.Services.AddTransient<TaskViewModel>();   // TaskViewModel should be transient
        builder.Services.AddTransient<CreateTaskViewModel>();
        

        // Add other services here as needed (e.g., ITaskStore)
        builder.Services.AddSingleton<ITaskStore, TaskStore>(); // Singleton for data services (e.g., repositories, data stores)

        builder.Services.AddSingleton<AppDatabase>(s =>
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "timebank.db3");
            return new AppDatabase(dbPath);
        });

        return builder.Build();
    }
}