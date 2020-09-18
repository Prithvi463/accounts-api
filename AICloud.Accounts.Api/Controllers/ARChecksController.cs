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
using AICloud.Accounts.Api.Context;
using AICloud.Accounts.Api.Models;

namespace AICloud.Accounts.Api.Controllers
{
    public class ARChecksController : ApiController
    {
        private AccountsDbContext db = new AccountsDbContext();

        // GET: api/ARChecks
        public IQueryable<ARCheck> GetARChecks()
        {
            return db.ARChecks;
        }

        // GET: api/ARChecks/5
        [ResponseType(typeof(ARCheck))]
        public IHttpActionResult GetARCheck(int id)
        {
            ARCheck aRCheck = db.ARChecks.Find(id);
            if (aRCheck == null)
            {
                return NotFound();
            }

            return Ok(aRCheck);
        }

        // PUT: api/ARChecks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutARCheck(int id, ARCheck aRCheck)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aRCheck.Id)
            {
                return BadRequest();
            }

            db.Entry(aRCheck).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ARCheckExists(id))
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

        // POST: api/ARChecks
        [ResponseType(typeof(ARCheck))]
        public IHttpActionResult PostARCheck(ARCheck aRCheck)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ARChecks.Add(aRCheck);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aRCheck.Id }, aRCheck);
        }

        // DELETE: api/ARChecks/5
        [ResponseType(typeof(ARCheck))]
        public IHttpActionResult DeleteARCheck(int id)
        {
            ARCheck aRCheck = db.ARChecks.Find(id);
            if (aRCheck == null)
            {
                return NotFound();
            }

            db.ARChecks.Remove(aRCheck);
            db.SaveChanges();

            return Ok(aRCheck);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ARCheckExists(int id)
        {
            return db.ARChecks.Count(e => e.Id == id) > 0;
        }
    }
}