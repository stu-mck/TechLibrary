using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TechLibrary.Controllers;
using TechLibrary.Domain.Aggregates;
using TechLibrary.Domain.Entities;
using TechLibrary.Domain.Repositories;
using TechLibrary.Domain.Values;
using TechLibrary.Models.Creators;
using TechTalk.SpecFlow;

namespace TechLibrary.BDD
{
    [Binding]
    public class ArticleIndexingSteps
    {
        private static ArticleDefinition _articleDefinition;
        private static ArticleController _articleController;
        private static Guid _indexReference = Guid.NewGuid();

        [BeforeTestRun]
        public static void SetUp()
        {
            _articleController = new ArticleController(new GenericRepository<ContentElement>(), new GenericRepository<ArticleDefinition>());
        }

        [Given(@"I have created an Article Definition")]
        public void GivenIHaveCreatedAnArticleDefinition()
        {
            var articleDefinition = new ArticleDefinitionCreationRequest();
            var result = _articleController.Post(articleDefinition);

        }
        
        [Given(@"I have added an Index to the Article Definition")]
        public void GivenIHaveAddedAnIndexToTheArticleDefinition()
        {
            _articleController.Index(_articleDefinition.EntityId, new ArticleIndex(_indexReference, IndexType.Manufacturer));
           
        }
        
       
        
        [Then(@"the Article Definition should have the Index")]
        public void ThenTheArticleDefinitionShouldHaveTheIndex()
        {
            Assert.AreEqual(_indexReference, _articleDefinition.Indexes.FirstOrDefault().ReferenceId);
        }
    }
}
