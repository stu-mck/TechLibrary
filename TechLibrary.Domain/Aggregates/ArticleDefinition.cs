using System;
using System.Collections.Generic;
using System.Linq;
using TechLibrary.Domain.DomainEvents;
using TechLibrary.Domain.Entitites;
using TechLibrary.Domain.Interfaces;
using TechLibrary.Domain.Values;



/// domain operations
/// - add section (crud? ordering ..)
/// - add content to section (crud ?)
/// - publish
///     - validate rules
///     - raise event 
///         - if success -> generate html
///         - if fail ->
///             raised intervention message
/// - set properties
///     - category
///     - name
///     - attributes


namespace TechLibrary.Domain.Aggregates
{
    public class ArticleDefinition : IEntity
    {
        private readonly List<IPublicationRule> _publicationRules = new List<IPublicationRule>();
        private readonly List<ArticleIndex> _indexes = new List<ArticleIndex>();
        private readonly List<Section> _sections = new List<Section>();

        public ArticleDefinition()
        {
            
        }

        public string Name { get; set; }

        public string Category { get; set; }

        public IDomainEvent AddSection(Section newSection)
        {
            if (!string.IsNullOrEmpty(newSection.Name))
            {
                if (_sections.Any(sect => sect.Order == newSection.Order))
                    ReorderSections(newSection);

                _sections.Add(newSection);
                return new SectionAddedEvent(newSection);
            }
            return new SectionAddFailedEvent(newSection);
        }

        private void ReorderSections(Section newSection)
        {
            _sections.Where(sect => sect.Order >= newSection.Order).ToList().ForEach(rs => rs.SetOrder(rs.Order + 1));
        }

        public IDomainEvent AddPublicationRule(IPublicationRule publicationRule)
        {
            _publicationRules.Add(publicationRule);

            var ruleResults = EvaluateRules();

            if (ruleResults.All(rr => rr.Success))
                return new PublicationRuleAddedEvent(this, publicationRule);
            return new PublicationRuleAddedEvent(this, publicationRule, ruleResults);
        }

        public List<Section> GetSections()
        {
            return _sections;
        }

        public IDomainEvent AddIndex(ArticleIndex index)
        {
            _indexes.Add(index);
            return new IndexAddedEvent(index);
        }

        public List<RuleEvaluationResult> EvaluateRules()
        {
            var results = new List<RuleEvaluationResult>();

            _publicationRules.ForEach(rule => results.Add(new RuleEvaluationResult(this)));

            return results;
        }

        public IDomainEvent Publish()
        {
            var ruleResults = EvaluateRules();

            if (ruleResults.Any() && ruleResults.All(rr => rr.Success))
            {
                Published = true;
                PublishDate = DateTime.Now;
                PublishedVersion = PublishedVersion++;
                return new PublishSuccessEvent(this);
            }
            return new PublishFailEvent(this, ruleResults);
        }


        public Guid EntityId { get; set; }

        public List<ArticleIndex> GetIndexes() {
            return _indexes;
        } 

        public bool Published { get; private set; }
        public DateTime PublishDate { get; private set; }
        public int PublishedVersion { get; private set; }
    }
}
