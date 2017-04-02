using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TechLibrary.Domain.Aggregates;
using TechLibrary.Domain.DomainEvents;
using TechLibrary.Domain.Entitites;
using TechLibrary.Domain.Values;

namespace TechLibrary.Tests
{
    [TestClass]
    public class ArticleDefinitonTests
    {
        [TestMethod]
        public void AddedIndexRaisesNewIndexEvent()
        {
            //setup
            var ad = new ArticleDefinition();
            var indexRef = Guid.NewGuid();
            var index = new ArticleIndex(indexRef, IndexType.Manufacturer);

            var indexAddedEvent = ad.AddIndex(index);

            Assert.IsInstanceOfType(indexAddedEvent, typeof(IndexAddedEvent));
            
        }

        [TestMethod]
        public void ValidSectionAddedToArticleRaisesSectionAddedEvent()
        {
            var ad = new ArticleDefinition();
            var newSection = new Section("A Section Name", 1);

            var sectionAddedResult = ad.AddSection(newSection);

            Assert.IsInstanceOfType(sectionAddedResult, typeof(SectionAddedEvent));
        }

        [TestMethod]
        public void InvalidSectionAddedToArticleRaisesSectionAddedEvent()
        {
            var ad = new ArticleDefinition();
            var newSection = new Section();

            var sectionAddedResult = ad.AddSection(newSection);

            Assert.IsInstanceOfType(sectionAddedResult, typeof(SectionAddFailedEvent));
        }

        [TestMethod]
        public void ValidSectionWithExistingOrderCorrectlyReordersSections()
        {
            var ad = new ArticleDefinition();
            ad.AddSection(new Section("section 1", 1));
            ad.AddSection(new Section("section 2", 2));
            ad.AddSection(new Section("section 3", 3));

            var testSection = new Section("section 4", 2);

            var sectionAddedResult = ad.AddSection(testSection);

            Assert.IsInstanceOfType(sectionAddedResult, typeof(SectionAddedEvent));
            Assert.AreEqual(1, ad.GetSections().Where(sect => sect.Order == 2).Count());
            Assert.AreEqual("section 4", ad.GetSections().First(sect => sect.Order == 2).Name);
            Assert.AreEqual("section 2", ad.GetSections().First(sect => sect.Order == 3).Name);
        }

        [TestMethod]
        public void AddedValidPublicationRuleWithNoFailuresReturnsPublicationAddedEvent()
        {
            var ad = new ArticleDefinition();

            var publicationAddedResult = ad.AddPublicationRule(new PublicationRule());

            Assert.IsInstanceOfType(publicationAddedResult, typeof(PublicationRuleAddedEvent));
        }

        [TestMethod]
        public void AddedValidPublicationRuleWithThatRaisesPublicationErrorsReturnsPublicationWithFailuresEvent()
        {
            var ad = new ArticleDefinition();

            var publicationAddedResult = ad.AddPublicationRule(new PublicationRule());

            Assert.IsInstanceOfType(publicationAddedResult, typeof(PublicationRuleAddedEvent));
            Assert.IsNotNull(((PublicationRuleAddedEvent)publicationAddedResult).EvaluationResults);
        }
    }
}
