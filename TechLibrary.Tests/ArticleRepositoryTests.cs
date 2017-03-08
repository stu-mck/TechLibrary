using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLibrary.Domain.Aggregates;
using TechLibrary.Domain.Interfaces;
using TechLibrary.Domain.Repositories;
using TechLibrary.Domain.Values;

namespace TechLibrary.Tests
{
    [TestClass]
    public class ArticleRepositoryTests
    {
        [TestMethod]
        public void ArticleWithIndexesIsReturnedWhenIndexInQuery()
        {
            var rep = new GenericRepository<ArticleDefinition>();
            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid();
            SetUp(new List<Guid> { guid1, guid2 }, rep);
            var query = new List<Guid>()
            {
                guid1
            };

            var result = rep.AsQueryable().Where(art => art.Indexes.Select(idx => idx.ReferenceId).Any(id => query.Contains(id))).ToList();

            Assert.AreEqual(1, result.Count);

        }

        [TestMethod]
        public void ArticleWithIndexesIsNotReturnedWhenIndexIsNotInQuery()
        {
            var rep = new GenericRepository<ArticleDefinition>();
            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid();
            SetUp(new List<Guid> { guid1, guid2 }, rep);
            var query = new List<Guid>()
            {
                Guid.NewGuid()
            };

            var result = rep.AsQueryable().Where(art => art.Indexes.Select(idx => idx.ReferenceId).Any(id => query.Contains(id))).ToList();

            Assert.AreEqual(0, result.Count);

        }


        private void SetUp(List<Guid> testIndexes, IRepository<ArticleDefinition> repository)
        {
            var articleDefn = new ArticleDefinition();

            testIndexes.ForEach(idx => articleDefn.Indexes.Add(new ArticleIndex(idx, It.IsAny<IndexType>())));

            repository.Save(articleDefn);
        }
        
    }
}
