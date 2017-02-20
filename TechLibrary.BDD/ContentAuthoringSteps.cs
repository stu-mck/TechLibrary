using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechLibrary.Controllers;
using TechLibrary.Domain.Aggregates;
using TechTalk.SpecFlow;

namespace TechLibrary.BDD
{
    [Binding]
    public class ContentAuthoringSteps
    {
        private string _contentElement = "contentElement";

        [Given(@"I have created a new ContentElement")]
        public void GivenIHaveCreatedANewContentElement()
        {
            ScenarioContext.Current.Add(_contentElement, new ContentElement());
        }
        
        [Given(@"I have entered content into the ContentElement")]
        public void GivenIHaveEnteredContentIntoTheContentElement()
        {
            var c = (ContentElement)ScenarioContext.Current[_contentElement];
            c.Content = "some content";
        }
        
        [When(@"I press save")]
        public void WhenIPressSave()
        {
            var controller = new ArticleController();
            var result = controller.Save((ContentElement)ScenarioContext.Current[_contentElement]);
            ScenarioContext.Current.Add("result", result);


        }
        
        [Then(@"the ContentElement should be saved")]
        public void ThenTheContentElementShouldBeSaved()
        {
            var result = (ContentElement)ScenarioContext.Current["result"];

            Assert.IsNotNull(result);
            Assert.AreEqual("some content", result.Content);
        }
    }
}
