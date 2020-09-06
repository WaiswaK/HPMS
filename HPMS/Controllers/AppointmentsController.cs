using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HPMS.Models;

namespace HPMS.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly Models.HPMS db = new Models.HPMS();

        // GET: Appointments
        public ActionResult Index()
        {
            var appointments = db.Appointments.Include(a => a.Patient).Include(a => a.Staff);
            return View(appointments.ToList());
        }

        // GET: Appointments/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            ViewBag.PID = new SelectList(db.Patients, "PID", "Full_Name");
            ViewBag.Doctor = new SelectList(db.Staffs, "SID", "SID");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Appointment_ID,PID,Doctor,Appointment_Date,Appointment_Time,Accepted,Rescheduled,Rescheduled_Date,Rescheduled_Time,Completed")] Appointment appointment)
        {
            var query = db.Appointments.Count() + 1;
            string temp = "APP-" + query;
            bool exist = false;
            try
            {
                var search = db.Appointments.Where(c => c.Appointment_ID == temp).Single();
                exist = true;
            }
            catch
            {
                exist = false;
            }
            if (exist)
            {
                var all = db.Appointments.ToList();
                var APP = all.Last();
                appointment.Appointment_ID = "APP-" + +DataModels.DataProcess.NextNumber(APP.Appointment_ID);
            }
            else
            {
                appointment.Appointment_ID = temp;
            }
            if (ModelState.IsValid)
            {
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PID = new SelectList(db.Patients, "PID", "Full_Name", appointment.PID);
            ViewBag.Doctor = new SelectList(db.Staffs, "SID", "SID", appointment.Doctor);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.PID = new SelectList(db.Patients, "PID", "Full_Name", appointment.PID);
            ViewBag.Doctor = new SelectList(db.Staffs, "SID", "SID", appointment.Doctor);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Appointment_ID,PID,Doctor,Appointment_Date,Appointment_Time,Accepted,Rescheduled,Rescheduled_Date,Rescheduled_Time,Completed")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PID = new SelectList(db.Patients, "PID", "Full_Name", appointment.PID);
            ViewBag.Doctor = new SelectList(db.Staffs, "SID", "SID", appointment.Doctor);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Appointment appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
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
