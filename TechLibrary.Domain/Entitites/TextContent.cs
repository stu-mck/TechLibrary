using System;


namespace TechLibrary.Domain.Entities
{
    public class TextContent 
    {
        public TextContent(Guid id)
        {
            ID = id;
        }

        public Guid ID { get; set; }

    }
}
