using ShuperShoesApp.Entities;
using ShuperShoesApp.Entities.Results;
using SuperShoesApp.Api;
using SuperShoesApp.Api.Data;
using SuperShoesApp.Api.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SuperArticlesApp.Api.Controllers
{
    [RoutePrefix("api/services/articles")]
    public class ArticlesController : ApiController
    {
        SuperShoesApp.Api.Data.SuperShoesDBEntities context = new SuperShoesApp.Api.Data.SuperShoesDBEntities();

        [HttpGet]
        [Route("")]
        public IHttpActionResult Articles()
        {
            try
            {            
                var list = context.Articles.ToList();

                return Ok(new ResultArticlesApi() { Success = true, articles = list, Total_elements = list.Count });
            }
            catch (Exception ex)
            {
                return Ok(new ResultArticlesApi() { Error_msg = ex.Message, Success = false, Error_code = 500 });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Articles(int id)
        {
            try
            {
                var article = context.Articles.SingleOrDefault(p => p.Id == id);

                return Ok(new ResultArticleApi() { Success = true, article = article});
            }
            catch (Exception ex)
            {
                return Ok(new ResultArticlesApi() { Error_msg = ex.Message, Success = false, Error_code = 500 });
            }

        }

        [HttpGet]
        [Route("stores/{id}")]
        public IHttpActionResult ByStore(string id)
        {
            try
            {
                int intId = 0;
                if (int.TryParse(id, out intId))
                {
                    if (context.Stores.Single(p => p.Id == intId) != null)
                    {

                        var list = context.Articles.Where(p => p.Store_id == intId).ToList();

                        return Ok(new ResultArticlesApi() { Success = true, articles = list, Total_elements = list.Count });

                    }
                    else
                    {
                        return Ok(new ResultArticlesApi() { Success = false, Error_code = 404, Error_msg = "Record not Found" });
                    }
                }
                else
                {
                    return Ok(new ResultArticlesApi() { Success = false, Error_code = 400, Error_msg = "Bad Request" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new ResultArticlesApi() { Error_msg = ex.Message, Success = false, Error_code = 500 });
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult ArticlesCreate(Articles article)
        {
            
            var newArticle = context.Articles.Add(article);
            context.SaveChanges();
            return Ok(new Result() { Success = true });
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
            return Ok(new Result() { Success = true });
        }

        [HttpPatch]
        [Route("{id}")]
        public IHttpActionResult ArticlesDelete([FromBody]int Id)
        {
            var articlebd = context.Articles.Single(p => p.Id == Id);

            var newArticle = context.Articles.Remove(articlebd);
            context.SaveChanges();
            return Ok(new Result() { Success = true });
        }
    }
}