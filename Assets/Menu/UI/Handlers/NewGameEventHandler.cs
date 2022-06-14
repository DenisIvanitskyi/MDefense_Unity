using Assets.Common.Services.Interfaces;
using Assets.Menu.UI.Base;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Menu.UI.Handlers
{
    public class NewGameEventHandler : MonoBehaviour
    {
        private IValidationGameNameService _validationNameOfNewGame;
        private IGameService _gameService;
        private IMenuController _menuController;

        [SerializeField]
        private TMP_InputField _inputNameOfNewGame;

        [SerializeField]
        private TextMeshProUGUI _errorMessageAboutGameName;

        [Inject]
        public void Constructor(IValidationGameNameService validationNameOfNewGame,
            IGameService gameService,
            IMenuController menuController)
        {
            _validationNameOfNewGame = validationNameOfNewGame;
            _gameService = gameService;
            _menuController = menuController;
        }

        public void CreateNewGame()
        {
            var gameName = _inputNameOfNewGame?.text;
            if (!string.IsNullOrEmpty(gameName))
                _gameService?.CreateNewGame(gameName);
        }

        public void OnInputOfNewGameTextChanged()
        {
            if (_errorMessageAboutGameName == null) return;

            var gameName = _inputNameOfNewGame?.text;
            var isValid = _validationNameOfNewGame?.ValidatateGameName(gameName) ?? false;
            if (!isValid)
                _errorMessageAboutGameName.text = "*Game name can not be empty!";
            else
                _errorMessageAboutGameName.text = "";
        }

        public void BackToMenu()
        {
            if (_errorMessageAboutGameName != null)
                _errorMessageAboutGameName.text = "";
            if (_inputNameOfNewGame != null)
                _inputNameOfNewGame.text = "";

            _menuController?.DisplayGeneralMenu();
        }
    }
}
