using System;
using System.Collections.Generic;
using TechLibrary.Interfaces;

namespace TechLibrary.Domain.Aggregates
{
    public class ContentElement : IEntity
    {
        public ContentElement(string name)
        {
            Name = name;
            ID = Guid.NewGuid();
        }

        public Guid ID { get; }

        public string Name { get; }

        public int Version { get; set; }

        public List<Attribute> Attributes { get; set; }

        public IContentElement Content { get; set; }

    }
}
