namespace Assets.Common.ECS.Base
{
    public interface IComponent
    {
        IEntity Entity { get; }

        void AddToEntity(IEntity entity);
    }
}
