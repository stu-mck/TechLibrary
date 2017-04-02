using System;
using TechLibrary.Domain.Interfaces;

namespace TechLibrary.Domain.Entities
{
    public class ContentElement : IEntity
    {
        public ContentElement()
        {
            
        }

        public ContentType ContentType { get; set; }

        public Guid EntityId { get; set; }
        
        
        public string Content { get; set; }

    }

    public enum ContentType
    {
        Text,
        Table,
        Resource,
        ExternalLink
    }
}
