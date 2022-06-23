using Assets.Common.ECS.Base;
using Assets.Common.ECSs;
using Assets.Common.Services.Interfaces;
using Assets.Common.UI.Interfaces;
using Assets.Game.Components;
using Assets.Game.Components.Hero;
using Assets.Game.Components.Map;
using Assets.Game.Systems;
using Assets.Game.Units;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Game
{
    public class GameWorld : MonoBehaviour, ICaroutineService
    {
        [SerializeField]
        private Camera _camera;

        [SerializeField]
        private GameObject _heroPrefab;

        private IProgressLoadingController _progressLoadingController;
        private IProgressLoadingSetup<GameWorld> _progressLoadingSetup;
        private ItemsContainer _itemsContainer;
        private IWorld _world;

        public IWorld World => _world;

        [Inject]
        public void Constructor(IProgressLoadingController progressLoadingController, 
            IProgressLoadingSetup<GameWorld> progressLoadingSetup,
            ItemsContainer itemsContainer)
        {
            _progressLoadingController = progressLoadingController;
            _progressLoadingSetup = progressLoadingSetup;
            _itemsContainer = itemsContainer;
        }


        public async void Start()
        {
            gameObject?.SetActive(false);

            Globals.GameDiContainer.Bind(typeof(GameWorld), typeof(ICaroutineService))
                .To<GameWorld>()
                .FromInstance(this)
                .AsSingle();

            _world = new World();
            
            AddSystems();
            CreateEntitiesAndAssignComponents();

            _world.Init();
            _progressLoadingSetup.AddAction("Starting Game", () => Task.Delay(TimeSpan.FromSeconds(1)));

            
            var loadings = _progressLoadingSetup.GetAllMemLoadings();
            await _progressLoadingController.StartLoading(loadings.ToArray());
            _progressLoadingSetup.Clear();
            gameObject?.SetActive(true);
        }

        private void AddSystems()
        {
            _world.AddSystem(new MapGeneratorSystem(this, _itemsContainer));
            _world.AddSystem(new HUDHealthSystem());
            _world.AddSystem(new InputMovmentSystem());
            _world.AddSystem(new HeroMovingSystem());
            _world.AddSystem(new CameraMovingSystem(_camera));
        }

        private void CreateEntitiesAndAssignComponents()
        {
            var mapEntity = _world.CreateEntity();
            mapEntity.AddComponent(new MapGeneratorComponent());

            var hero = Instantiate(_heroPrefab);
            hero.transform.localScale = new Vector3(0.9f, 0.9f, 1f);
            hero.transform.SetParent(transform);
            hero.transform.position = new Vector3(0, 0, 0);
            var heroSpriteRender = hero.GetComponent<SpriteRenderer>();

            var heroCharacter = _world.CreateEntity();
            heroCharacter.AddComponent(new HeroComponent() { Hero = "" });
            heroCharacter.AddComponent(new HeroMovableComponent() { Transform = hero.transform, VectorPosition = new Vector2() });
            heroCharacter.AddComponent(new HeroSpriteComponent() { SpriteRenderer = heroSpriteRender });
            heroCharacter.AddComponent(new CameraTargetComponent() { TargetPosition = hero.transform });
        }

        public void Update()
        {
            if (gameObject?.activeSelf == true)
            {
                _world?.Update();
            }
        }

        public void FixedUpdate()
        {
            if (gameObject?.activeSelf == true)
            {
                _world?.FixedUpdate();
            }
        }

        public void Start(IEnumerator enumerator)
            => StartCoroutine(enumerator);
    }
}
