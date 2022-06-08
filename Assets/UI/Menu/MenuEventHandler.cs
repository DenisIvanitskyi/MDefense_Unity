
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

        [Inject]
        public void Constructor(IMenuController menuController,
            ICreateNewGame gameCreator)
        {
            _menuController = menuController;
            _gameCreator = gameCreator;
        }

        public void CreateNewGame()
        {
            var gameName = _menuController.GetNewGameName();
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
