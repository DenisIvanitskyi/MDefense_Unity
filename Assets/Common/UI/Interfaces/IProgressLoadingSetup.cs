using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assets.Common.UI.Interfaces
{
    public interface IProgressLoadingSetup<TMark>
    {
        void AddAction(string title, Func<Task> action);

        IReadOnlyList<ILoadingAction> GetAllMemLoadings();

        void Clear();
    }
}
