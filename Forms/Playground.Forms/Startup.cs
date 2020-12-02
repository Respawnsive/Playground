using Microsoft.Extensions.DependencyInjection;
using Playground.Forms.Modules;
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
            services.RegisterModule<EssentialsModule>();

            // Add Settings
            services.RegisterModule<SettingsModule>();
        }
    }
}
