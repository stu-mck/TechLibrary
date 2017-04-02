using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLibrary.Domain.Values;

namespace TechLibrary.Domain.DomainEvents
{
    public class IndexAddedEvent : IDomainEvent
    {
        public IndexAddedEvent(ArticleIndex index)
        {
            ArticleIndex = index;
        }

        public ArticleIndex ArticleIndex { get; private set; }
    }
}
