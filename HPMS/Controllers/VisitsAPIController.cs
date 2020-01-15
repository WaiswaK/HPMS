using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HPMS.Models;

namespace HPMS.Controllers
{
    public class VisitsAPIController : ApiController
    {
        private Models.HPMS db = new Models.HPMS();

        // GET: api/VisitsAPI
        public IQueryable<Visit> GetVisits()
        {
            return db.Visits;
        }

        // GET: api/VisitsAPI/5
        [ResponseType(typeof(Visit))]
        public IHttpActionResult GetVisit(string id)
        {
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return NotFound();
            }

            return Ok(visit);
        }

        // PUT: api/VisitsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVisit(string id, Visit visit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != visit.Visit_ID)
            {
                return BadRequest();
            }

            db.Entry(visit).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/VisitsAPI
        [ResponseType(typeof(Visit))]
        public IHttpActionResult PostVisit(Visit visit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Visits.Add(visit);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VisitExists(visit.Visit_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = visit.Visit_ID }, visit);
        }

        // DELETE: api/VisitsAPI/5
        [ResponseType(typeof(Visit))]
        public IHttpActionResult DeleteVisit(string id)
        {
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return NotFound();
            }

            db.Visits.Remove(visit);
            db.SaveChanges();

            return Ok(visit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VisitExists(string id)
        {
            return db.Visits.Count(e => e.Visit_ID == id) > 0;
        }
    }
}