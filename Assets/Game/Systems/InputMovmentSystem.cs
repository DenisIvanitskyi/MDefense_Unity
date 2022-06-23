using Assets.Common.ECS;
using Assets.Common.ECS.Base;
using Assets.Game.Components.Hero;
using Assets.Game.Components.Map;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Game.Systems
{
    public class InputMovmentSystem : ECSSystem, ISystemInit, ISystemUpdate
    {
        private IEnumerable<IEntity> _filter;
        private IEntity _mapEntity;

        public void Init()
        {
            _filter = Entities.Where(e => e.Components.Any(c => c is HeroMovableComponent));
            _mapEntity = Entities.FirstOrDefault(e => e.Components.Any(c => c is MapGeneratorComponent));
        }

        public void Update()
        {
            var leftPressed = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
            var rightPressed = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
            var upPressed = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
            var downPressed = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);

            if (leftPressed || rightPressed || upPressed || downPressed)
            {
                var offset = new Vector2Int(leftPressed ? -1 : (rightPressed ? 1 : 0), upPressed ? 1 : (downPressed ? -1 : 0));
                var mapGeneratorComponent = (MapGeneratorComponent)_mapEntity.Components.FirstOrDefault(c => c is MapGeneratorComponent);
                foreach (var item in _filter)
                {
                    var movableComponent = (HeroMovableComponent)item.Components.FirstOrDefault(c => c is HeroMovableComponent);
                    var nextPosition = movableComponent.VectorPosition + offset;
                    var block = mapGeneratorComponent.ChunkItems.Find(e =>
                            e.BlockObject.transform.position.x == nextPosition.x
                            && e.BlockObject.transform.position.y == nextPosition.y);
                    if (block.BlockObject != null && block.Unit.Height <= 1)
                    {
                        movableComponent.IsMoving = true;
                        movableComponent.TargetData = block;
                    }
                }
            }
        }


    }
}
