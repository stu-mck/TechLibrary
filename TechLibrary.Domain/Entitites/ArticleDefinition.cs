using System;
using System.Collections.Generic;
using System.Linq;
using TechLibrary.Domain.Interfaces;
using TechLibrary.Domain.Values;


namespace TechLibrary.Domain.Aggregates
{
    public class ArticleDefinition : IEntity
    {
        public ArticleDefinition()
        {
            
        }

        public void AddIndex(ArticleIndex index)
        {
            Indexes.Add(index);
        }



        public Guid EntityId { get; set; }

        private readonly List<ArticleIndex> _indexes = new List<ArticleIndex>();

        public List<ArticleIndex> Indexes => _indexes;
        
    }
}
