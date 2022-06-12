using Assets.Models;
using Assets.Services.Base;
using System;
using System.Collections.Generic;
using Zenject;

namespace Assets.Services
{
    public class GameService : IInitializable, IGameService
    {
        private readonly Action _onGameQuit;
        private ILoggerService _logger;
        private IDataStorageService<List<GameModel>> _dataStorage;

        public GameService(Action onGameQuit)
        {
            _onGameQuit = onGameQuit ?? throw new ArgumentNullException(nameof(onGameQuit));
        }

        public Guid CreateNewGame(string gameName)
        {
            var newGameModel = new GameModel() { Id = Guid.NewGuid(), Name = gameName, CreatedTime = DateTime.Now };
            _dataStorage.Current.Add(newGameModel);
            _dataStorage.Save();
            return newGameModel.Id;
        }

        public void DeleteGame(Guid id)
        {
            _dataStorage.Current.RemoveAll(e => e.Id == id);
            _dataStorage.Save();
        }

        public List<GameModel> GetGames()
        {
            _dataStorage.Load();
            return new List<GameModel>(_dataStorage.Current);
        }

        public void Initialize()
        {
            _logger = RefInstances.Container.Resolve<ILoggerService>();
            _dataStorage = RefInstances.Container.Resolve<IDataStorageService<List<GameModel>>>();

            _dataStorage.Load();
        }

        public void QuitGame()
        {
            _logger.Log($"Invoke {nameof(GameService.QuitGame)}");
            _onGameQuit?.Invoke();
        }
    }
}
