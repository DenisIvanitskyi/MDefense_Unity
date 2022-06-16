
using Assets.Common.UI.ProgressLoading;
using System.Threading.Tasks;

namespace Assets.Common.UI.Interfaces
{
    public interface IProgressLoadingController
    {
        Task<LoadingInfoResult> StartLoading(params ILoadingAction[] loadingAction);
    }
}
