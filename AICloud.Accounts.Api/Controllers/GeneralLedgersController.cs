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
    public class GeneralLedgersController : ApiController
    {
        private AccountsDbContext db = new AccountsDbContext();

        // GET: api/GeneralLedgers
        public IQueryable<GeneralLedger> GetGeneralLedgers()
        {
            return db.GeneralLedgers;
        }

        // GET: api/GeneralLedgers/5
        [ResponseType(typeof(GeneralLedger))]
        public IHttpActionResult GetGeneralLedger(int id)
        {
            GeneralLedger generalLedger = db.GeneralLedgers.Find(id);
            if (generalLedger == null)
            {
                return NotFound();
            }

            return Ok(generalLedger);
        }

        // PUT: api/GeneralLedgers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGeneralLedger(int id, GeneralLedger generalLedger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != generalLedger.Id)
            {
                return BadRequest();
            }

            db.Entry(generalLedger).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneralLedgerExists(id))
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

        // POST: api/GeneralLedgers
        [ResponseType(typeof(GeneralLedger))]
        public IHttpActionResult PostGeneralLedger(GeneralLedger generalLedger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GeneralLedgers.Add(generalLedger);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = generalLedger.Id }, generalLedger);
        }

        // DELETE: api/GeneralLedgers/5
        [ResponseType(typeof(GeneralLedger))]
        public IHttpActionResult DeleteGeneralLedger(int id)
        {
            GeneralLedger generalLedger = db.GeneralLedgers.Find(id);
            if (generalLedger == null)
            {
                return NotFound();
            }

            db.GeneralLedgers.Remove(generalLedger);
            db.SaveChanges();

            return Ok(generalLedger);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GeneralLedgerExists(int id)
        {
            return db.GeneralLedgers.Count(e => e.Id == id) > 0;
        }
    }
}