using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechLibrary.Domain.Aggregates;
using TechTalk.SpecFlow;

namespace TechLibrary.BDD
{
    [Binding]
    public class ArticleAuthoringSteps : ArticleAuthoringBase
    {
        

        [Given(@"I have created a new ArticleDefinition")]
        public void GivenIHaveCreatedANewArticle()
        {
            ScenarioContext.Current.Add(_articleToSave, new ArticleDefinition());
        }

        [When(@"I press the save article button")]
        public void WhenIPressTheSaveArticleButton()
        {
            var result = SaveArticleDefinition(new Models.Creators.ArticleDefinitionCreationRequest());
            var savedArticle = GetArticleDefinition(result);
            ScenarioContext.Current.Add(_savedArticle, result);
        }


        [Then(@"the Article should be saved")]
        public void ThenTheArticleShouldBeSaved()
        {
            var originalItem = (ArticleDefinition)ScenarioContext.Current[_articleToSave];
            var savedItem = (ArticleDefinition)ScenarioContext.Current[_savedArticle];

            Assert.IsNotNull(savedItem);
        }

    }
}
