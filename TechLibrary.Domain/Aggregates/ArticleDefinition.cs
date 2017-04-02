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
        private readonly List<PublicationRule> _publicationRules;
        public ArticleDefinition(List<PublicationRule> publicationRules)
        {
            _publicationRules = publicationRules;
        }

        public string Name { get; set; }

        public string Category { get; set; }

        public IDomainEvent AddIndex(ArticleIndex index)
        {
            Indexes.Add(index);
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

            if (ruleResults.All(rr => rr.Success))
            {
                Published = true;
                PublishDate = DateTime.Now;
                PublishedVersion = PublishedVersion++;
                return new PublishSuccessEvent(this);
            }
            return new PublishFailEvent(this, ruleResults);
        }


        public Guid EntityId { get; set; }

        private readonly List<ArticleIndex> _indexes = new List<ArticleIndex>();

        public List<ArticleIndex> Indexes => _indexes;

        public bool Published { get; private set; }
        public DateTime PublishDate { get; private set; }
        public int PublishedVersion { get; private set; }
    }
}
