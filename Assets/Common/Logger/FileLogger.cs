using System;
using System.IO;

namespace Assets.Common.Logger
{
    public class FileLogger : ILogger, IDisposable
    {
        private readonly string _pathToFile;
        private StreamWriter _streamWriter;

        public FileLogger(string pathToFile, string name = "")
        {
            _pathToFile = pathToFile;
            if (!File.Exists(pathToFile))
                throw new Exception("Path to file not found!");

            if (string.IsNullOrEmpty(name))
                Name = GetType().Name;

            _streamWriter = new StreamWriter(_pathToFile, true);
        }

        public string Name { get; }

        public void Dispose()
        {
            _streamWriter.Close();
            _streamWriter.Dispose();
            _streamWriter = null;
        }

        public void Log(string message)
        {
            _ = _streamWriter.WriteLineAsync($"[ Info -> {DateTime.Now.ToFileTime()} ]: {message}");
        }

        public void LogError(string message)
        {
            _ = _streamWriter.WriteLineAsync($"[ Error -> {DateTime.Now.ToFileTime()} ]: {message}");
        }
    }
}
