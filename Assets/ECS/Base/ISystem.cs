
using System.Collections.Generic;

namespace Assets.ECS
{
    public interface ISystem
    {
        IWorld World { get; }

        IReadOnlyList<IEntity> Entities { get; }

        void AddToWorld(IWorld world);
    }
}
