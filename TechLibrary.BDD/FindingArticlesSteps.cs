using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TechLibrary.Controllers;
using TechLibrary.Domain.Aggregates;
using TechLibrary.Domain.Entities;
using TechLibrary.Domain.Repositories;
using TechLibrary.Domain.Values;
using TechTalk.SpecFlow;

namespace TechLibrary.BDD
{
    [Binding]
    public class FindingArticlesSteps
    {
        private ArticleDefinition _articleDefinition;
        private IEnumerable<ArticleDefinition> _searchResults;
        private ArticleIndex _manufacturerIndex;
        private ArticleIndex _modelIndex;
        private static ArticleController _articleController;

        [BeforeTestRun]
        public static void SetUp()
        {
            _articleController = new ArticleController(new GenericRepository<ContentElement>(), new GenericRepository<ArticleDefinition>());
        }

        [Given(@"I have created an ArticleDefinition with an index for a Manufacturer")]
        public void GivenIHaveCreatedAnArticleDefinitionWithAnIndexForAManufacturer()
        {
            _articleDefinition = _articleController.SaveArticle(new ArticleDefinition());


            _manufacturerIndex = new ArticleIndex(Guid.NewGuid(), IndexType.Manufacturer);
            _articleDefinition = _articleController.Index(_articleDefinition.EntityId, _manufacturerIndex);

          


        }
        
        [Given(@"I have added an ArticleIndex for XB")]
        public void GivenIHaveAddedAnArticleIndexForXB()
        {
            _modelIndex = new ArticleIndex(Guid.NewGuid(), IndexType.ModelFamily);
            _articleDefinition = _articleController.Index(_articleDefinition.EntityId, _modelIndex);
        }
        
       
        
        [When(@"I search by the (.*) indexes")]
        public void WhenISearchByTheIndexes(int p0)
        {
            _searchResults = _articleController.FindArticles(new List<Guid> { _manufacturerIndex.ReferenceId, _modelIndex.ReferenceId });
        }
        
        [Then(@"the ArticleDefinition should be retrieved")]
        public void ThenTheArticleDefinitoinShouldBeRetrieved()
        {
            Assert.IsNotNull(_searchResults);
            var searchResult = _searchResults.FirstOrDefault();

            Assert.IsNotNull(searchResult);
            Assert.IsNotNull(searchResult.Indexes.Any(idx => idx.ReferenceId == _manufacturerIndex.ReferenceId));
            Assert.IsNotNull(searchResult.Indexes.Any(idx => idx.ReferenceId == _modelIndex.ReferenceId));

        }
    }
}
