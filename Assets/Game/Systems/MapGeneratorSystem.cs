using Assets.Common.ECS;
using Assets.Common.ECS.Base;
using Assets.Common.UI.Interfaces;
using Assets.Game.Components.Map;
using Assets.Game.MapGenerators;
using Assets.Game.Units;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game.Systems
{
    public class MapGeneratorSystem : ECSSystem, ISystemInit
    {
        private readonly GameWorld _gameWorld;
        private readonly ItemsContainer _itemsContainer;

        public MapGeneratorSystem(GameWorld gameWorld, ItemsContainer itemsContainer)
        {
            _gameWorld = gameWorld;
            _itemsContainer = itemsContainer;
        }

        public void Init()
        {
            var loadingSetup = Globals.GameDiContainer.TryResolve<IProgressLoadingSetup<GameWorld>>();
            if (loadingSetup != null)
                loadingSetup.AddAction("Generate Map", GenerateMap);
            else
                _ = GenerateMap();
        }

        private Task GenerateMap()
        {
            if (_itemsContainer != null && _gameWorld != null)
            {
                var filter = Entities.FirstOrDefault(e => e.Components.Any(c => c is MapGeneratorComponent));
                if (filter != null)
                {
                    var mapGeneratorComponent = (MapGeneratorComponent)filter.Components.FirstOrDefault(c => c is MapGeneratorComponent);

                    var simpleLandChunkGenerator = new SimpleLandChunkGenerator(_itemsContainer);
                    var chunkData = simpleLandChunkGenerator.GenerateChunk(new Vector2Int(40, 20));
                    mapGeneratorComponent.ChunkItems = chunkData.data;

                    var mapObject = chunkData.mapRoot;
                    mapObject.name = "Map";
                    mapObject.transform.SetParent(_gameWorld.transform);
                    mapObject.transform.position = new Vector3(0, 0, 1);
                }
            }

            return Task.CompletedTask;
        }
    }
}
