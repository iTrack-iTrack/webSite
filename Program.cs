using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SmartWatchWeb.Services;

namespace SmartWatchWeb
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton<userState>();
            builder.Services.AddScoped<Services.UserSessionService>();
            builder.Services.AddScoped<IHealthDataService, HealthDataService>();
            builder.Services.AddScoped<IBpmStreamService, BpmStreamService>();
            builder.Services.AddScoped<userState>();


            await builder.Build().RunAsync();
        }
    }
}
