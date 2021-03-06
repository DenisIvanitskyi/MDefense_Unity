using Assets.Common.ECS;
using Assets.Common.ECS.Base;
using Assets.Game.Components.Hero;
using Assets.Game.Components.Map;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Game.Systems
{
    public class HeroMovingSystem : ECSSystem, ISystemInit, ISystemFixedUpdate
    {
        private IEnumerable<IEntity> _filter;

        public void Init()
        {
            _filter = Entities.Where(e => e.Components.Any(c => c is HeroMovableComponent));
        }

        public void FixedUpdate()
        {
            foreach (var entity in _filter)
            {
                var movableComponent = entity.Components.FirstOrDefault(c => c is HeroMovableComponent) as HeroMovableComponent;
                if (movableComponent != null
                    && movableComponent.TargetData.BlockObject != null 
                    && movableComponent.TargetData.Unit != null
                    && movableComponent.IsMoving)
                {
                    MoveToTarget(movableComponent.TargetData, movableComponent);
                }
            }
        }

        private void MoveToTarget(BlockData block, HeroMovableComponent heroMovableComponent)
        {
            var newPosition = Vector2.MoveTowards(heroMovableComponent.Transform.position,
                    block.BlockObject.transform.position, Time.fixedDeltaTime * heroMovableComponent.Speed);
            heroMovableComponent.Transform.position = new Vector3(newPosition.x, newPosition.y, heroMovableComponent.Transform.position.z);
            if (Vector2.Distance(newPosition, block.BlockObject.transform.position) <= 0.5f)
            {
                heroMovableComponent.IsMoving = false;
                heroMovableComponent.Transform.position = new Vector2(block.BlockObject.transform.position.x, block.BlockObject.transform.position.y);
                heroMovableComponent.VectorPosition = heroMovableComponent.Transform.position;
            }

        }
    }
}
