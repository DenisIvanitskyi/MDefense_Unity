using System.Collections.Generic;

namespace Assets.Common.ECS.Base
{
    public interface ISystem
    {
        IWorld World { get; }

        IReadOnlyList<IEntity> Entities { get; }

        void AddToWorld(IWorld world);
    }
}
