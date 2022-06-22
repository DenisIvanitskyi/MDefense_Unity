using Assets.Common.ECS.Interfaces;
using System.Collections.Generic;

namespace Assets.Game.Components.Map
{
    public class MapGeneratorComponent : IComponent
    {
        public List<BlockData> ChunkItems { get; set; }
    }
}
