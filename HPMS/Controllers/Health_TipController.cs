using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HPMS.Models;

namespace HPMS.Controllers
{
    public class Health_TipController : Controller
    {
        private Models.HPMS db = new Models.HPMS();

        // GET: Health_Tip
        public ActionResult Index()
        {
            return View(db.Health_Tips.ToList());
        }

        // GET: Health_Tip/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Health_Tip health_Tip = db.Health_Tips.Find(id);
            if (health_Tip == null)
            {
                return HttpNotFound();
            }
            return View(health_Tip);
        }

        // GET: Health_Tip/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Health_Tip/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HT,Tip")] Health_Tip health_Tip)
        {
            var query = db.Diet_Charts.Count() + 1;
            string temp = "HT-" + query;
            bool exist = false;
            try
            {
                var search = db.Health_Tips.Where(c => c.HT == temp).Single();
                exist = true;
            }
            catch
            {
                exist = false;

            }
            if (exist)
            {
                var all = db.Health_Tips.ToList();
                var tip = all.Last();
                tip.HT = "HT-" + DataModels.DataProcess.NextNumber(tip.HT) ;
            }
            else
            {
                health_Tip.HT = temp;
            }
            if (ModelState.IsValid)
            {
                db.Health_Tips.Add(health_Tip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(health_Tip);
        }

        // GET: Health_Tip/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Health_Tip health_Tip = db.Health_Tips.Find(id);
            if (health_Tip == null)
            {
                return HttpNotFound();
            }
            return View(health_Tip);
        }

        // POST: Health_Tip/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HT,Tip")] Health_Tip health_Tip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(health_Tip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(health_Tip);
        }

        // GET: Health_Tip/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Health_Tip health_Tip = db.Health_Tips.Find(id);
            if (health_Tip == null)
            {
                return HttpNotFound();
            }
            return View(health_Tip);
        }

        // POST: Health_Tip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Health_Tip health_Tip = db.Health_Tips.Find(id);
            db.Health_Tips.Remove(health_Tip);
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
