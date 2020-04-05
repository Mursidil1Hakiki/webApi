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
using TestRestApi.Models;

namespace TestRestApi.Controllers
{
    public class activitiesController : ApiController
    {
        private DBActivities db = new DBActivities();

        // GET: api/activities
        public IQueryable<activity> Getactivities()
        {
            return db.activities;
        }

        // GET: api/activities/5
        [ResponseType(typeof(activity))]
        public IHttpActionResult Getactivity(int id)
        {
            activity activity = db.activities.Find(id);
            if (activity == null)
            {
                return NotFound();
            }

            return Ok(activity);
        }

        // PUT: api/activities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putactivity(int id, activity activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activity.No)
            {
                return BadRequest();
            }

            db.Entry(activity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!activityExists(id))
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

        // POST: api/activities
        [ResponseType(typeof(activity))]
        public IHttpActionResult Postactivity(activity activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.activities.Add(activity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = activity.No }, activity);
        }

        // DELETE: api/activities/5
        [ResponseType(typeof(activity))]
        public IHttpActionResult Deleteactivity(int id)
        {
            activity activity = db.activities.Find(id);
            if (activity == null)
            {
                return NotFound();
            }

            db.activities.Remove(activity);
            db.SaveChanges();

            return Ok(activity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool activityExists(int id)
        {
            return db.activities.Count(e => e.No == id) > 0;
        }
    }
}