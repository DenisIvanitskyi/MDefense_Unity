using Assets.Common.Logger;
using Assets.Common.Models;
using Assets.Common.Services;
using Assets.Common.Services.Interfaces;
using Assets.Menu.UI;
using Assets.Menu.UI.Base;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ILogger = Assets.Common.Logger.ILogger;

namespace Assets.Menu
{
    public class Bootstrapper : MonoInstaller
    {
        [SerializeField]
        private GameObject _defaultMenuView,
            _newGameMenuView, _saveGamesMenuView, _settingsMenuView;

        public override void InstallBindings()
        {
            Globals.MenuDiContainer = Container;

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
                .FromInstance(new MenuController(_defaultMenuView, _newGameMenuView, _saveGamesMenuView, _settingsMenuView))
                .AsSingle();

            Container.Bind<ISaveGamesController>()
                .To<SaveGamesController>()
                .AsSingle();

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
