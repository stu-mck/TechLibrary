using System;
using TechLibrary.Domain.Interfaces;

namespace TechLibrary.Domain.PublicationRules
{
    public class ArticleSectionCountRule : PublicationRuleBase, IPublicationRule
    {
        private int _sectionCount;
        public ArticleSectionCountRule(int sectionCount, string name):base(name)
        {
            _sectionCount = sectionCount;
        }


        

        public bool EvaluateRule(IEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
