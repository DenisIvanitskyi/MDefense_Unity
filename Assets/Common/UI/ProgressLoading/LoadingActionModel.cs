using Assets.Common.UI.Interfaces;
using System;
using System.Threading.Tasks;

namespace Assets.Common.UI.ProgressLoading
{
    internal class LoadingActionModel : ILoadingAction
    {
        private readonly Func<Task> _funcTask;

        public LoadingActionModel(string title, Func<Task> funcTask)
        {
            Title = title;
            _funcTask = funcTask;
        }

        public string Title { get; }

        public Task StartLoading()
            => _funcTask?.Invoke();
    }
}
