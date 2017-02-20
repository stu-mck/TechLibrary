using System;


namespace TechLibrary.Domain.Entitites
{
    public class Series 
    {
        public Series()
        {
            ID = Guid.NewGuid();
        }

        public Guid ID { get; private set; }
        public string Name { get; set; }
        public int YearFrom { get; set; }
        public int YearTo { get; set; }
        public ModelFamily ModelFamily { get; set; }
    }
}
