using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Playground.Forms.Options;
using Shiny;

namespace Playground.Forms.Modules
{
    public class OptionsModule : ShinyModule
    {
        public override void Register(IServiceCollection services)
        {
            var stream = Assembly.GetAssembly(typeof(App)).GetManifestResourceStream($"{typeof(App).Namespace}.Options.AppSettings.appsettings.json");
            if (stream != null)
            {
                var config = new ConfigurationBuilder()
                    .AddJsonStream(stream)
                    .Build();

                services.AddOptions<FirstOptions>()
                    .Bind(config.GetSection(FirstOptions.Section))
                    .ValidateDataAnnotations();
            }
        }
    }
}
