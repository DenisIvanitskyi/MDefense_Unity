using System;

namespace Assets.Common.Models
{
    [Serializable]
    public class Model
    {
        public Model()
        {

        }

        public Model(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
