using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLibrary.Domain.Aggregagtes;
using TechLibrary.Interfaces;

namespace TechLibrary.Domain.Entitites
{
    public class ModelFamily : IEntity, IIndexable
    {
        public ModelFamily()
        {
            ID = Guid.NewGuid();
            Series = new List<Entitites.Series>();
        }

        public string Name { get; set; }

        public Guid ID { get; private set; }

        public List<Series> Series { get; set; }

        public Manufacturer Manufacturer { get; set; }

        public Series AddSeries(string name, int yearFrom, int yearTo)
        {
            var series = new Series()
            {
                Name = name,
                YearFrom = yearFrom,
                YearTo = yearTo
            };
            Series.Add(series);
            return series;
        }
    }
}
