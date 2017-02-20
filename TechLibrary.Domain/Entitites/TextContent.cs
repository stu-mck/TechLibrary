using System;
using TechLibrary.Interfaces;

namespace TechLibrary.Domain.Entities
{
    public class TextContent : IContentElement, IEntity, IIndexable
    {
        public TextContent(Guid id)
        {
            ID = id;
        }

        public Guid ID { get; set; }

    }
}
