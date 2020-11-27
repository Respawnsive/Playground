using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Playground.Forms.Settings.AppSettings.Options;
using Shiny;

namespace Playground.Forms.Settings
{
    public class SettingsModule : ShinyModule
    {
        public override void Register(IServiceCollection services)
        {
            var stream = Assembly.GetAssembly(typeof(App)).GetManifestResourceStream($"{typeof(App).Namespace}.Settings.AppSettings.appsettings.json");
            if (stream != null)
            {
                var config = new ConfigurationBuilder()
                    .AddJsonStream(stream)
                    .Build();

                services.Configure<AppCenterOptions>(config.GetSection(nameof(AppCenterOptions)));

                services.AddOptions<SomeOtherOptions>()
                    .Bind(config.GetSection(nameof(SomeOtherOptions)))
                    .ValidateDataAnnotations();
            }
        }
    }
}
