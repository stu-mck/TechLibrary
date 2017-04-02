using System;
using TechLibrary.Domain.Aggregates;
using TechLibrary.Domain.Interfaces;
using TechLibrary.Domain.Values;

namespace TechLibrary.Domain.PublicationRules
{
    public class ArticleSectionCountRule : PublicationRuleBase, IPublicationRule
    {
        private readonly int _sectionCount;

        public ArticleSectionCountRule(int sectionCount, string name):base(name)
        {
            _sectionCount = sectionCount;
        }

        private string _articleName;
        private int _articleCount;

        public RuleEvaluationResult EvaluateRule(ArticleDefinition articleDefinition)
        {
            _articleName = articleDefinition.Name;
            _articleCount = articleDefinition.GetSections().Count;
            return _articleCount == _sectionCount
                ? new RuleEvaluationResult()
                {
                    Success = true,
                    RuleName = _name
                }
                : new RuleEvaluationResult()
                {
                    FailureMessage =
                        $"Article {_articleName} must have {_sectionCount} sections - it only has {_articleCount}",
                    Success = false,
                    RuleName = _name

                };
        }

    }
}
