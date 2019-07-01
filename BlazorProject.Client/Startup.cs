using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Blazorise;
using Blazorise.Material;
using Blazorise.Icons.Material;

namespace BlazorProject.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddBlazorise(options =>
                {
                    options.ChangeTextOnKeyPress = true;
                }) // from v0.6.0-preview4
                .AddMaterialProviders()
                .AddMaterialIcons();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.
                UseMaterialProviders()
                .UseMaterialIcons();
            app.AddComponent<App>("app");
        }
    }
}
