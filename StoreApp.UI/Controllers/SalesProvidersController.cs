using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using StoreApp.UI.Models;

namespace StoreApp.UI.Controllers
{
    public class SalesProvidersController : Controller
    {
        private StoreEntities db = new StoreEntities();

        // GET: SalesProviders
        public ActionResult Index()
        {
            return View(db.SalesProviders.ToList());
        }

        // GET: SalesProviders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesProvider salesProvider = db.SalesProviders.Find(id);
            if (salesProvider == null)
            {
                return HttpNotFound();
            }
            return View(salesProvider);
        }

        // GET: SalesProviders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalesProviders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Provider_Name")] SalesProvider salesProvider)
        {
            if (ModelState.IsValid)
            {
                db.SalesProviders.Add(salesProvider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salesProvider);
        }

        // GET: SalesProviders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesProvider salesProvider = db.SalesProviders.Find(id);
            if (salesProvider == null)
            {
                return HttpNotFound();
            }
            return View(salesProvider);
        }

        // POST: SalesProviders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Provider_Name")] SalesProvider salesProvider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesProvider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salesProvider);
        }

        // GET: SalesProviders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesProvider salesProvider = db.SalesProviders.Find(id);
            if (salesProvider == null)
            {
                return HttpNotFound();
            }
            return View(salesProvider);
        }

        // POST: SalesProviders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalesProvider salesProvider = db.SalesProviders.Find(id);
            db.SalesProviders.Remove(salesProvider);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
