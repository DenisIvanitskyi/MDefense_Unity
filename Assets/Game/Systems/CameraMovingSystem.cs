
using Assets.Common.ECS;
using Assets.Common.ECS.Base;
using Assets.Game.Components;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Game.Systems
{
    public class CameraMovingSystem : ECSSystem, ISystemInit, ISystemFixedUpdate
    {
        private readonly Camera _camera;
        private IEnumerable<IEntity> _filter;

        public CameraMovingSystem(Camera camera)
        {
            _camera = camera;
        }

        public void Init()
        {
            _filter = Entities.Where(e => e.Components.Any(c => c is CameraTargetComponent));
        }

        public void FixedUpdate()
        {
            foreach (var entity in _filter)
            {
                var cameraTargetComponent = entity.Components.FirstOrDefault(c => c is CameraTargetComponent) as CameraTargetComponent;
                if (_camera != null && cameraTargetComponent != null)
                {
                    var newLocation = Vector2.MoveTowards(_camera.transform.position, cameraTargetComponent.TargetPosition.position, Time.deltaTime * 5);
                    var distance = Vector2.Distance(newLocation, cameraTargetComponent.TargetPosition.position);
                    if (distance >= 0.1f)
                        _camera.transform.position = new Vector3(newLocation.x, newLocation.y, _camera.transform.position.z);
                }
            }
        }
    }
}
