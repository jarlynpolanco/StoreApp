using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using StoreApp.UI.Models;

namespace StoreApp.UI.Controllers
{
    public class SalesProductsController : Controller
    {
        private StoreEntities db = new StoreEntities();

        // GET: SalesProducts
        public ActionResult Index()
        {
            var salesProducts = db.SalesProducts.Include(s => s.SalesProvider);
            return View(salesProducts.ToList());
        }

        // GET: SalesProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesProduct salesProduct = db.SalesProducts.Find(id);
            if (salesProduct == null)
            {
                return HttpNotFound();
            }
            return View(salesProduct);
        }

        // GET: SalesProducts/Create
        public ActionResult Create()
        {
            ViewBag.Id_Provider = new SelectList(db.SalesProviders, "Id", "Provider_Name");
            return View();
        }

        // POST: SalesProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Product_Name,Product_Price,Product_Quantity,Product_Description,Id_Provider")] SalesProduct salesProduct)
        {
            if (ModelState.IsValid)
            {
                db.SalesProducts.Add(salesProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Provider = new SelectList(db.SalesProviders, "Id", "Provider_Name", salesProduct.Id_Provider);
            return View(salesProduct);
        }

        // GET: SalesProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesProduct salesProduct = db.SalesProducts.Find(id);
            if (salesProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Provider = new SelectList(db.SalesProviders, "Id", "Provider_Name", salesProduct.Id_Provider);
            return View(salesProduct);
        }

        // POST: SalesProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Product_Name,Product_Price,Product_Quantity,Product_Description,Id_Provider")] SalesProduct salesProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Provider = new SelectList(db.SalesProviders, "Id", "Provider_Name", salesProduct.Id_Provider);
            return View(salesProduct);
        }

        // GET: SalesProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesProduct salesProduct = db.SalesProducts.Find(id);
            if (salesProduct == null)
            {
                return HttpNotFound();
            }
            return View(salesProduct);
        }

        // POST: SalesProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalesProduct salesProduct = db.SalesProducts.Find(id);
            db.SalesProducts.Remove(salesProduct);
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

        // GET: SalesProducts/Edit/5
        public ActionResult SaleProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesProduct salesProduct = db.SalesProducts.Find(id);
            if (salesProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Provider = new SelectList(db.SalesProviders, "Id", "Provider_Name", salesProduct.Id_Provider);
            return View(salesProduct);
        }

        // POST: SalesProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaleProduct([Bind(Include = "Id,Product_Name,Product_Price,Product_Quantity,Product_Description,Id_Provider")] 
                SalesProduct salesProduct, int cantidadProducto, int precioVenta)
        {
            if (ModelState.IsValid)
            {
                Sale sale = new Sale
                {
                    Total_Sale = precioVenta
                };
                db.Sales.Add(sale);

                salesProduct.Product_Quantity -= cantidadProducto;
                db.Entry(salesProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Provider = new SelectList(db.SalesProviders, "Id", "Provider_Name", salesProduct.Id_Provider);
            return View(salesProduct);
        }

        public ActionResult SalePrice(int productId, int productQuantity) 
        {
            var productValue = db.SalesProducts.Find(productId).Product_Price;

            return Content((int.Parse(productValue.ToString()) * productQuantity).ToString());
        }
    }
}
