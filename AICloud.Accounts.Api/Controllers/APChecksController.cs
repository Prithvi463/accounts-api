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
using AICloud.Accounts.Api.Attributes;
using AICloud.Accounts.Api.Context;
using AICloud.Accounts.Api.Models;

namespace AICloud.Accounts.Api.Controllers
{
    [AuthorizeUser]
    public class APChecksController : ApiController
    {
        private AccountsDbContext db = new AccountsDbContext();

        // GET: api/APChecks
        public IQueryable<APCheck> GetAPChecks()
        {
            return db.APChecks;
        }

        // GET: api/APChecks/5
        [ResponseType(typeof(APCheck))]
        public IHttpActionResult GetAPChecks(int id)
        {
            APCheck aPChecks = db.APChecks.Find(id);
            if (aPChecks == null)
            {
                return NotFound();
            }

            return Ok(aPChecks);
        }

        // PUT: api/APChecks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAPChecks(int id, APCheck aPChecks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aPChecks.Id)
            {
                return BadRequest();
            }

            db.Entry(aPChecks).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!APChecksExists(id))
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

        // POST: api/APChecks
        [ResponseType(typeof(APCheck))]
        public IHttpActionResult PostAPChecks(APCheck aPChecks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.APChecks.Add(aPChecks);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aPChecks.Id }, aPChecks);
        }

        // DELETE: api/APChecks/5
        [ResponseType(typeof(APCheck))]
        public IHttpActionResult DeleteAPChecks(int id)
        {
            APCheck aPChecks = db.APChecks.Find(id);
            if (aPChecks == null)
            {
                return NotFound();
            }

            db.APChecks.Remove(aPChecks);
            db.SaveChanges();

            return Ok(aPChecks);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool APChecksExists(int id)
        {
            return db.APChecks.Count(e => e.Id == id) > 0;
        }
    }
}