﻿using System;
using System.Collections.Generic;

namespace Assets.ECS
{
    public interface IEntity
    {
        Guid Id { get; }

        IWorld World { get; }

        IReadOnlyList<IComponent> Components { get; }

        void AddComponent(IComponent component);

        void RemoveComponent(IComponent component);

        void AddToWorld(IWorld world);
    }
}
