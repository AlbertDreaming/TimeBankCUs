using TimeBankCU.Views;

namespace TimeBankCU;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        
        RegisterRoutes();
    }

    private void RegisterRoutes()
    {
        Routing.RegisterRoute(nameof(CreateTaskPage), typeof(CreateTaskPage));
        Routing.RegisterRoute(nameof(TaskPage), typeof(TaskPage));
        Routing.RegisterRoute(nameof(CalendarPage), typeof(CalendarPage));
        Routing.RegisterRoute(nameof(MePage), typeof(MePage));
        


        
        // Routing.RegisterRoute(nameof(SomeDetailPage), typeof(SomeDetailPage));
    }
}