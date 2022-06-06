﻿using System.Collections.Generic;

namespace Assets.ECS
{
    public class System : ISystem
    {
        public IWorld World { get; }

        public IReadOnlyList<IEntity> Entities { get; }

        public void AddToWorld(IWorld world)
        {
            world.AddSystem(this);
        }
    }
}
