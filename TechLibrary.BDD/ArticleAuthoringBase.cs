using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        protected ArticleDefinition SaveArticleDefinition(ArticleDefinition articleDefinition)
        {
            var controller = GetController();
            return controller.SaveArticle(articleDefinition);

        }

        protected ArticleController GetController()
        {
            if (!ScenarioContext.Current.ContainsKey("controller"))
            {
                ScenarioContext.Current.Add("controller", new ArticleController(new GenericRepository<ContentElement>()));
            }
            return (ArticleController)ScenarioContext.Current["controller"];
        }
    }
}
