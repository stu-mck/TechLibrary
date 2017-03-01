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

            ad.AddIndex(index);

            var result = ad.Indexes.First(ir => ir.ReferenceId == indexRef);

            Assert.AreEqual<ArticleIndex>(index, result);
            
        }
    }
}
