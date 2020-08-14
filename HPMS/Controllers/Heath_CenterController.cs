using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HPMS.Models;

namespace HPMS.Controllers
{
    public class Heath_CenterController : Controller
    {
        private readonly Models.HPMS db = new Models.HPMS();

        // GET: Heath_Center
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View(db.Heath_Centers.ToList());
        }

        // GET: Heath_Center/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heath_Center heath_Center = db.Heath_Centers.Find(id);
            if (heath_Center == null)
            {
                return HttpNotFound();
            }
            return View(heath_Center);
        }

        // GET: Heath_Center/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Heath_Center/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HCID,Center,Latitude,Longtitude,District,Parish")] Heath_Center heath_Center)
        {
            var query = db.Heath_Centers.Count() + 1;
            string temp = "HC-" + query;
            bool exist = false;
            try
            {
                var search = db.Heath_Centers.Where(c => c.HCID == temp).Single();
                exist = true;
            }
            catch
            {
                exist = false;

            }
            if (exist)
            {
                var all = db.Heath_Centers.ToList();
                var HC = all.Last();
                HC.HCID = "HC-" + DataModels.DataProcess.NextNumber(HC.HCID);
            }
            else
            {
                heath_Center.HCID = temp;
            }
            if (ModelState.IsValid)
            {
                db.Heath_Centers.Add(heath_Center);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(heath_Center);
        }

        // GET: Heath_Center/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heath_Center heath_Center = db.Heath_Centers.Find(id);
            if (heath_Center == null)
            {
                return HttpNotFound();
            }
            return View(heath_Center);
        }

        // POST: Heath_Center/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HCID,Center,Latitude,Longtitude,District,Parish")] Heath_Center heath_Center)
        {
            if (ModelState.IsValid)
            {
                db.Entry(heath_Center).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(heath_Center);
        }

        // GET: Heath_Center/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heath_Center heath_Center = db.Heath_Centers.Find(id);
            if (heath_Center == null)
            {
                return HttpNotFound();
            }
            return View(heath_Center);
        }

        // POST: Heath_Center/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Heath_Center heath_Center = db.Heath_Centers.Find(id);
            db.Heath_Centers.Remove(heath_Center);
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
