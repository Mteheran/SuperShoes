using SuperShoesApp.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SuperShoesApp.Api.Controllers
{
    [RoutePrefix("api/services/stores")]
    public class StoresController : ApiController
    {
        Data.SuperShoesDBEntities context = new Data.SuperShoesDBEntities();

        [HttpGet]
        [Route("")]
        public IHttpActionResult Stores()
        {
            return Ok(context.Stores.ToList());
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Stores(int id)
        {
            return Ok(context.Stores.SingleOrDefault(p=> p.Id==id));
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult StoresCreate(Stores store)
        {
            var newStore = context.Stores.Add(store);
            context.SaveChanges();
            return Ok(newStore);
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult StoresEdit(Stores store)
        {
            var storebd = context.Stores.Single(p => p.Id == store.Id);

            storebd.Name = store.Name;
            storebd.Address = store.Address;
            context.SaveChanges();
            return Ok(storebd);
        }

        [HttpPatch]
        [Route("{id}")]
        public IHttpActionResult StoresDelete([FromBody]int Id)
        {
            var storebd = context.Stores.Single(p => p.Id == Id);

            var newStore = context.Stores.Remove(storebd);
            context.SaveChanges();
            return Ok(newStore);
        }
    }
}