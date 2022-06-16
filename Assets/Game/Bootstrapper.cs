using Assets.Common.UI.ProgressLoading;
using UnityEngine;
using Zenject;

namespace Assets.Game
{
    public class Bootstrapper : MonoInstaller
    {
        [SerializeField]
        private GameObject _loadingViewPrefab;

        public override void InstallBindings()
        {
            Globals.GameDiContainer = Container;

            Container.Bind<ProgressLoadingController>()
                .FromComponentsInNewPrefab(_loadingViewPrefab)
                .AsCached();
        }

        public override void Start()
        {
            base.Start();


        }
    }
}
