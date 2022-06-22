using Assets.Common.ECS.Base;
using System.Collections.Generic;

namespace Assets.Common.ECS
{
    public class ECSSystem : ISystem
    {
        public IWorld World { get; private set; }

        public IReadOnlyList<IEntity> Entities => World.Entities;

        public void AddToWorld(IWorld world)
        {
            World = world;
        }
    }
}
