﻿using ShuperShoesApp.Entities;
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
            var lst = await Service.Get<Article>();

            return View(lst);
        }


        public async Task<ActionResult> ByStore(string Id)
        {
            await LoadDropDownLists();

            if (!string.IsNullOrEmpty(Id) )
            {
                int store = int.Parse(Id);
                var lst = await Service.GetByStore<Article>(store);

                var bystore = new ArticlesByStoreViewModel() { Store_Id = store, listArticles = lst };

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
                    await Service.Create<Article>(article);


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

            var article = await Service.Get<Article>(id);

            if (article == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            await LoadDropDownLists();

            return View(article);
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
                    await Service.Edit<Article>(article);

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

            var article = await Service.Get<Article>(id);

            if (article == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return View(article);
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
                    await Service.Delete<Article>(id);

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
            var ct = await StoreService.Get<Store>();

            ViewData["Stores"] = new SelectList(ct, "Id", "Name");
        }



    }
}