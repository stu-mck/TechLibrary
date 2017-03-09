using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TechLibrary.Domain.Aggregates;
using TechLibrary.Domain.Entities;
using TechLibrary.Domain.Interfaces;
using TechLibrary.Domain.Values;
using TechLibrary.Models.Creators;
using TechLibrary.Models.Response;

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

        [HttpGet]
        public IHttpActionResult Get(Guid id)
        {
            var article = _articleDefinitionRepository.Load(id);
            if (article == null)
                return NotFound();
            return Ok(new Models.Views.ArticleDefinition()
            {
                Name = article.Name,
                Category = article.Category
            });
        }

        [HttpPost]
        public IHttpActionResult Post(ArticleDefinitionCreationRequest articleDefinitionRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var articleDefinition = new ArticleDefinition()
                    {
                        Name = articleDefinitionRequest.Name,
                        Category = articleDefinitionRequest.Category
                    };
                    var savedEntity = _articleDefinitionRepository.Save(articleDefinition);
                    return Ok<OkResponse>(new OkResponse() { ResourceLocation = $"{BuildDomain()}/Article/{savedEntity.EntityId}" });
                }
                catch (Exception ex)
                {
                    return InternalServerError();
                }
            }
            return BadRequest();
        }

        private string BuildDomain()
        {
            var port = Request.RequestUri.Port == 80 ? "" : $":{Request.RequestUri.Port}";

            return $"{Request.RequestUri.Scheme}//{Request.RequestUri.DnsSafeHost}{port}";

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
