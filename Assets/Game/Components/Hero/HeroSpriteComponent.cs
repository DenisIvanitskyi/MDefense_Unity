using Assets.Common.ECS.Interfaces;
using UnityEngine;

namespace Assets.Game.Components.Hero
{
    public class HeroSpriteComponent : IComponent
    {
        public SpriteRenderer SpriteRenderer { get; set; }
    }
}
