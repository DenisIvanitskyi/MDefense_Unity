using Assets.Game.Components.Map;
using Assets.Game.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Game.MapGenerators
{

    public interface IChunkGenerator
    {
        string Name { get; }

        (List<BlockData> data, GameObject mapRoot) GenerateChunk(Vector2Int chunkSize);
    }

    public class SimpleLandChunkGenerator : IChunkGenerator
    {
        private readonly ItemsContainer _itemsContainer;

        public string Name => "Simple Land";

        public SimpleLandChunkGenerator(ItemsContainer itemsContainer)
        {
            _itemsContainer = itemsContainer;
        }

        public (List<BlockData> data, GameObject mapRoot) GenerateChunk(Vector2Int chunkSize)
        {
            var listOfBlocks = new List<BlockData>();
            var rootContainer = new GameObject();
            rootContainer.transform.position = new Vector3(0, 0, -1);
            GenerateStone(rootContainer, chunkSize, listOfBlocks);
            GenerateGrass(rootContainer, chunkSize, listOfBlocks);
            GenerateSand(rootContainer, chunkSize, listOfBlocks);

            return (listOfBlocks, rootContainer);
        }

        private void GenerateStone(GameObject root, Vector2 size, List<BlockData> blocks)
        {
            Foreach(size, p =>
            {
                if (p.x == 0 || p.y == 0 || p.x == size.x - 1 || p.y == size.y - 1)
                {
                    var data = CreateFromTemplate(root, _itemsContainer.Stone, p);
                    blocks.Add(data);
                }
            });
        }

        private void GenerateSand(GameObject root, Vector2 size, List<BlockData> blocks)
        {
            Foreach(size, p =>
            {
                if (!blocks.Any(b => b.BlockObject.transform.position.x == p.x && b.BlockObject.transform.position.y == p.y))
                {
                    var data = CreateFromTemplate(root, _itemsContainer.Sand, p);
                    blocks.Add(data);
                }
            });
        }

        private void GenerateGrass(GameObject root, Vector2 size, List<BlockData> blocks)
        {
            Foreach(size, p =>
            {
                if (p.x == size.x / 2 && !blocks.Any(b => b.BlockObject.transform.position.x == p.x && b.BlockObject.transform.position.y == p.y))
                {
                    var data = CreateFromTemplate(root, _itemsContainer.Grass, p);
                    blocks.Add(data);
                }
            });
        }

        private BlockData CreateFromTemplate(GameObject root, BlockUnit unit, (int x, int y) p)
        {

            var block = new GameObject();
            block.transform.SetParent(root.transform);
            block.transform.Translate(p.x, p.y, block.transform.position.z);

            var sprite = block.AddComponent<SpriteRenderer>();
            sprite.sprite = unit.Sprite;
            sprite.drawMode = SpriteDrawMode.Sliced;
            sprite.size = new Vector2(1, 1);
            
            var blockData = new BlockData() { BlockObject = block, Unit = unit };
            return blockData;
        }

        private void Foreach(Vector2 size, Action<(int x, int y)> action)
        {
            for (var y = 0; y < size.y; y++)
            {
                for (var x = 0; x < size.x; x++)
                {
                    action.Invoke((x, y));
                }
            }
        }
    }
}
