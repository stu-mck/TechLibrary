using System;

namespace TechLibrary.Domain.Aggregates
{
    public class ContentElement     {
        public ContentElement()
        {
            
        }


        public Guid EntityId { get; set; }
        
        
        public string Content { get; set; }

    }
}
