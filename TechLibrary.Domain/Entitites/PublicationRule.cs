using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLibrary.Domain.Aggregates;
using TechLibrary.Domain.Interfaces;
using TechLibrary.Domain.Values;

namespace TechLibrary.Domain.Entitites
{
    public class PublicationRule : IPublicationRule
    {
        public Guid RuleId { get; set; }

        public string   RuleName { get; set; }

        public RuleEvaluationResult EvaluateRule(ArticleDefinition entity)
        {
            return null;
        }

        public string RuleFailureMessage { get; }
    }
}
