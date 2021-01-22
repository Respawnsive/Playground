using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Playground.Forms.Settings.AppSettings;
using Playground.Forms.Settings.SessionSettings;
using Playground.Forms.Settings.UserSettings;
using Shiny;

namespace Playground.Forms.Modules
{
    public class SettingsModule : ShinyModule
    {
        public override void Register(IServiceCollection services)
        {
            // AppSettings (loaded from embedded json settings files to readonly properties)
            var stream = Assembly.GetAssembly(typeof(App)).GetManifestResourceStream($"{typeof(App).Namespace}.Settings.AppSettings.SettingsFiles.appsettings.json");
            if (stream != null)
            {
                var config = new ConfigurationBuilder()
                    .AddJsonStream(stream)
                    .Build();

                // Add all settings sections here
                services.Configure<AppCenterSettings>(config.GetSection($"Logging:{nameof(AppCenterSettings)}"), options => options.BindNonPublicProperties = true);
                services.Configure<FileLoggerSettings>(config.GetSection($"Logging:{nameof(FileLoggerSettings)}"), options => options.BindNonPublicProperties = true);
                services.AddOptions<SomeAppSettings>()
                    .Bind(config.GetSection(nameof(SomeAppSettings)), options => options.BindNonPublicProperties = true)
                    .ValidateDataAnnotations();
                services.Configure<TheMovieDbSettings>(config.GetSection(nameof(TheMovieDbSettings)), options => options.BindNonPublicProperties = true);
            }

            // UserSettings (sync with device preferences)
            services.AddOptions<UserAccountSettings>();
            services.AddOptions<UserProfileSettings>();

            // SessionSettings (kept in-memory during app lifetime)
            services.AddOptions<SomeSessionSettings>();
            services.AddOptions<SomeOtherSessionSettings>();
        }
    }
}
