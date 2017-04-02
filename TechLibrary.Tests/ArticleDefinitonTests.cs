using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLibrary.Domain.Aggregates;
using TechLibrary.Domain.Values;

namespace TechLibrary.Tests
{
    [TestClass]
    public class ArticleDefinitonTests
    {
        [TestMethod]
        public void AddedIndexIsPartOfArticleDefiniton()
        {
            //setup
            var ad = new ArticleDefinition();
            var indexRef = Guid.NewGuid();
            var index = new ArticleIndex(indexRef, IndexType.Manufacturer);

            var indexAddedEvent = ad.AddIndex(index);

            Assert.AreEqual(indexRef, indexAddedEvent.ArticleIndex.Index);
            
        }

        public void SectionAddedToArticleRaisesSectionAddedEvent()
        {
            var ad = new ArticleDefinition();
            var newSection 
        }
    }
}
