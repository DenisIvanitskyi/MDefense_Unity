using Assets.Logger;
using Assets.Services.Base;
using System.Collections.Generic;

namespace Assets.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly List<ILogger> _loggers;
        private readonly string _name;

        public IReadOnlyList<ILogger> Loggers => _loggers;

        public string Name => _name;

        public LoggerService(params ILogger[] loggers)
        {
            _loggers = new List<ILogger>(loggers);
        }

        public void AppendLogger(ILogger logger)
        {
            _loggers.Add(logger);
        }

        public void Log(string message)
        {
            foreach (var logger in _loggers)
                logger.Log(message);
        }

        public void LogError(string message)
        {
            foreach (var logger in _loggers)
                logger.LogError(message);
        }
    }
}
