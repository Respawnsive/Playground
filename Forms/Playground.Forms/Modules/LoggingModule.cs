using System;
using Microsoft.Extensions.DependencyInjection;
using Playground.Forms.Logging;
using Shiny;
using Shiny.Logging;

namespace Playground.Forms.Modules
{
    public class LoggingModule : ShinyModule
    {
        public override void Register(IServiceCollection services)
        {
#if DEBUG
            services.AddSingleton<ILogger, DebugLogger>();
            services.AddSingleton<ILogger, ConsoleLogger>();
#endif
            services.AddSingleton<ILogger, LimitedFileLogger>();
            services.AddSingleton<ILogger, AppCenterLogger>();
        }

        public override void OnContainerReady(IServiceProvider services)
        {
            var loggers = services.GetServices<ILogger>();
            foreach (var logger in loggers)
            {
                Log.AddLogger(logger, 
                    (logger as IExtendedLogger)?.IsCrashEnabled ?? true,
                    (logger as IExtendedLogger)?.IsEventsEnabled ?? true);
            }
        }
    }
}
