using Assets.Menu.Interfaces;
using System;

namespace Assets.Menu.Enemies.Interfaces
{
    public interface IEnemy : IGameEntity
    {
        Guid CategoryId { get; }
    }
}
