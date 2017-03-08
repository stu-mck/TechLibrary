using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Http;
using TechLibrary.Domain.Aggregates;
using TechLibrary.Domain.Entities;
using TechLibrary.Domain.Interfaces;
using TechLibrary.Domain.Values;

namespace TechLibrary.Controllers
{
    public class ArticleController : ApiController
    {
        private readonly IRepository<ContentElement> _contentRepository;
        private readonly IRepository<ArticleDefinition> _articleDefinitionRepository;

        public ArticleController(IRepository<ContentElement> contentRepository, IRepository<ArticleDefinition> articleDefinitionRepository)
        {
            _contentRepository = contentRepository;
            _articleDefinitionRepository = articleDefinitionRepository;
        }

        [HttpGet]
        public ArticleDefinition ArticleDefinition(Guid entityId)
        {
            return _articleDefinitionRepository.Load(entityId);
        }

        public IEnumerable<ArticleDefinition> FindArticles(List<Guid> indexes)
        {
            return _articleDefinitionRepository.AsQueryable().Where(art => art.Indexes.Select(idx => idx.ReferenceId).Any(id => indexes.Contains(id))).ToList();
        }

        public ContentElement Save(ContentElement contentElement)
        {
            return _contentRepository.Save(contentElement);
        }

        [HttpGet]
        public ContentElement ContentElement(Guid entityId)
        {
            return _contentRepository.Load(entityId);
        }

        [HttpPost]
        public ArticleDefinition SaveArticle(ArticleDefinition articleDefinition)
        {
            return _articleDefinitionRepository.Save(articleDefinition);
        }

        /// <summary>
        /// How should the index be added, by an object or by attributers
        /// </summary>
        /// <param name="articleDefinitionId"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        [HttpPost]
        public ArticleDefinition Index(Guid articleDefinitionId, ArticleIndex index)
        {
            var article =_articleDefinitionRepository.Load(articleDefinitionId);
            article.AddIndex(index);

            _articleDefinitionRepository.Save(article);
            //where should the repository save go?
            return article;
        }
    }
}
