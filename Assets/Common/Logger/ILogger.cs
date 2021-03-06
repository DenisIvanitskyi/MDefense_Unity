namespace Assets.Common.Logger
{
    public interface ILogger
    {
        string Name { get; }

        void Log(string message);

        void LogError(string message);
    }
}
