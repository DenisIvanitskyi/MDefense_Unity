using System;
using System.Threading.Tasks;

namespace Assets.Common.UI.Interfaces
{
    public interface ILoadingAction
    {
        string Title { get; }

        Task StartLoading();
    }
}
