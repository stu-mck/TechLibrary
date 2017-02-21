using System;
using System.Collections.Generic;
using System.Linq;
using TechLibrary.Domain.Aggregates;

namespace TechLibrary.Domain.Repositories
{
    public class ContentElementRepository
    {
        private List<ContentElement> _contentElements = new List<ContentElement>();
        public ContentElement Save(ContentElement contentElement)
        {
            contentElement.EntityId = Guid.NewGuid();
            _contentElements.Add(contentElement);
            return contentElement;
        }

        public ContentElement Load(Guid entityId)
        {
            return _contentElements.FirstOrDefault(ce => ce.EntityId.Equals(entityId));
        }
    }
}
