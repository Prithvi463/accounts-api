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
    public class APInvoicesController : ApiController
    {
        private AccountsDbContext db = new AccountsDbContext();

        // GET: api/APInvoices
        public IQueryable<APInvoice> GetAPInvoices()
        {
            return db.APInvoices;
        }

        // GET: api/APInvoices/5
        [ResponseType(typeof(APInvoice))]
        public IHttpActionResult GetAPInvoice(int id)
        {
            APInvoice aPInvoice = db.APInvoices.Find(id);
            if (aPInvoice == null)
            {
                return NotFound();
            }

            return Ok(aPInvoice);
        }

        // PUT: api/APInvoices/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAPInvoice(int id, APInvoice aPInvoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aPInvoice.Id)
            {
                return BadRequest();
            }

            db.Entry(aPInvoice).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!APInvoiceExists(id))
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

        // POST: api/APInvoices
        [ResponseType(typeof(APInvoice))]
        public IHttpActionResult PostAPInvoice(APInvoice aPInvoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.APInvoices.Add(aPInvoice);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aPInvoice.Id }, aPInvoice);
        }

        // DELETE: api/APInvoices/5
        [ResponseType(typeof(APInvoice))]
        public IHttpActionResult DeleteAPInvoice(int id)
        {
            APInvoice aPInvoice = db.APInvoices.Find(id);
            if (aPInvoice == null)
            {
                return NotFound();
            }

            db.APInvoices.Remove(aPInvoice);
            db.SaveChanges();

            return Ok(aPInvoice);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool APInvoiceExists(int id)
        {
            return db.APInvoices.Count(e => e.Id == id) > 0;
        }
    }
}