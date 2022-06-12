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
        [Inject]
        private IMenuController _menuController;

        public void OpenDefaultMenu()
        {
            _menuController?.DisplayGeneralMenu();
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
