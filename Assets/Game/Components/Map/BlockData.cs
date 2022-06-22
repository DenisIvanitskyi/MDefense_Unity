using Assets.Game.Units;
using UnityEngine;

namespace Assets.Game.Components.Map
{
    public struct BlockData
    {
        public BlockUnit Unit { get; set; }

        public GameObject BlockObject { get; set; }
    }
}
