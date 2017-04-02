using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLibrary.Domain.Aggregates;
using TechLibrary.Domain.Values;

namespace TechLibrary.Domain.DomainEvents
{
    public class PublishFailEvent : IDomainEvent
    {
        private ArticleDefinition articleDefinition;
        private List<RuleEvaluationResult> ruleResults;

        public PublishFailEvent(ArticleDefinition articleDefinition, List<RuleEvaluationResult> ruleResults)
        {
            this.articleDefinition = articleDefinition;
            this.ruleResults = ruleResults;
        }
    }
}
