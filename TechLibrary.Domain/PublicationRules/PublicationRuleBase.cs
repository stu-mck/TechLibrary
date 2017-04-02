using System;
using TechLibrary.Domain.Interfaces;

namespace TechLibrary.Domain.PublicationRules
{
    public abstract class PublicationRuleBase 
    {
        protected string _name;
        protected PublicationRuleBase(string name)
        {
            _name = name;
        }



        public string RuleName
        {
            get
            {
                return _name;
            }
        }

    }
}
