using System;
using System.Collections.Generic;

namespace Assets.Common.ECS.Base
{
    public interface IWorld
    {
        IReadOnlyList<ISystem> Systems { get; }

        IReadOnlyList<IEntity> Entities { get; }

        void AddSystem(ISystem system);

        void RemoveSystem(ISystem system);

        void RemoveEntity(Guid entityId);

        IEntity CreateEntity();

        void Init();

        void Update();

        void FixedUpdate();
    }
}
