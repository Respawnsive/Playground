using Microsoft.Extensions.DependencyInjection;
using Playground.Forms.Modules;
using Shiny;

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

            // Add Loggers
            services.RegisterModule<LoggingModule>();
        }
    }
}
