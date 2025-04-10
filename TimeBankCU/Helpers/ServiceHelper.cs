namespace TimeBankCU.Helpers
{
    public static class ServiceHelper
    {
        public static T GetService<T>() =>
            Current.GetService<T>() ?? throw new InvalidOperationException($"Service of type {typeof(T)} not found.");

        public static IServiceProvider Current =>
            Application.Current?.Handler?.MauiContext?.Services
            ?? throw new InvalidOperationException("MauiContext or Services is not available.");
    }
}