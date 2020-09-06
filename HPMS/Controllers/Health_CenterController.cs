using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HPMS.Models;

namespace HPMS.Controllers
{
    public class Health_CenterController : Controller
    {
        private readonly Models.HPMS db = new Models.HPMS();

        // GET: Health_Center
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View(db.Health_Centers.ToList());
        }

        // GET: Health_Center/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Health_Center health_Center = db.Health_Centers.Find(id);
            if (health_Center == null)
            {
                return HttpNotFound();
            }
            return View(health_Center);
        }

        // GET: Health_Center/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Health_Center/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HCID,Center,Latitude,Longtitude,District,Parish")] Health_Center health_Center)
        {
            var query = db.Health_Centers.Count() + 1;
            string temp = "HC-" + query;
            bool exist = false;
            try
            {
                var search = db.Health_Centers.Where(c => c.HCID == temp).Single();
                exist = true;
            }
            catch
            {
                exist = false;

            }
            if (exist)
            {
                var all = db.Health_Centers.ToList();
                var HC = all.Last();
                HC.HCID = "HC-" + DataModels.DataProcess.NextNumber(HC.HCID);
            }
            else
            {
                health_Center.HCID = temp;
            }
            if (ModelState.IsValid)
            {
                db.Health_Centers.Add(health_Center);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(health_Center);
        }

        // GET: Health_Center/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Health_Center health_Center = db.Health_Centers.Find(id);
            if (health_Center == null)
            {
                return HttpNotFound();
            }
            return View(health_Center);
        }

        // POST: Health_Center/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HCID,Center,Latitude,Longtitude,District,Parish")] Health_Center health_Center)
        {
            if (ModelState.IsValid)
            {
                db.Entry(health_Center).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(health_Center);
        }

        // GET: Health_Center/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Health_Center health_Center = db.Health_Centers.Find(id);
            if (health_Center == null)
            {
                return HttpNotFound();
            }
            return View(health_Center);
        }

        // POST: Health_Center/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Health_Center health_Center = db.Health_Centers.Find(id);
            db.Health_Centers.Remove(health_Center);
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
