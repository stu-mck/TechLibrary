using Moq;
using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;
using System.Web.Http.Results;
using TechLibrary.Controllers;
using TechLibrary.Domain.Aggregates;
using TechLibrary.Domain.Entities;
using TechLibrary.Domain.Repositories;
using TechLibrary.Models.Creators;
using TechLibrary.Models.Response;
using TechTalk.SpecFlow;


namespace TechLibrary.BDD
{
    public abstract class ArticleAuthoringBase
    {
        protected const string _articleToSave = "articleToSave";
        protected const string _savedArticle = "savedArticle";
        protected const string _retrievedArticle = "retrievedArticle";
        protected const string _savedArticleId = "savedArticleId";
        

        protected string SaveArticleDefinition(ArticleDefinitionCreationRequest articleDefinition)
        {
            var result = (OkNegotiatedContentResult<OkResponse>)GetController().Post(articleDefinition);
            return result.Content.ResourceLocation;

        }

        protected ArticleDefinition GetArticleDefinition(string resourceLocation)
        {
            return null;
        }

        protected ArticleController GetController()
        {
            if (!ScenarioContext.Current.ContainsKey("controller"))
            {
                var controller = new ArticleController(new GenericRepository<ContentElement>(), new GenericRepository<ArticleDefinition>());
                controller.Request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("http://test.com"),
                };
                controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

                ScenarioContext.Current.Add("controller", controller);
            }
            return (ArticleController)ScenarioContext.Current["controller"];
        }
    }
}
