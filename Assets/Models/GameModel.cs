using System;
using System.Collections.Generic;

namespace Assets.Models
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
