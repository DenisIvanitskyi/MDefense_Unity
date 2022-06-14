using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Menu.UI.Base
{
    public interface ISaveGamesController
    {
        void Setup(GameObject tabaleContentRoot, GameObject tableItemPrefab);

        void ApplyFilter(Predicate<string> filter);

        void Show(IEnumerable<string> items);
    }
}
