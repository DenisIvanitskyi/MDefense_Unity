using Assets.Common.UI.Interfaces;
using Assets.Common.UI.ProgressLoading;
using Assets.Game.Units;
using UnityEngine;
using Zenject;

namespace Assets.Game
{
    public class GameBootstrapper : MonoInstaller
    {
        [SerializeField]
        private GameObject _loadingView;

        [SerializeField]
        private GameObject _gameObject;

        public override void InstallBindings()
        {
            Globals.GameDiContainer = Container;

            Container.Bind<IProgressLoadingController>()
                .To<ProgressLoadingController>()
                .FromComponentsOn(_loadingView)
                .AsSingle();

            Container.Bind<IProgressLoadingSetup<GameWorld>>()
                .To<ProgressLoadingSetup<GameWorld>>()
                .AsSingle();

            Container.Bind<ItemsContainer>()
                .To<ItemsContainer>()
                .FromComponentOn(_gameObject)
                .AsSingle();
        }

        public override void Start()
        {
            base.Start();
        }
    }
}
