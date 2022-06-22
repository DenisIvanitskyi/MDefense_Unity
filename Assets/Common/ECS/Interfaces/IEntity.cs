using Assets.Common.ECS.Interfaces;
using System;
using System.Collections.Generic;

namespace Assets.Common.ECS.Base
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
