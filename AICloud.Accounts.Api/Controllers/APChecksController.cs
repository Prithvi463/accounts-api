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
using AICloud.Accounts.Api.Enums.GeneralLedger;
using AICloud.Accounts.Api.Models;
using AICloud.Accounts.Api.Services.GeneralLedger;

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
        public IHttpActionResult GetAPCheck(int id)
        {
            APCheck aPCheck = db.APChecks.Find(id);
            if (aPCheck == null)
            {
                return NotFound();
            }

            return Ok(aPCheck);
        }

        // PUT: api/APChecks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAPCheck(int id, APCheck aPCheck)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aPCheck.Id)
            {
                return BadRequest();
            }

            db.Entry(aPCheck).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!APCheckExists(id))
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
        public IHttpActionResult PostAPCheck(APCheck aPCheck)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.APChecks.Add(aPCheck);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = aPCheck.Id }, aPCheck);
        }

        // DELETE: api/APChecks/5
        [ResponseType(typeof(APCheck))]
        public IHttpActionResult DeleteAPCheck(int id)
        {
            APCheck aPCheck = db.APChecks.Find(id);
            if (aPCheck == null)
            {
                return NotFound();
            }

            db.APChecks.Remove(aPCheck);
            db.SaveChanges();

            return Ok(aPCheck);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool APCheckExists(int id)
        {
            return db.APChecks.Count(e => e.Id == id) > 0;
        }
    }
}