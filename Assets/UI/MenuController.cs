using Assets.Services.Base;
using System.Linq;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.UI
{
    public class MenuController : IInitializable, IMenuController
    {
        private GameObject _currentView = null;
        private readonly GameObject _defaulView, _newGameView, _saveGamesView, _settingsView;
        private readonly GameObject _saveGamesList;
        private readonly TMP_InputField _inputNewGameName;
        private readonly TMP_InputField _inputSearchSaveGames;
        private IGameQuit _gameQuit;
        private ILoadSaveGamesService _loadSaveGamesService;
        private ISaveGamesController _saveGamesController;
        private ILoggerService _loggerService;

        public MenuController(GameObject defaultView,
            GameObject newGameView,
            GameObject saveGamesView,
            GameObject settingsView,
            GameObject saveGamesList,
            TMP_InputField inputNewGameName,
            TMP_InputField inputSearchSaveGames)
        {
            _defaulView = defaultView;
            _newGameView = newGameView;
            _saveGamesView = saveGamesView;
            _settingsView = settingsView;
            _saveGamesList = saveGamesList;

            _inputNewGameName = inputNewGameName;
            _inputSearchSaveGames = inputSearchSaveGames;
        }

        public void Initialize()
        {
            _gameQuit = RefInstances.Container.TryResolve<IGameQuit>();
            _loadSaveGamesService = RefInstances.Container.TryResolve<ILoadSaveGamesService>();
            _saveGamesController = RefInstances.Container.TryResolve<ISaveGamesController>();
            _loggerService = RefInstances.Container.TryResolve<ILoggerService>();

            _settingsView.SetActive(false);
            _saveGamesView.SetActive(false);
            _newGameView.SetActive(false);
            DisplayMenu();
        }

        public void DisplayMenu()
        {
            ChangeCurrentView(_defaulView);
        }

        public void DisplayNewGame()
        {
            ChangeCurrentView(_newGameView);
        }

        public void DisplaySaveGames()
        {
            ChangeCurrentView(_saveGamesView);

            var games = _loadSaveGamesService.GetSaveGames();
            _saveGamesController?.Show(games.Select(e => e.Name));
        }

        public void DisplaySettings()
        {
            ChangeCurrentView(_settingsView);
        }

        public void Exit()
        {
            _gameQuit?.QuitFromGame();
        }

        private void ChangeCurrentView(GameObject view)
        {
            if (view != _currentView)
            {
                _loggerService?.Log($"Change menu view from: {_currentView} to {view}");

                _currentView?.SetActive(false);
                _currentView = view;
                _currentView.SetActive(true);
            }
        }

        public string GetNewGameName()
            => _inputNewGameName.text;

        public string GetTextFromSaveGamesSearchTb()
            => _inputSearchSaveGames.text;
    }
}
