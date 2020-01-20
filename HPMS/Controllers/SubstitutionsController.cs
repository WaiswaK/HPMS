using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HPMS.Models;

namespace HPMS.Controllers
{
    public class SubstitutionsController : Controller
    {
        private Models.HPMS db = new Models.HPMS();

        // GET: Substitutions
        public ActionResult Index()
        {
            var substitutions = db.Substitutions.Include(s => s.Reason1).Include(s => s.Reason1).Include(s => s.Substitution_Line);
            return View(substitutions.ToList());
        }

        // GET: Substitutions/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Substitution substitution = db.Substitutions.Find(id);
            if (substitution == null)
            {
                return HttpNotFound();
            }
            return View(substitution);
        }

        // GET: Substitutions/Create
        public ActionResult Create()
        {
            ViewBag.Reason_ID = new SelectList(db.Reasons, "Reson_ID", "Reason1");
            ViewBag.Reason_ID = new SelectList(db.Reasons, "Reson_ID", "Reason1");
            ViewBag.Line_ID = new SelectList(db.Substitution_Lines, "Line_ID", "Line_ID");
            return View();
        }

        // POST: Substitutions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Substution_ID,Substitution_Date,PID,Reason_ID,Line_ID,Regimen")] Substitution substitution)
        {
            if (ModelState.IsValid)
            {
                db.Substitutions.Add(substitution);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Reason_ID = new SelectList(db.Reasons, "Reson_ID", "Reason1", substitution.Reason_ID);
            ViewBag.Reason_ID = new SelectList(db.Reasons, "Reson_ID", "Reason1", substitution.Reason_ID);
            ViewBag.Line_ID = new SelectList(db.Substitution_Lines, "Line_ID", "Line_ID", substitution.Line_ID);
            return View(substitution);
        }

        // GET: Substitutions/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Substitution substitution = db.Substitutions.Find(id);
            if (substitution == null)
            {
                return HttpNotFound();
            }
            ViewBag.Reason_ID = new SelectList(db.Reasons, "Reson_ID", "Reason1", substitution.Reason_ID);
            ViewBag.Reason_ID = new SelectList(db.Reasons, "Reson_ID", "Reason1", substitution.Reason_ID);
            ViewBag.Line_ID = new SelectList(db.Substitution_Lines, "Line_ID", "Line_ID", substitution.Line_ID);
            return View(substitution);
        }

        // POST: Substitutions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Substution_ID,Substitution_Date,PID,Reason_ID,Line_ID,Regimen")] Substitution substitution)
        {
            if (ModelState.IsValid)
            {
                db.Entry(substitution).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Reason_ID = new SelectList(db.Reasons, "Reson_ID", "Reason1", substitution.Reason_ID);
            ViewBag.Reason_ID = new SelectList(db.Reasons, "Reson_ID", "Reason1", substitution.Reason_ID);
            ViewBag.Line_ID = new SelectList(db.Substitution_Lines, "Line_ID", "Line_ID", substitution.Line_ID);
            return View(substitution);
        }

        // GET: Substitutions/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Substitution substitution = db.Substitutions.Find(id);
            if (substitution == null)
            {
                return HttpNotFound();
            }
            return View(substitution);
        }

        // POST: Substitutions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Substitution substitution = db.Substitutions.Find(id);
            db.Substitutions.Remove(substitution);
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
