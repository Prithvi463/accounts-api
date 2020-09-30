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
    public class VendorContactsController : ApiController
    {
        private AccountsDbContext db = new AccountsDbContext();

        // GET: api/VendorContacts
        public IQueryable<VendorContacts> GetVendorContacts()
        {
            return db.VendorContacts;
        }

        // GET: api/VendorContacts/5
        [ResponseType(typeof(VendorContacts))]
        public IHttpActionResult GetVendorContacts(int id)
        {
            VendorContacts vendorContacts = db.VendorContacts.Find(id);
            if (vendorContacts == null)
            {
                return NotFound();
            }

            return Ok(vendorContacts);
        }

        // PUT: api/VendorContacts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVendorContacts(int id, VendorContacts vendorContacts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vendorContacts.Id)
            {
                return BadRequest();
            }

            db.Entry(vendorContacts).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendorContactsExists(id))
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

        // POST: api/VendorContacts
        [ResponseType(typeof(VendorContacts))]
        public IHttpActionResult PostVendorContacts(VendorContacts vendorContacts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VendorContacts.Add(vendorContacts);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vendorContacts.Id }, vendorContacts);
        }

        // DELETE: api/VendorContacts/5
        [ResponseType(typeof(VendorContacts))]
        public IHttpActionResult DeleteVendorContacts(int id)
        {
            VendorContacts vendorContacts = db.VendorContacts.Find(id);
            if (vendorContacts == null)
            {
                return NotFound();
            }

            db.VendorContacts.Remove(vendorContacts);
            db.SaveChanges();

            return Ok(vendorContacts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VendorContactsExists(int id)
        {
            return db.VendorContacts.Count(e => e.Id == id) > 0;
        }
    }
}