
namespace Assets.ECS
{
    public interface IComponent
    {
        IEntity Entity { get; }

        void AddToEntity(IEntity entity);
    }
}
