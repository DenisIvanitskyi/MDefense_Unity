
using System;
using System.Collections.Generic;

namespace Assets.UI
{
    public interface ISaveGamesController
    {
        void ApplyFilter(Predicate<string> filter);

        void Show(IEnumerable<string> items);
    }
}
