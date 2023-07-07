using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using Quipu.Core;

namespace Quipu.UI
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            IHostBuilder hostBuilder = Host.CreateDefaultBuilder();
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddCoreServices();
                    services.AddViews();
                })
                .Build();


            var app = host.Services.GetService<App>();
            app?.Run();
        }
    }
}
