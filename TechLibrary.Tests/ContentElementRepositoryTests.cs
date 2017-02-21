using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechLibrary.Domain.Repositories;
using TechLibrary.Domain.Aggregates;

namespace TechLibrary.Tests
{
    [TestClass]
    public class ContentElementRepositoryTests
    {
        private readonly string _content = "some content";
        [TestMethod]
        public void SaveContentElementReturnsPersistedObject()
        {
            var contentElement = new ContentElement();

            var sut = new ContentElementRepository();

            var result = sut.Save(contentElement);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SaveContentElementAddsEntityId()
        {
            var contentElement = new ContentElement();

            var sut = new ContentElementRepository();

            var result = sut.Save(contentElement);

            Assert.AreNotEqual(Guid.Empty, result.EntityId);
        }

        [TestMethod]
        public void SavedContentElementCanBeRetrievedFromRepository()
        {
            var contentElement = new ContentElement()
            {
                Content = _content
            };

            var sut = new ContentElementRepository();

            var saveResult = sut.Save(contentElement);

            var retrievedObject = sut.Load(saveResult.EntityId);

            Assert.IsNotNull(retrievedObject);
            Assert.AreEqual(saveResult.EntityId, retrievedObject.EntityId);
        }
    }
}
