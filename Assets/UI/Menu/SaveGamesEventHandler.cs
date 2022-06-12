using Assets.Services.Base;
using System.Linq;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.UI.Menu
{
    public class SaveGamesEventHandler : MonoBehaviour, IActivateView
    {
        private IMenuController _menuController;
        private IGetAllGamesPartSerivce _getGamesPartService;
        private ISaveGamesController _saveGamesController;

        [SerializeField]
        private TMP_InputField _inputSearch;

        [SerializeField]
        private GameObject _listOfSavedGames;

        [SerializeField]
        private GameObject _tableItemPrefab;
        private bool _isInitialStarted;

        [Inject]
        public void Constructor(IMenuController menuController,
            IGetAllGamesPartSerivce getGamesPartService,
            ISaveGamesController saveGamesController)
        {
            _menuController = menuController;
            _getGamesPartService = getGamesPartService;
            _saveGamesController = saveGamesController;
        }

        public void Start()
        {
            _saveGamesController?.Setup(_listOfSavedGames, _tableItemPrefab);
            RefreshGames();
            _isInitialStarted = true;
        }

        public void OnInputSearchTextChanged()
        {
            var filter = (_inputSearch?.text ?? string.Empty).ToLower();
            if (string.IsNullOrEmpty(filter))
                _saveGamesController.ApplyFilter(null);
            else
                _saveGamesController?.ApplyFilter(e => e.ToLower().IndexOf(filter) >= 0);
        }

        public void BackToMenu()
        {
            if (_inputSearch != null)
                _inputSearch.text = "";

            _menuController?.DisplayGeneralMenu();
        }

        private void RefreshGames()
        {
            var games = _getGamesPartService?.GetGames();
            _saveGamesController?.Show(games.Select(e => e.Name));
        }

        public void OnActivateItem()
        {
            if (_isInitialStarted)
                RefreshGames();
        }
    }
}
