using Microsoft.Extensions.DependencyInjection;
using Shiny;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;

namespace Playground
{
    public partial class Startup : ShinyStartup
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            // Add Xamarin Essentials
            services.AddTransient<IAppInfo, AppInfoImplementation>();
        }
    }
}
