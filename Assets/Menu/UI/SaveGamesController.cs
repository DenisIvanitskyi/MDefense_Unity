using Assets.Menu.UI.Base;
using Assets.Menu.UI.SaveGames;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Menu.UI
{
    public class SaveGamesController : ISaveGamesController
    {
        private GameObject _rootContent;
        private GameObject _tableItemPrefab;

        private readonly List<SaveGamesItem> _items;

        public SaveGamesController()
        {
            _items = new List<SaveGamesItem>();
        }

        public void ApplyFilter(System.Predicate<string> filter)
        {
            if (filter == null)
                _items.ForEach(e => e.gameObject.SetActive(true));
            else
                foreach (var item in _items)
                {
                    item.gameObject.SetActive(filter(item.Titlte));
                }
        }

        public void Show(IEnumerable<string> items)
        {
            _items.Clear();
            foreach (Transform child in _rootContent.transform)
            {
                Object.Destroy(child.gameObject);
            }

            foreach (var item in items)
            {
                var tableItem = Globals
                    .MenuDiContainer
                    .InstantiatePrefabForComponent<SaveGamesItem>(_tableItemPrefab, Vector3.zero, Quaternion.identity, _rootContent.transform);

                _items.Add(tableItem);
                tableItem.Titlte = item;
                var rectTransfrom = tableItem.gameObject.GetComponent<RectTransform>();
                rectTransfrom.localScale = Vector3.one; rectTransfrom.localPosition = new Vector3(rectTransfrom.localPosition.x, rectTransfrom.localPosition.y, 0);
            }
        }

        public void Setup(GameObject tabaleContentRoot, GameObject tableItemPrefab)
        {
            _rootContent = tabaleContentRoot;
            _tableItemPrefab = tableItemPrefab;
        }
    }
}
