using Shiny.Logging;

namespace Playground.Forms.Logging
{
    public interface IExtendedLogger : ILogger
    {
        bool IsCrashEnabled { get; }

        bool IsEventsEnabled { get; }
    }
}
