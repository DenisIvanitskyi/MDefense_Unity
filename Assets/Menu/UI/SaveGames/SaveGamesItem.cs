using TMPro;
using UnityEngine;

namespace Assets.Menu.UI.SaveGames
{
    public class SaveGamesItem : MonoBehaviour
    {
        private TextMeshProUGUI _textObject;
        private string _title;

        public string Titlte
        {
            get => _title;
            set
            {
                _title = value;
                if (_textObject != null)
                    _textObject.text = value;
            }
        }

        public void Start()
        {
            _textObject = GetComponentInChildren<TextMeshProUGUI>();
            Titlte = _title;
        }
    }
}
