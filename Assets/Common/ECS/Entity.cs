using Assets.Common.ECS.Base;
using Assets.Common.ECS.Interfaces;
using System;
using System.Collections.Generic;

namespace Assets.Common.ECS
{
    public class Entity : IEntity
    {
        private readonly List<IComponent> _components;

        public Entity()
        {
            Id = Guid.NewGuid();
            _components = new List<IComponent>();
        }

        public Guid Id { get; }

        public IWorld World { get; private set; }

        public IReadOnlyList<IComponent> Components => _components;

        public void AddComponent(IComponent component)
        {
            _components.Add(component);
        }

        public void AddToWorld(IWorld world)
        {
            World = world;
        }

        public void RemoveComponent(IComponent component)
        {
            _components.Remove(component);
        }
    }
}
