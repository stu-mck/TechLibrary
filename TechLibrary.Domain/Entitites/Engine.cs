using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLibrary.Domain.Aggregagtes;
using TechLibrary.Domain.Values;


namespace TechLibrary.Domain.Entitites
{
    public class Engine     {
        public Engine()
        {
            ID = Guid.NewGuid();
        }
        public Guid ID { get; private set; }

        public Manufacturer Manufacturer { get; set; }

        public int Capacity { get; set; }

        public FuelType FuelType { get; set; }
    }
}
