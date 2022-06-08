using Assets.Services.Base;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Zenject;

namespace Assets.Services
{
    internal class GameStorageService<T> : IInitializable, IDataStorageService<T>
    {
        private readonly string _path;
        private readonly BinaryFormatter _binaryFormatter;
        private ILoggerService _logger;

        public GameStorageService(string path, T inital)
        {
            _path = path;
            _binaryFormatter = new BinaryFormatter();
            Current = inital;
        }

        public T Current { get; set; }

        public void Initialize()
        {
            _logger = RefInstances.Container.Resolve<ILoggerService>();

            try
            {
                var directionName = Path.GetDirectoryName(_path);
                if (!Directory.Exists(directionName))
                    Directory.CreateDirectory(directionName);
            }
            catch(Exception er)
            {
                _logger?.LogError(er.Message);
            }
        }

        public void Load()
        {
            try
            {
                using (var file = File.Open(_path, FileMode.OpenOrCreate))
                {
                    Current = (T)_binaryFormatter.Deserialize(file);
                }
            }
            catch(Exception er)
            {
                _logger?.LogError(er.Message);
            }
        }

        public void Save()
        {
            try
            {
                using (var file = File.Open(_path, FileMode.OpenOrCreate))
                {
                    _binaryFormatter.Serialize(file, Current);
                }
            }
            catch(Exception er)
            {
                _logger?.LogError(er.Message);
            }
        }
    }
}
