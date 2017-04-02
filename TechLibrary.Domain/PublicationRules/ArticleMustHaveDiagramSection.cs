using System.Linq;
using TechLibrary.Domain.Aggregates;
using TechLibrary.Domain.Interfaces;
using TechLibrary.Domain.Values;

namespace TechLibrary.Domain.PublicationRules
{
    public class ArticleMustHaveDiagramSection : PublicationRuleBase, IPublicationRule
    {
        public ArticleMustHaveDiagramSection(string name) : base(name)
        {
            
        }

        public RuleEvaluationResult EvaluateRule(ArticleDefinition articleDefinition)
        {

            var diagramSection = articleDefinition.GetSections().FirstOrDefault(sect => sect.Name == "Diagrams");

            if (diagramSection != null) return new RuleEvaluationResult()
            {
                Success = true
            };

            return new RuleEvaluationResult()
            {
                FailureMessage = "Article does not contain a Diagram section",
                Success = false,
                RuleName = _name
            };

        }

    }
}
