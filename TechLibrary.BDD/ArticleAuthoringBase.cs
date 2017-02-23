using System;
using TechLibrary.Controllers;
using TechLibrary.Domain.Aggregates;
using TechLibrary.Domain.Entities;
using TechLibrary.Domain.Repositories;
using TechTalk.SpecFlow;

namespace TechLibrary.BDD
{
    public abstract class ArticleAuthoringBase
    {
        protected const string _articleToSave = "articleToSave";
        protected const string _savedArticle = "savedArticle";
        protected const string _retrievedArticle = "retrievedArticle";
        protected const string _savedArticleId = "savedArticleId";
        

        protected ArticleDefinition SaveArticleDefinition(ArticleDefinition articleDefinition)
        {
            return GetController().SaveArticle(articleDefinition);

        }

        protected ArticleController GetController()
        {
            if (!ScenarioContext.Current.ContainsKey("controller"))
            {
                ScenarioContext.Current.Add("controller", new ArticleController(new GenericRepository<ContentElement>(), new GenericRepository<ArticleDefinition>()));
            }
            return (ArticleController)ScenarioContext.Current["controller"];
        }
    }
}
