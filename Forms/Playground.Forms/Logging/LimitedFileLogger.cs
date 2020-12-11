using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Options;
using Playground.Forms.Settings.AppSettings;
using Shiny.IO;
using Shiny.Logging;

namespace Playground.Forms.Logging
{
    public class LimitedFileLogger : ILogger
    {
        private readonly object _syncLock = new object();
        private readonly string _filePath;
        private readonly int _maxLines;

        public LimitedFileLogger(IOptions<FileLoggerSettings> fileLoggerSettings, IFileSystem fileSystem)
        {
#if DEBUG
            _filePath = Path.Combine(fileSystem.Public.FullName, fileLoggerSettings.Value.LogFileName);
#else
            _filePath = Path.Combine(fileSystem.AppData.FullName, fileLoggerSettings.Value.LogFileName);
#endif
            _maxLines = fileLoggerSettings.Value.LogFileMaxLines;
        }

        public void Write(Exception exception, params (string Key, string Value)[] parameters)
        {
            var message = $@"[{DateTime.Now:MM/d/yyyy hh:mm:ss tt}] {exception}";

            Write(message);
        }


        public void Write(string eventName, string description, params (string Key, string Value)[] parameters)
        {
            var message = $@"[{DateTime.Now:MM/d/yyyy hh:mm:ss tt}] {eventName}";
            if (!string.IsNullOrWhiteSpace(description))
                message += $" - {description}";

            Write(message);
        }

        private void Write(string message)
        {
            lock (_syncLock)
            {
                if (!File.Exists(_filePath))
                {
                    File.AppendAllText(_filePath, message);
                    return;
                }

                var logEntries = File.ReadAllLines(_filePath).ToList();

                logEntries.Add(message);

                while (logEntries.Count > _maxLines)
                    logEntries.RemoveAt(0);

                File.WriteAllLines(_filePath, logEntries);
            }
        }
    }
}
