using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HPMS.Models;

namespace HPMS.Controllers
{
    public class COHORTsController : Controller
    {
        private Models.HPMS db = new Models.HPMS();

        // GET: COHORTs
        [Authorize]
        public ActionResult Index()
        {
            var cOHORTs = db.COHORTs.Include(c => c.Patient);
            return View(cOHORTs.ToList());
        }

        // GET: COHORTs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COHORT cOHORT = db.COHORTs.Find(id);
            if (cOHORT == null)
            {
                return HttpNotFound();
            }
            return View(cOHORT);
        }

        // GET: COHORTs/Create
        public ActionResult Create()
        {
            ViewBag.PID = new SelectList(db.Patients, "PID", "NIN");
            return View();
        }

        // POST: COHORTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COHORT_ID,Date_of_Start,PID")] COHORT cOHORT)
        {
            if (ModelState.IsValid)
            {
                db.COHORTs.Add(cOHORT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PID = new SelectList(db.Patients, "PID", "NIN", cOHORT.PID);
            return View(cOHORT);
        }

        // GET: COHORTs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COHORT cOHORT = db.COHORTs.Find(id);
            if (cOHORT == null)
            {
                return HttpNotFound();
            }
            ViewBag.PID = new SelectList(db.Patients, "PID", "NIN", cOHORT.PID);
            return View(cOHORT);
        }

        // POST: COHORTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COHORT_ID,Date_of_Start,PID")] COHORT cOHORT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOHORT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PID = new SelectList(db.Patients, "PID", "NIN", cOHORT.PID);
            return View(cOHORT);
        }

        // GET: COHORTs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COHORT cOHORT = db.COHORTs.Find(id);
            if (cOHORT == null)
            {
                return HttpNotFound();
            }
            return View(cOHORT);
        }

        // POST: COHORTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            COHORT cOHORT = db.COHORTs.Find(id);
            db.COHORTs.Remove(cOHORT);
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
