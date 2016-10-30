using ShuperShoesApp.Entities;
using SuperShoesApp.Services.Contracts;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace SuperShoesApp.Controllers
{
    public class ArticlesController : Controller
    {

        IArticlesService Service;

        public ArticlesController(IArticlesService service)
        {
            Service = service;
        }

        // GET: Articles
        public async Task<ActionResult> Index()
        {
            var lst = await Service.Get<Article>();

            return View(lst);
        }

        // GET: Articles/Create
        public async Task<ActionResult> Create()
        {
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
    }
}