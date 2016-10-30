using ShuperShoesApp.Entities;
using SuperShoesApp.Services.Contracts;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SuperShoesApp.Controllers
{
    public class StoresController : Controller
    {

        IStoresService Service;

        public StoresController (IStoresService service)
        {
            Service = service;
        }

        // GET: Stores
        public async Task<ActionResult> Index()
        {
            var lst = await Service.Get<Store>();

            return View(lst);
        }
        
        // GET: Stores/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: Stores/Create
        [HttpPost]
        public async Task<ActionResult> Create(Store store)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    await Service.Create<Store>(store);


                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Stores/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null || id==0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var store = await Service.Get<Store>(id);

            if (store==null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return View(store);
        }

        // POST: Stores/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Store store)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    await Service.Edit<Store>(store);

                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Stores/Delete/5

        public async Task<ActionResult> Delete(int id)
        {

            if (id == null || id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var store = await Service.Get<Store>(id);

            if (store == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return View(store);
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    await Service.Delete<Store>(id);

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
