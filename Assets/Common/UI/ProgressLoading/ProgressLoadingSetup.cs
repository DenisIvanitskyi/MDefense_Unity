using Assets.Common.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assets.Common.UI.ProgressLoading
{
    public class ProgressLoadingSetup<TMark> : IProgressLoadingSetup<TMark>
    {
        private readonly List<ILoadingAction> _loadings;

        public ProgressLoadingSetup()
        {
            _loadings = new List<ILoadingAction>();
        }

        public void AddAction(string title, Func<Task> action)
        {
            _loadings.Add(new LoadingActionModel(title, action));
        }

        public void Clear()
        {
            _loadings.Clear();
        }

        public IReadOnlyList<ILoadingAction> GetAllMemLoadings()
        {
            return _loadings;
        }
    }
}
