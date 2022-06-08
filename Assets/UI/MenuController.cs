using Assets.Services.Base;
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
        private IGameQuit _gameQuit;

        public MenuController(GameObject defaultView,
            GameObject newGameView,
            GameObject saveGamesView,
            GameObject settingsView,
            GameObject saveGamesList,
            TMP_InputField inputNewGameName)
        {
            _defaulView = defaultView;
            _newGameView = newGameView;
            _saveGamesView = saveGamesView;
            _settingsView = settingsView;
            _saveGamesList = saveGamesList;
            _inputNewGameName = inputNewGameName;
        }

        public void Initialize()
        {
            _gameQuit = RefInstances.Container.TryResolve<IGameQuit>();
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
                _currentView?.SetActive(false);
                _currentView = view;
                _currentView.SetActive(true);
            }
        }

        public string GetNewGameName()
            => _inputNewGameName.text;
    }
}
