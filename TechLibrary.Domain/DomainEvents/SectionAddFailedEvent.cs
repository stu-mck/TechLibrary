using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLibrary.Domain.Values;

namespace TechLibrary.Domain.DomainEvents
{
    public class SectionAddFailedEvent : IDomainEvent
    {
        private Section newSection;

        public SectionAddFailedEvent(Section newSection)
        {
            this.newSection = newSection;
        }
    }
}
