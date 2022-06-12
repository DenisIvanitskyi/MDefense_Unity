using Assets.Services.Base;
using Assets.UI.Base;
using UnityEngine;
using Zenject;

namespace Assets.UI
{
    public class MenuController : IInitializable, IMenuController
    {
        private GameObject _currentView = null;
        private readonly GameObject _defaulView, _newGameView, _saveGamesView, _settingsView;
        private IGameQuitPartService _gameQuit;
        private ILoggerService _loggerService;

        public MenuController(GameObject defaultView,
            GameObject newGameView,
            GameObject saveGamesView,
            GameObject settingsView)
        {
            _defaulView = defaultView;
            _newGameView = newGameView;
            _saveGamesView = saveGamesView;
            _settingsView = settingsView;
        }

        public void Initialize()
        {
            _gameQuit = RefInstances.Container.TryResolve<IGameQuitPartService>();
            _loggerService = RefInstances.Container.TryResolve<ILoggerService>();

            _settingsView.SetActive(false);
            _saveGamesView.SetActive(false);
            _newGameView.SetActive(false);

            DisplayGeneralMenu();
        }

        public void DisplayGeneralMenu()
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
            _gameQuit?.QuitGame();
        }

        private void ChangeCurrentView(GameObject view)
        {
            if (view != _currentView)
            {
                _loggerService?.Log($"Change menu view from: {_currentView} to {view}");

                if (_currentView != null && _currentView.TryGetComponent<IDeactivateView>(out var deactivateView))
                    deactivateView.OnDeactivateItem();
                _currentView?.SetActive(false);

                _currentView = view;

                _currentView?.SetActive(true);
                if (_currentView != null && _currentView.TryGetComponent<IActivateView>(out var activateItem))
                    activateItem.OnActivateItem();
            }
        }
    }
}
