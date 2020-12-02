using AICloud.Accounts.Api.Attributes;
using AICloud.Accounts.Api.Context;
using AICloud.Accounts.Api.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace AICloud.Accounts.Api.Controllers
{
     [AuthorizeUser]
    public class AccountDetailsController : ApiController
    {
         private AccountsDbContext db = new AccountsDbContext();

        // GET: api/accountDetails
        public IQueryable<AccountDetails> GetaccountDetails()
        {
            return db.AccountDetails.OrderByDescending(s=>s.CreatedAt);
        }

        // GET: api/accountDetails/5
        [ResponseType(typeof(AccountDetails))]
        public IHttpActionResult GetaccountDetails(string id)
        {
            AccountDetails accountDetails = db.AccountDetails.Find(id);
            if (accountDetails == null)
            {
                return NotFound();
            }

            return Ok(accountDetails);
        }

        // PUT: api/accountDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutaccountDetails(string id, AccountDetails accountDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountDetails.Id)
            {
                return BadRequest();
            }

            db.Entry(accountDetails).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!accountDetailsExists(id))
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

        // POST: api/accountDetails
        [ResponseType(typeof(AccountDetails))]
        public IHttpActionResult PostaccountDetails(AccountDetails accountDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AccountDetails.Add(accountDetails);
            db.SaveChanges();
            var response = CreatedAtRoute("DefaultApi", new { id = accountDetails.Id }, accountDetails);
            //var glsvc = new GeneralLedgerService();
            //glsvc.CreateLedgerEntry(accountDetails.Id.ToString(),(int)LedgerTypes.OpeningBalance,accountDetails.Code,"",accountDetails.OpeningBalance);
            return response;
        }

        // DELETE: api/accountDetails/5
        [ResponseType(typeof(AccountDetails))]
        public IHttpActionResult DeleteaccountDetails(int id)
        {
            AccountDetails accountDetails = db.AccountDetails.Find(id);
            if (accountDetails == null)
            {
                return NotFound();
            }

            db.AccountDetails.Remove(accountDetails);
            db.SaveChanges();

            return Ok(accountDetails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool accountDetailsExists(string id)
        {
            return db.AccountDetails.Count(e => e.Id == id) > 0;
        }
    }
}
