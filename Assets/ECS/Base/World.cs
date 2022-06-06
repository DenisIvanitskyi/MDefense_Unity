
using System;
using System.Collections.Generic;

namespace Assets.ECS
{
    public class World : IWorld
    {
        private readonly List<ISystem> _systems;

        private readonly List<IEntity> _entities;

        public IReadOnlyList<ISystem> Systems => _systems;

        public IReadOnlyList<IEntity> Entities => _entities;

        public void AddSystem(ISystem system)
        {
            system.AddToWorld(this);
            _systems.Add(system);
        }

        public IEntity CreateEntity()
        {
            var entity = new Entity();
            entity.AddToWorld(this);
            _entities.Add(entity);
            return entity;
        }

        public void FixedUpdate()
        {
            for (var i = 0; i < _systems.Count; i++)
            {
                var system = _systems[i];
                if (system is ISystemFixedUpdate fixedUpdate)
                    fixedUpdate.FixedUpdate();
            }
        }

        public virtual void Init()
        {
            for (var i = 0; i < _systems.Count; i++)
            {
                var system = _systems[i];
                if (system is ISystemInit init)
                    init.Init();
            }
        }

        public void RemoveEntity(Guid entityId)
        {
            _entities.RemoveAll(e => e.Id == entityId);
        }

        public void RemoveSystem(ISystem system)
        {
            system.AddToWorld(null);
            _systems.Remove(system);
        }

        public virtual void Update()
        {
            for (var i = 0; i < _systems.Count; i++)
            {
                var system = _systems[i];
                if (system is ISystemUpdate update)
                    update.Update();
            }
        }
    }
}
