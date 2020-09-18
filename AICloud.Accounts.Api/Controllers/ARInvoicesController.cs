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
    public class ARInvoicesController : ApiController
    {
        private AccountsDbContext db = new AccountsDbContext();

        // GET: api/ARInvoices
        public IQueryable<ARInvoice> GetARInvoices()
        {
            return db.ARInvoices;
        }

        // GET: api/ARInvoices/5
        [ResponseType(typeof(ARInvoice))]
        public IHttpActionResult GetARInvoice(int id)
        {
            ARInvoice aRInvoice = db.ARInvoices.Find(id);
            if (aRInvoice == null)
            {
                return NotFound();
            }

            return Ok(aRInvoice);
        }

        // PUT: api/ARInvoices/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutARInvoice(int id, ARInvoice aRInvoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aRInvoice.Id)
            {
                return BadRequest();
            }

            db.Entry(aRInvoice).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ARInvoiceExists(id))
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

        // POST: api/ARInvoices
        [ResponseType(typeof(ARInvoice))]
        public IHttpActionResult PostARInvoice(ARInvoice aRInvoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ARInvoices.Add(aRInvoice);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aRInvoice.Id }, aRInvoice);
        }

        // DELETE: api/ARInvoices/5
        [ResponseType(typeof(ARInvoice))]
        public IHttpActionResult DeleteARInvoice(int id)
        {
            ARInvoice aRInvoice = db.ARInvoices.Find(id);
            if (aRInvoice == null)
            {
                return NotFound();
            }

            db.ARInvoices.Remove(aRInvoice);
            db.SaveChanges();

            return Ok(aRInvoice);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ARInvoiceExists(int id)
        {
            return db.ARInvoices.Count(e => e.Id == id) > 0;
        }
    }
}