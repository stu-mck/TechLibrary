using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechLibrary.Domain.Aggregates;
using TechTalk.SpecFlow;

namespace TechLibrary.BDD
{
    [Binding]
    public class ArticleRetrievingSteps : ArticleAuthoringBase
    {
        [Given(@"I have created a new Article")]
        public void GivenIHaveCreatedANewArticle()
        {
            ScenarioContext.Current.Add(_articleToSave, new ArticleDefinition());
        }

       

        [When(@"I enter the entityId of the saved ArticleDefinition")]
        public void WhenIEnterTheEntityIdOfTheSavedArticleDefinition()
        {
            ScenarioContext.Current.Add(_retrievedArticle, GetController().ArticleDefinition(((ArticleDefinition)ScenarioContext.Current[_savedArticle]).EntityId));

        }
        
        [Then(@"the ArticleDefinition should be returned")]
        public void ThenTheArticleDefinitionShouldBeReturned()
        {
            var sut = (ArticleDefinition)ScenarioContext.Current[_retrievedArticle];

            Assert.IsNotNull(sut);
            Assert.AreNotEqual(Guid.Empty, sut.EntityId);
        }
    }
}
