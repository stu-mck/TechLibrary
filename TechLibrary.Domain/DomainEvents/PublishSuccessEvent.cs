using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLibrary.Domain.Aggregates;

namespace TechLibrary.Domain.DomainEvents
{
    public class PublishSuccessEvent : IDomainEvent
    {
        public PublishSuccessEvent(ArticleDefinition articleDefinition)
        {

        }
    }
}
