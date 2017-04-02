using System;
using System.Collections.Generic;
using TechLibrary.Domain.Entities;

namespace TechLibrary.Domain.Values
{ 
    public class Section
    {

        public Section()
        {
            Settings = new List<Setting>();
        }

        public Section(string name, int order):this()
        {
            Name = name;
            Order = order;
        }


        public List<ContentElement> ContentElements { get; } = new List<ContentElement>();

  

        public List<Setting> Settings { get; set; }

        public string Name { get; }

        private int _order;
        

        public int Order
        {
            get
            {
                return _order;
            }
            private set
            {
                _order = value;
            }
        }


        internal void SetOrder(int order)
        {
            _order = order;
        }
    }
}
