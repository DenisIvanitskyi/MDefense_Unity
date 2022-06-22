using UnityEngine;

namespace Assets.Game.Block
{
    public class GameUnit : ScriptableObject
    {
        [SerializeField]
        private Sprite _sprite;

        public Sprite Sprite => _sprite;
    }
}
