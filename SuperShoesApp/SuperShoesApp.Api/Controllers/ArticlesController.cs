using SuperShoesApp.Api;
using SuperShoesApp.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SuperArticlesApp.Api.Controllers
{
    [RoutePrefix("api/services/Articles")]
    public class ArticlesController : ApiController
    {
        SuperShoesApp.Api.Data.SuperShoesDBEntities context = new SuperShoesApp.Api.Data.SuperShoesDBEntities();

        [HttpGet]
        [Route("")]
        public IHttpActionResult Articles()
        {
            return Ok(context.Articles.ToList());
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Articles(int id)
        {
            return Ok(context.Articles.SingleOrDefault(p => p.Id == id));
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult ArticlesCreate(Articles article)
        {
            
            var newArticle = context.Articles.Add(article);
            context.SaveChanges();
            return Ok(newArticle);
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult ArticlesEdit(Articles article)
        {
            var articlebd = context.Articles.Single(p => p.Id == article.Id);

            articlebd.Name = article.Name;
            articlebd.Description = article.Description;
            articlebd.Price = article.Price;
            articlebd.Total_in_shelf = article.Total_in_shelf;
            articlebd.Total_in_vault = article.Total_in_vault;
            articlebd.Store_id = article.Store_id;

            context.SaveChanges();
            return Ok(articlebd);
        }

        [HttpPatch]
        [Route("{id}")]
        public IHttpActionResult ArticlesDelete([FromBody]int Id)
        {
            var articlebd = context.Articles.Single(p => p.Id == Id);

            var newArticle = context.Articles.Remove(articlebd);
            context.SaveChanges();
            return Ok(newArticle);
        }
    }
}