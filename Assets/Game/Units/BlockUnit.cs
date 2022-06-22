using Assets.Game.Block;
using UnityEngine;

namespace Assets.Game.Units
{
    [CreateAssetMenu(fileName = "Block", menuName = "GameUnit/Block", order = 1)]
    public class BlockUnit : GameUnit
    {
        [SerializeField]
        private float _height;

        public float Height
        {
            get => _height;
            set => _height = value;
        }
    }
}
