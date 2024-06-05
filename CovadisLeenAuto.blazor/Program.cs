using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DemoCovadis.Shared.Clients;
using DemoCovadis.Blazor.Services;
using Microsoft.AspNetCore.Components.Authorization;
using DemoCovadis.Blazor.Handler;
using DemoCovadis.Shared.Interfaces;
using DemoCovadis.Blazor;
using DemoCovadis.Shared.Clients;

namespace DemoCovadis.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped<LocalStorageService>();
            builder.Services.AddScoped<ICurrentUserContext, CurrentUserContext>();

            builder.Services.AddScoped<AuthorizationMessageHandler>();

            builder.Services.AddScoped<UserHttpClient>();
            builder.Services.AddHttpClient(nameof(UserHttpClient)).AddHttpMessageHandler<AuthorizationMessageHandler>();

            builder.Services.AddScoped<AuthHttpClient>();

            builder.Services.AddScoped<DemoCovadisAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<DemoCovadisAuthenticationStateProvider>());
            builder.Services.AddAuthorizationCore();

            await builder.Build().RunAsync();
        }
    }
}