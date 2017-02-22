﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TechLibrary.Domain.Aggregates;
using TechLibrary.Domain.Entities;
using TechLibrary.Domain.Interfaces;

namespace TechLibrary.Controllers
{
    public class ArticleController : ApiController
    {
        private readonly IRepository<ContentElement> _contentRepository;
        private Domain.Repositories.GenericRepository<ContentElement> genericRepository;

        public ArticleController(IRepository<ContentElement> contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public ArticleController(Domain.Repositories.GenericRepository<ContentElement> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public IEnumerable<ArticleDefinition> FindArticles(Guid manufacturerId, Guid modelFamilyId, Guid series)
        {
            return new List<ArticleDefinition>();
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

        public ArticleDefinition SaveArticle(ArticleDefinition articleDefinition)
        {
            return articleDefinition;
        }
    }
}
