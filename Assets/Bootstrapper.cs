using Assets.Logger;
using Assets.Models;
using Assets.Services;
using Assets.Services.Base;
using Assets.UI;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;
using ILogger = Assets.Logger.ILogger;

namespace Assets
{
    public class Bootstrapper : MonoInstaller
    {
        [SerializeField]
        private GameObject _defaultMenuView,
            _newGameMenuView, _saveGamesMenuView, _settingsMenuView;

        [SerializeField]
        private GameObject _saveGamesContent;

        [SerializeField]
        private TMP_InputField _inputNewGameName, _inputSearchSaveGames;

        [SerializeField]
        private GameObject _listItemPrefab;

        [SerializeField]
        private TextMeshProUGUI _errorMessageOnCreateGameView;

        public override void InstallBindings()
        {
            RefInstances.Container = Container;

            var loggerService = new LoggerService(GetLoggert());
            Container.Bind<ILoggerService>()
                .To<LoggerService>()
                .FromInstance(loggerService)
                .AsSingle();

            Container.Bind<IValidationGameNameService>()
                .To<ValidationService>()
                .AsSingle();

            Container.Bind(typeof(IGameQuitPartService), 
                    typeof(IGameService), typeof(IGetAllGamesPartSerivce), typeof(IInitializable))
                .To<GameService>()
                .AsSingle()
                .WithArguments<Action>(QuitGame)
                .NonLazy();

            Container.Bind(typeof(IDataStorageService<List<GameModel>>), typeof(IInitializable))
                .To<GameStorageService<List<GameModel>>>()
                .FromInstance(new GameStorageService<List<GameModel>>(Application.persistentDataPath + "/db/games.dat", new List<GameModel>()))
                .AsSingle();
                

            Container.Bind(typeof(IMenuController), typeof(IInitializable))
                .To<MenuController>()
                .FromInstance(new MenuController(_defaultMenuView, _newGameMenuView, _saveGamesMenuView, _settingsMenuView, _saveGamesContent, 
                    _inputNewGameName, _inputSearchSaveGames, _errorMessageOnCreateGameView))
                .AsSingle();

            Container.Bind<ISaveGamesController>()
                .To<SaveGamesController>()
                .AsSingle()
                .WithArguments(_saveGamesContent, _listItemPrefab);

            loggerService.Log("Bootstrapper init!");
        }

        private ILogger[] GetLoggert()
        {
            return new ILogger[] {
                new UnityLogger(),
                //new FileLogger("Assert/Resources/Logger/Logs.txt")
            };
        }

        private void QuitGame()
        {
            Application.Quit();
        }
    }
}
