using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechLibrary.Controllers;
using TechLibrary.Domain.Entities;
using TechLibrary.Domain.Repositories;
using TechTalk.SpecFlow;

namespace TechLibrary.BDD
{
    [Binding]
    public class ContentAuthoringSteps : ArticleAuthoringBase
    {
        private readonly string _contentElement = "contentElement";
        private readonly string _savedElement = "savedElement";
        private readonly string _content = "some content";

        [Given(@"I have created a new ContentElement")]
        public void GivenIHaveCreatedANewContentElement()
        {
            ScenarioContext.Current.Add(_contentElement, new ContentElement());
        }
        
        [Given(@"I have entered content into the ContentElement")]
        public void GivenIHaveEnteredContentIntoTheContentElement()
        {
            var c = (ContentElement)ScenarioContext.Current[_contentElement];
            c.Content = _content;
        }
        
        [When(@"I press save")]
        public void WhenIPressSave()
        {
            var result = SaveContentElement((ContentElement)ScenarioContext.Current[_contentElement]);
            ScenarioContext.Current.Add("result", result);
        }
        
        [Then(@"the ContentElement should be saved")]
        public void ThenTheContentElementShouldBeSaved()
        {
            var result = (ContentElement)ScenarioContext.Current["result"];

            Assert.IsNotNull(result);
            Assert.AreEqual(_content, result.Content);
        }

        [Given(@"I press save")]
        public void GivenIPressSave()
        {
            var result = SaveContentElement((ContentElement)ScenarioContext.Current[_contentElement]);
            ScenarioContext.Current.Add("result", result);
        }


        [When(@"I enter the entityId of the saved ContentElement")]
        public void WhenIEnterTheEntityIdOfTheSavedContentElement()
        {
            var controller = GetController();
            var savedItem = (ContentElement)ScenarioContext.Current[_contentElement];
            ScenarioContext.Current.Add(_savedElement, controller.ContentElement(savedItem.EntityId));
        }

        [Then(@"the ContentElement should be returned")]
        public void ThenTheContentElementShouldBeReturned()
        {
            var originalItem = (ContentElement)ScenarioContext.Current[_contentElement];
            var savedItem = (ContentElement)ScenarioContext.Current[_savedElement];

            Assert.AreEqual(originalItem.Content, savedItem.Content);
        }

        private ContentElement SaveContentElement(ContentElement contentElement)
        {
            return GetController().Save(contentElement);
        }

    }
}
