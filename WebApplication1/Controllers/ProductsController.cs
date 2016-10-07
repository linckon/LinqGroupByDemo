using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        private ProductDemoEntities db = new ProductDemoEntities();

        // GET: Products
        public ActionResult Index()
        {
            //var query = db.ProductOptions.Where(x => x.ProductId == 4).GroupBy(x => x.Product.CategoryId).Select(g => new
            //{
            //    CategoryId = g.Key,
            //    Products = g.Select(x => x.Product)

            //});
            //var productOptions = new List<ProductOptionViewModel>();
            //var productOption = new ProductOptionViewModel();
            //foreach (var item in query)
            //{
            //    productOption.CategoryId = (int)item.CategoryId;

            //    foreach (var option in item.Products)
            //    {
            //        productOption.ProductOption = option.Name;
            //        productOptions.Add(productOption);
            //    }

            //}
            var query = ProductOptionViewModels();
            return View(query.ToList());
        }

        private IQueryable<ProductOptionViewModel> ProductOptionViewModels()
        {
            var query =
                    db.ProductOptions
                    .Where(x => x.ProductId == 4)
                    .GroupBy(x => x.Product.CategoryId)
                    .Select(g => new ProductOptionViewModel
                    {
                        CategoryId = g.Key,
                        ProductOptions = g
                    });
            return query;
        }
        //private IQueryable<Group<string, ProductOption>> ProductOptionViewModels()
        //{
        //    var query =
        //            db.ProductOptions
        //            .Where(x => x.ProductId == 4)
        //            .GroupBy(x => x.Product.CategoryId)
        //            .Select(g => new Group<string, ProductOption>
        //            {
        //                Key = g.Key,
        //                Values = g
        //            });
        //    return query;
        //}

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
