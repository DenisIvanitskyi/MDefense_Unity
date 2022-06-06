using Assets.ECS;
using UnityEngine;

namespace Assets
{
    public class Bootstrapper : MonoBehaviour
    {
        public void Init()
        {
            var inGameWorld = new World();
            inGameWorld.AddSystem(null);
        }

        public void Start()
        {
            Init();
        }
    }
}
