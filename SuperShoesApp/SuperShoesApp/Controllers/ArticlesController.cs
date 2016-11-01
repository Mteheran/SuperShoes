using ShuperShoesApp.Entities;
using SuperShoesApp.Helpers;
using SuperShoesApp.Services.Contracts;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace SuperShoesApp.Controllers
{
    public class ArticlesController : Controller
    {

        IArticlesService Service;
        IStoresService StoreService;

        public ArticlesController(IArticlesService service, IStoresService storeservice)
        {
            Service = service;
            StoreService = storeservice;

        }

        // GET: Articles
        public async Task<ActionResult> Index()
        {
            var result = await Service.Get();

            ResultHelper.SetResult(this, result);

            return View(result.articles);
        }


        public async Task<ActionResult> ByStore(string Id)
        {
            await LoadDropDownLists();

            if (!string.IsNullOrEmpty(Id) )
            {
                int store = int.Parse(Id);

                var result = await Service.GetByStore(store);

                ResultHelper.SetResult(this, result);

                var bystore = new ArticlesByStoreViewModel() { Store_Id = store, listArticles = result.articles };

                return View(bystore);
            }
            else
            {
                return View(new ArticlesByStoreViewModel() { Store_Id = 0, listArticles = new List<Article>() });
            }
          
        }

        [HttpPost]
        public async Task<ActionResult> GetByStore()
        {
            string storeid = Request.Form["Store_Id"];
            if (!string.IsNullOrEmpty(storeid))
            {
                return RedirectToAction("ByStore/" + storeid);
            }
            else
            {
                return RedirectToAction("ByStore");
            }

        }

        // GET: Articles/Create
        public async Task<ActionResult> Create()
        {
            await LoadDropDownLists();

            return View();
        }

        // POST: Articles/Create
        [HttpPost]
        public async Task<ActionResult> Create(Article article)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    var result = await Service.Create<Article>(article);
                    ResultHelper.SetResult(this, result);

                    return RedirectToAction("Index");
                }

                await LoadDropDownLists();

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Articles/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null || id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var result = await Service.Get<Article>(id);

            if (result == null || result.article == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            await LoadDropDownLists();

            return View(result.article);
        }

        // POST: Articles/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Article article)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    var result = await Service.Edit<Article>(article);
                    ResultHelper.SetResult(this, result);
                    return RedirectToAction("Index");
                }

                await LoadDropDownLists();

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Articles/Delete/5

        public async Task<ActionResult> Delete(int id)
        {

            if (id == null || id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var result = await Service.Get<Article>(id);

            if (result == null || result.article == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            await LoadDropDownLists();

            return View(result.article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    var result =  await Service.Delete<Article>(id);
                    ResultHelper.SetResult(this, result);
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        private async Task LoadDropDownLists()
        {
            var result = await StoreService.Get();

            ResultHelper.SetResult(this, result);

            if (result.Success)
            {
                ViewData["Stores"] = new SelectList((List<Store>)result.stores, "Id", "Name");
            }
            else
            {
                ViewData["Stores"] = new SelectList(new List<Store>());
            }

        
        }



    }
}