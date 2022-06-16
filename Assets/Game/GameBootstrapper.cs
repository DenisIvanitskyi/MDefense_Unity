using Assets.Common.UI.Interfaces;
using Assets.Common.UI.ProgressLoading;
using UnityEngine;
using Zenject;

namespace Assets.Game
{
    public class GameBootstrapper : MonoInstaller
    {
        [SerializeField]
        private GameObject _loadingView;

        public override void InstallBindings()
        {
            Globals.GameDiContainer = Container;

            Container.Bind<IProgressLoadingController>()
                .To<ProgressLoadingController>()
                .FromComponentsOn(_loadingView)
                .AsSingle();
        }

        public override void Start()
        {
            base.Start();


        }
    }
}
