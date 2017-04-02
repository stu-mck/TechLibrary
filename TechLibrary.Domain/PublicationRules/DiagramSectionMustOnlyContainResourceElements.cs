using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLibrary.Domain.Aggregates;
using TechLibrary.Domain.Entities;
using TechLibrary.Domain.Interfaces;
using TechLibrary.Domain.Values;

namespace TechLibrary.Domain.PublicationRules
{
    public class DiagramSectionMustOnlyContainResourceElements : PublicationRuleBase, IPublicationRule
    {
        public DiagramSectionMustOnlyContainResourceElements(string name) : base(name)
        {

        }

        public RuleEvaluationResult EvaluateRule(ArticleDefinition articleDefinition)
        {

            var diagramSection = articleDefinition.GetSections().FirstOrDefault(sect => sect.Name == "Diagrams");

            if (diagramSection == null)
            {
                return new RuleEvaluationResult()
                {
                    FailureMessage = "Diagram Section Not Found",
                    Success = false,
                    RuleName = _name
                };
            }

            if (diagramSection.ContentElements.All(ce => ce.ContentType == ContentType.Resource))
                return new RuleEvaluationResult()
                {
                    Success = true,
                    RuleName = _name
                };

            return new RuleEvaluationResult()
            {
                FailureMessage = "Diagram Section may only contain Resource Elements",
                Success = false
            };
            
        }

    }
}
