using Assets.ECS;
using UnityEngine;

namespace Assets
{
    public class Bootstrapper : MonoBehaviour
    {
        public void Init()
        {
            var inGameWorld = new World();
        }

        public void Start()
        {
            Init();
        }
    }
}
