using Microsoft.Extensions.DependencyInjection;
using Quipu.Core.Services;
using Quipu.Core.Services.Interfaces;

namespace Quipu.Core
{
    public static class DI
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IValidationService, ValidationService>();
            services.AddScoped<ICalculatingService, CalculatingService>();
        }
    }
}
