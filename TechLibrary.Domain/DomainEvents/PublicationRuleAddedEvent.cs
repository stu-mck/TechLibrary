using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLibrary.Domain.Aggregates;
using TechLibrary.Domain.Entitites;
using TechLibrary.Domain.Interfaces;
using TechLibrary.Domain.Values;

namespace TechLibrary.Domain.DomainEvents
{
    public class PublicationRuleAddedEvent : IDomainEvent
    {
        private ArticleDefinition articleDefinition;
        private IPublicationRule publicationRule;
        private List<RuleEvaluationResult> _ruleResults;

        public PublicationRuleAddedEvent(ArticleDefinition articleDefinition, IPublicationRule publicationRule)
        {
            this.articleDefinition = articleDefinition;
            this.publicationRule = publicationRule;
        }

        public PublicationRuleAddedEvent(ArticleDefinition articleDefinition, IPublicationRule publicationRule, List<RuleEvaluationResult> ruleResults) : this(articleDefinition, publicationRule)
        {
            _ruleResults = ruleResults;
        }

        public List<RuleEvaluationResult> EvaluationResults
        {
            get
            {
                return _ruleResults;
            }
        }
    }
}
