using System;


namespace TechLibrary.Domain.Entitites
{
    public class Transmission 
    {
        public Transmission()
        {
            ID = Guid.NewGuid();
        }

        public Guid ID { get; private set; }
        
    }
}
