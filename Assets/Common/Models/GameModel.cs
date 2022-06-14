using System;

namespace Assets.Common.Models
{
    [Serializable]
    public class GameModel : Model
    {
        public GameModel()
        {

        }

        public string Name { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
