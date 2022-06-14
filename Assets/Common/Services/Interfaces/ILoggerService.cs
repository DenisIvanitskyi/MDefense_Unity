using Assets.Common.Logger;
using System.Collections.Generic;

namespace Assets.Common.Services.Interfaces
{
    public interface ILoggerService : ILogger
    {
        IReadOnlyList<ILogger> Loggers { get; }

        void AppendLogger(ILogger logger);
    }
}
