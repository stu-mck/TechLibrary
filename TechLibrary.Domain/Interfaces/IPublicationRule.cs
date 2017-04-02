using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLibrary.Domain.Aggregates;
using TechLibrary.Domain.Values;

namespace TechLibrary.Domain.Interfaces
{
    public interface IPublicationRule
    { 
   
        string RuleName { get; }

        RuleEvaluationResult EvaluateRule(ArticleDefinition entity);

    }
}
