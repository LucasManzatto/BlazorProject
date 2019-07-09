using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Blazorise.Material;
using Blazorise.Icons.Material;
using Blazor.Realm.ReduxDevTools.Extensions;
using Blazor.Realm.Extensions;
using BlazorProject.Client.Redux;
using Blazor.Realm;

namespace BlazorProject.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRealmReduxDevToolServices();
            services.AddRealmStore(new State(), Reducers.RootReducer);
        }

        public void Configure(IComponentsApplicationBuilder app, IStoreBuilder<State> RealmStoreBuilder)
        {
            RealmStoreBuilder.UseRealmReduxDevTools(new System.Type[]{
                typeof(Redux.Actions.Pokemon.Dispose)
            });
            app.AddComponent<App>("app");
        }
    }
}
