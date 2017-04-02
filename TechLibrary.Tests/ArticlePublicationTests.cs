using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechLibrary.Domain.Aggregates;
using TechLibrary.Domain.DomainEvents;
using TechLibrary.Domain.Entities;
using TechLibrary.Domain.PublicationRules;
using TechLibrary.Domain.Values;

namespace TechLibrary.Tests
{
    [TestClass]
    public class ArticlePublicationTests
    {
        [TestMethod]
        public void ArticleWithValidStructureReturnsPublishSuccessEvent()
        {
            var ad = BuildArticleDefinitionWithRules();
            ad.AddSection(new Section("Info", 1));
            ad.AddSection(BuildDiagramSection(2));

            var publishResult = ad.Publish();

            Assert.IsInstanceOfType(publishResult, typeof(PublishSuccessEvent));

        }

        [TestMethod]
        public void ArticleWithoutDiagramSectionReturnsPublishFailureEvent()
        {
            var ad = BuildArticleDefinitionWithRules();
            ad.AddSection(new Section("Info", 1));
            ad.AddSection(new Section("Info2", 2));

            var publishResult = ad.Publish();

            Assert.IsInstanceOfType(publishResult, typeof(PublishFailEvent));

        }


        [TestMethod]
        public void ArticleWithoutCOrrectSectionCountReturnsPublishFailureEven()
        {
            var ad = BuildArticleDefinitionWithRules();
            ad.AddSection(new Section("Info", 1));

            var publishResult = ad.Publish();

            Assert.IsInstanceOfType(publishResult, typeof(PublishFailEvent));

        }
        private Section BuildDiagramSection(int order)
        {
            var section = new Section("Diagrams", order);
            section.ContentElements.Add(new ContentElement()
            {
                Content = "Image ref",
                ContentType = ContentType.Resource,
                EntityId = Guid.NewGuid()
            });

            return section;
            
        }

        private ArticleDefinition BuildArticleDefinitionWithRules()
        {
            var ad = new ArticleDefinition();
            ad.AddPublicationRule(new ArticleMustHaveDiagramSection("Article must have a diagram section"));
            ad.AddPublicationRule(new ArticleSectionCountRule(2, "Article must have 6 sections"));
            ad.AddPublicationRule(new DiagramSectionMustOnlyContainResourceElements("Diagram must only have resource elements"));


            return ad;
        }


    }
}
