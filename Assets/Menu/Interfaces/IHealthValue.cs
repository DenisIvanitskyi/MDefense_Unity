using System;

namespace Assets.Menu.Interfaces
{
    public interface IHealthValue
    {
        Action<float> OnHealthChanged { get; }

        float Health { get; }
    }
}
