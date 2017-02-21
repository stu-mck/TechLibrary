using System;
using TechLibrary.Domain.Interfaces;

namespace TechLibrary.Domain.Entities
{
    public class ContentElement : IEntity
    {
        public ContentElement()
        {
            
        }


        public Guid EntityId { get; set; }
        
        
        public string Content { get; set; }

    }
}
