using Microsoft.Extensions.DependencyInjection;
using Playground.Forms.Modules;
using Shiny;
using Shiny.Prism;

namespace Playground.Forms
{
    public partial class Startup : PrismStartup
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            // Add Xamarin Essentials
            services.RegisterModule<EssentialsModule>();

            // Add Settings
            services.RegisterModule<SettingsModule>();

            // Add Loggers
            services.RegisterModule<LoggingModule>();

            // Add Apizr
            services.RegisterModule<WebApiModule>();

            // Add cache
            services.UseRepositoryCache();
        }
    }
}
