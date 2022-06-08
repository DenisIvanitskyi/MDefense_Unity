
using Assets.Logger;
using System.Collections.Generic;

namespace Assets.Services.Base
{
    public interface ILoggerService : ILogger
    {
        IReadOnlyList<ILogger> Loggers { get; }

        void AppendLogger(ILogger logger);
    }
}
