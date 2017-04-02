using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLibrary.Domain.Aggregates;

namespace TechLibrary.Domain.Values
{
    public class RuleEvaluationResult
    {
        private ArticleDefinition articleDefinition;

        public RuleEvaluationResult(ArticleDefinition articleDefinition)
        {
            this.articleDefinition = articleDefinition;
        }

        public bool Success { get; set; }

        public string RuleName { get; set; }

        public string RuleDetails { get; set; }

        public string FailureMessage { get; set; }

    }
}
