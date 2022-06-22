using Assets.Common.ECS;
using Assets.Common.ECS.Base;
using Assets.Game.Components.Hero;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Game.Systems
{
    public class HUDHealthSystem : ECSSystem, ISystemInit, ISystemUpdate
    {
        private IEnumerable<IEntity> _filter;
        private float _health;

        public void Init()
        {
            _filter = World.Entities.Where(e => e.Components.Any(c => c is HeroHealthComponent));
        }

        public void Update()
        {
            foreach(var entity in _filter)
            {
                var healthComponent = entity.Components.FirstOrDefault(c => c is HeroHealthComponent) as HeroHealthComponent;
                if(healthComponent != null && _health != healthComponent.Health)
                {
                    _health = healthComponent.Health;
                }
            }
        }
    }
}
