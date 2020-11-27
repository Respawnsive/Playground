using Microsoft.Extensions.DependencyInjection;
using Playground.Forms.Settings;
using Shiny;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;

namespace Playground.Forms
{
    public partial class Startup : ShinyStartup
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            // Add Xamarin Essentials
            services.AddTransient<IAppInfo, AppInfoImplementation>();

            // Add config options
            services.RegisterModule<SettingsModule>();
        }
    }
}
