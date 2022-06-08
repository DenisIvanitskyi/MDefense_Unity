using System;

namespace Assets.Models
{
    public class GameModel : Model
    {
        public GameModel() : base(Guid.NewGuid())
        {

        }

        public string Name { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
