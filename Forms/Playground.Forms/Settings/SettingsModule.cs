using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Playground.Forms.Settings.App;
using Playground.Forms.Settings.Session;
using Playground.Forms.Settings.User;
using Shiny;

namespace Playground.Forms.Settings
{
    public class SettingsModule : ShinyModule
    {
        public override void Register(IServiceCollection services)
        {
            // App settings (loaded from embedded json file)
            var stream = Assembly.GetAssembly(typeof(Forms.App)).GetManifestResourceStream($"{typeof(Forms.App).Namespace}.Settings.App.Files.appsettings.json");
            if (stream != null)
            {
                var config = new ConfigurationBuilder()
                    .AddJsonStream(stream)
                    .Build();

                // Add all section settings here
                services.Configure<AppCenterSettings>(config.GetSection(nameof(AppCenterSettings)), options => options.BindNonPublicProperties = true);

                services.AddOptions<SomeAppSettings>()
                    .Bind(config.GetSection(nameof(SomeAppSettings)), options => options.BindNonPublicProperties = true)
                    .ValidateDataAnnotations();
            }

            // User settings (saved to device preferences)
            services.AddOptions<UserAccountSettings>();
            services.AddOptions<UserPreferencesSettings>();

            // Session settings (kept in-memory during app lifetime)
            services.AddOptions<SomeSessionSettings>();
            services.AddOptions<SomeOtherSessionSettings>();
        }
    }
}
