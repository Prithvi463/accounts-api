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
    public class BankDetailsController : ApiController
    {
        private AccountsDbContext db = new AccountsDbContext();

        // GET: api/BankDetails
        public IQueryable<BankDetails> GetBankDetails()
        {
            return db.BankDetails;
        }

        // GET: api/BankDetails/5
        [ResponseType(typeof(BankDetails))]
        public IHttpActionResult GetBankDetails(int id)
        {
            BankDetails bankDetails = db.BankDetails.Find(id);
            if (bankDetails == null)
            {
                return NotFound();
            }

            return Ok(bankDetails);
        }

        // PUT: api/BankDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBankDetails(int id, BankDetails bankDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bankDetails.Id)
            {
                return BadRequest();
            }

            db.Entry(bankDetails).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankDetailsExists(id))
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

        // POST: api/BankDetails
        [ResponseType(typeof(BankDetails))]
        public IHttpActionResult PostBankDetails(BankDetails bankDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BankDetails.Add(bankDetails);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bankDetails.Id }, bankDetails);
        }

        // DELETE: api/BankDetails/5
        [ResponseType(typeof(BankDetails))]
        public IHttpActionResult DeleteBankDetails(int id)
        {
            BankDetails bankDetails = db.BankDetails.Find(id);
            if (bankDetails == null)
            {
                return NotFound();
            }

            db.BankDetails.Remove(bankDetails);
            db.SaveChanges();

            return Ok(bankDetails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BankDetailsExists(int id)
        {
            return db.BankDetails.Count(e => e.Id == id) > 0;
        }
    }
}