using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HPMS.Models;

namespace HPMS.Controllers
{
    public class Substitution_LineController : Controller
    {
        private Models.HPMS db = new Models.HPMS();

        // GET: Substitution_Line
        public ActionResult Index()
        {
            return View(db.Substitution_Lines.ToList());
        }

        // GET: Substitution_Line/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Substitution_Line substitution_Line = db.Substitution_Lines.Find(id);
            if (substitution_Line == null)
            {
                return HttpNotFound();
            }
            return View(substitution_Line);
        }

        // GET: Substitution_Line/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Substitution_Line/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Line_ID,Line_Number")] Substitution_Line substitution_Line)
        {
            if (ModelState.IsValid)
            {
                db.Substitution_Lines.Add(substitution_Line);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(substitution_Line);
        }

        // GET: Substitution_Line/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Substitution_Line substitution_Line = db.Substitution_Lines.Find(id);
            if (substitution_Line == null)
            {
                return HttpNotFound();
            }
            return View(substitution_Line);
        }

        // POST: Substitution_Line/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Line_ID,Line_Number")] Substitution_Line substitution_Line)
        {
            if (ModelState.IsValid)
            {
                db.Entry(substitution_Line).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(substitution_Line);
        }

        // GET: Substitution_Line/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Substitution_Line substitution_Line = db.Substitution_Lines.Find(id);
            if (substitution_Line == null)
            {
                return HttpNotFound();
            }
            return View(substitution_Line);
        }

        // POST: Substitution_Line/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Substitution_Line substitution_Line = db.Substitution_Lines.Find(id);
            db.Substitution_Lines.Remove(substitution_Line);
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
