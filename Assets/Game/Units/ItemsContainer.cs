using UnityEngine;

namespace Assets.Game.Units
{
    public class ItemsContainer : MonoBehaviour
    {
        [SerializeField]
        private BlockUnit _grass;

        [SerializeField]
        private BlockUnit _stone;

        [SerializeField]
        private BlockUnit _sand;

        public BlockUnit Grass => _grass;
        public BlockUnit Stone => _stone;
        public BlockUnit Sand => _sand;
    }
}
