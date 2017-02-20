using System;
using System.Collections.Generic;
using System.Linq;
using TechLibrary.Domain.Values;
using TechLibrary.Interfaces;

namespace TechLibrary.Domain.Aggregates
{
    public class ArticleDefinition : IEntity
    {
        public ArticleDefinition(Guid id)
        {
            ID = id;
        }

        public List<ContentIndex> Indexes { get;  }

        public Guid ID { get;  }

        public List<Section>  Sections { get; } = new List<Section>();


        //attribute should be section or pointer to section?
        public void AddIndex(string sectionName, ContentIndex contentIndex)
        {
            var section = Sections.First(sec => sec.Name.Equals(sectionName, StringComparison.CurrentCultureIgnoreCase));

            section.Indexes.Add(contentIndex);

        }

        public IEnumerable<ContentIndex> GetArticleIndexes()
        {
            return Sections.SelectMany(sec => sec.Indexes);
        }

        public void AddSection(string name, int order)
        {
            var section   = new Section(name, order);
            Sections.Add(section);
        }


    }
}
