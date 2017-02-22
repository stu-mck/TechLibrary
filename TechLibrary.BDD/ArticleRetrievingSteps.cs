using System;
using TechTalk.SpecFlow;

namespace TechLibrary.BDD
{
    [Binding]
    public class ArticleRetrievingSteps : ArticleAuthoringBase
    {
        [Given(@"I have created a new Article")]
        public void GivenIHaveCreatedANewArticle()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I enter the entityId of the saved ArticleDefinition")]
        public void WhenIEnterTheEntityIdOfTheSavedArticleDefinition()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the ArticleDefinition should be returned")]
        public void ThenTheArticleDefinitionShouldBeReturned()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
