using Assets.Common.ECS.Interfaces;
using UnityEngine;

namespace Assets.Game.Components
{
    public class CameraTargetComponent : IComponent
    {
        public Transform TargetPosition { get; set; }
    }
}
