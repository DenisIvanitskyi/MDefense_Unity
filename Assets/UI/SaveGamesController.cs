using Assets.MB;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.UI
{
    public class SaveGamesController : ISaveGamesController
    {
        private readonly GameObject _rootContent;
        private readonly GameObject _tableItemPrefab;

        public SaveGamesController(GameObject rootContent, GameObject tableItemPrefab)
        {
            _rootContent = rootContent;
            _tableItemPrefab = tableItemPrefab;
        }

        public void Show(IEnumerable<string> items)
        {
            foreach (Transform child in _rootContent.transform)
            {
                Object.Destroy(child.gameObject);
            }

            foreach (var item in items)
            {
                var tableItem = RefInstances
                    .Container
                    .InstantiatePrefabForComponent<SaveGamesItem>(_tableItemPrefab, Vector3.zero, Quaternion.identity, _rootContent.transform);
                
                tableItem.Titlte = item;
                var rectTransfrom = tableItem.gameObject.GetComponent<RectTransform>();
                rectTransfrom.localScale = Vector3.one;
                rectTransfrom.localPosition = new Vector3(rectTransfrom.localPosition.x, rectTransfrom.localPosition.y, 0);
            }
        }
    }
}
