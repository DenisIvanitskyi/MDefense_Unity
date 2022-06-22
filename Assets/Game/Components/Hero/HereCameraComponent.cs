using Assets.Common.ECS.Interfaces;
using UnityEngine;

namespace Assets.Game.Components.Hero
{
    public class HeroCameraComponent : IComponent
    {
        public Camera Camera { get; set; }
    }
}
