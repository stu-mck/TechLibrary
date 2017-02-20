using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TechLibrary.Domain.Aggregates;

namespace TechLibrary.Controllers
{
    public class ArticleController : ApiController
    {
        public IEnumerable<ArticleDefinition> FindArticles(Guid manufacturerId, Guid modelFamilyId, Guid series)
        {
            return new List<ArticleDefinition>();
        }

        public ContentElement Save(ContentElement contentElement)
        {
            return contentElement;
        }
    }
}
