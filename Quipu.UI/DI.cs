using Microsoft.Extensions.DependencyInjection;
using Quipu.UI.Views;

namespace Quipu.UI
{
    public static class DI
    {
        public static void AddViews(this IServiceCollection services)
        {
            services.AddSingleton<App>();

            services.AddScoped<MainWindow>();
        }
    }
}
