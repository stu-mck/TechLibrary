using System;
using TechLibrary.Interfaces;

namespace TechLibrary.Domain.Entitites
{
    public class Transmission : IEntity, IIndexable
    {
        public Transmission()
        {
            ID = Guid.NewGuid();
        }

        public Guid ID { get; private set; }
        
    }
}
