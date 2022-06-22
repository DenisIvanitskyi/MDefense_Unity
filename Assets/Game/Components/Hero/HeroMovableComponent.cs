using Assets.Common.ECS.Interfaces;
using Assets.Game.Components.Map;
using UnityEngine;

namespace Assets.Game.Components.Hero
{
    public class HeroMovableComponent : IComponent
    {
        public float Speed { get; set; }

        public Transform Transform { get; set; }

        public BlockData TargetData { get; set; }
    }
}
