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

        public Guid EntityId { get; set; }
        
    }
}
