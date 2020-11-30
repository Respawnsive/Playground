using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Playground.Forms.Settings.AppSettings;
using Playground.Forms.Settings.SessionSettings;
using Shiny;

namespace Playground.Forms.Settings
{
    public class SettingsModule : ShinyModule
    {
        public override void Register(IServiceCollection services)
        {
            // App settings loaded from Json files (readonly)
            var stream = Assembly.GetAssembly(typeof(App)).GetManifestResourceStream($"{typeof(App).Namespace}.Settings.AppSettings.JsonSettings.appsettings.json");
            if (stream != null)
            {
                var config = new ConfigurationBuilder()
                    .AddJsonStream(stream)
                    .Build();

                services.Configure<AppCenterSettings>(config.GetSection(nameof(AppCenterSettings)), options => options.BindNonPublicProperties = true);

                services.AddOptions<SomeAppSettings>()
                    .Bind(config.GetSection(nameof(SomeAppSettings)), options => options.BindNonPublicProperties = true)
                    .ValidateDataAnnotations();
            }

            // User settings (saved)

            // Session settings (App lifetime)
            services.Configure<SomeSessionSettings>(o => { });
            //services.AddOptions<SomeSessionSettings>();
        }
    }
}
