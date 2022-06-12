
using Assets.Services.Base;
using UnityEngine;
using Zenject;

namespace Assets.UI.Menu
{
    public enum MenuTypes
    {
        Default,
        NewGame,
        SaveGames,
        Settings
    }

    public class MenuEventHandler : MonoBehaviour
    {

        private IMenuController _menuController;
        private ICreateNewGame _gameCreator;
        private ISaveGamesController _saveGamesController;

        [Inject]
        public void Constructor(IMenuController menuController,
            ICreateNewGame gameCreator,
            ISaveGamesController saveGamesController)
        {
            _menuController = menuController;
            _gameCreator = gameCreator;
            _saveGamesController = saveGamesController;
        }

        public void FilterForSaveGames()
        {
            var filterString = _menuController?.GetTextFromSaveGamesSearchTb() ?? string.Empty;
            if (string.IsNullOrEmpty(filterString))
                _saveGamesController?.ApplyFilter(null);
            else
                _saveGamesController?.ApplyFilter(e => e.ToLower().IndexOf(filterString.ToLower()) >= 0);
        }

        public void CheckNewGameNameRule()
        {
            _menuController?.OnNewGameTextChanged();
        }

        public void CreateNewGame()
        {
            var gameName = _menuController.GetNewGameName();
            if (!string.IsNullOrEmpty(gameName))
                _gameCreator?.CreateNewGame(gameName);
        }

        public void OpenDefaultMenu()
        {
            _menuController?.DisplayMenu();
        }

        public void OpenNewGame()
        {
            _menuController?.DisplayNewGame();
        }

        public void OpenSaveGames()
        {
            _menuController?.DisplaySaveGames();
        }

        public void OpenSettingsGame()
        {
            _menuController?.DisplaySettings();
        }

        public void ExitGame()
        {
            _menuController.Exit();
        }
    }
}
