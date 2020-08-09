using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HPMS.Models;

namespace HPMS.Controllers
{
    public class Diet_ChartController : Controller
    {
        private Models.HPMS db = new Models.HPMS();

        // GET: Diet_Chart
        public ActionResult Index()
        {
            return View(db.Diet_Charts.ToList());
        }

        // GET: Diet_Chart/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diet_Chart diet_Chart = db.Diet_Charts.Find(id);
            if (diet_Chart == null)
            {
                return HttpNotFound();
            }
            return View(diet_Chart);
        }

        // GET: Diet_Chart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Diet_Chart/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DC,Content")] Diet_Chart diet_Chart)
        {
            var query = db.Diet_Charts.Count() + 1; 
            string temp = "DIET-" + query;
            bool exist = false;
            try
            {
                var search = db.Diet_Charts.Where(c => c.DC == temp).Single();
                exist = true;
            }
            catch
            {
                exist = false;

            }
            if (exist)
            {
                var all = db.Diet_Charts.ToList();
                var diet = all.Last();
               diet.DC = "DIET-" + DataModels.DataProcess.NextNumber(diet.DC);
            }
            else
            {
                diet_Chart.DC = temp;
            }
            if (ModelState.IsValid)
            {
                db.Diet_Charts.Add(diet_Chart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(diet_Chart);
        }

        // GET: Diet_Chart/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diet_Chart diet_Chart = db.Diet_Charts.Find(id);
            if (diet_Chart == null)
            {
                return HttpNotFound();
            }
            return View(diet_Chart);
        }

        // POST: Diet_Chart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DC,Content")] Diet_Chart diet_Chart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diet_Chart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diet_Chart);
        }

        // GET: Diet_Chart/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diet_Chart diet_Chart = db.Diet_Charts.Find(id);
            if (diet_Chart == null)
            {
                return HttpNotFound();
            }
            return View(diet_Chart);
        }

        // POST: Diet_Chart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Diet_Chart diet_Chart = db.Diet_Charts.Find(id);
            db.Diet_Charts.Remove(diet_Chart);
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
