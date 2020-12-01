using System;
using System.Linq;
using Prism.Services;
using Shiny;

namespace Playground.Forms.Settings.AppSettings
{
    public abstract class AppSettingsBase
    {
        private readonly Lazy<IDeviceService> _lazyDeviceService;

        protected AppSettingsBase()
        {
            // This one can't be injected as constructor must be parameter-less
            _lazyDeviceService = ShinyHost.LazyResolve<IDeviceService>();
        }

        /// <summary>
        /// Extract current platform value from a merged formatted key aka android={android_value};ios={ios_value}
        /// </summary>
        /// <param name="sourceValue">The formatted source key</param>
        /// <returns>The current platform value</returns>
        protected string GetPlatformValue(ref string sourceValue)
        {
            if (string.IsNullOrWhiteSpace(sourceValue) || !sourceValue.Contains(";") || !sourceValue.Contains("="))
                return sourceValue;

            return sourceValue = sourceValue.Split(';')
                .Select(x => x.Split('='))
                .FirstOrDefault(x => x[0] == _lazyDeviceService.Value.RuntimePlatform
                    .ToString()
                    .ToLower())?[1];
        }
    }
}
