using AICloud.Accounts.Api.Attributes;
using AICloud.Accounts.Api.CustomModels.APInvoices;
using AICloud.Accounts.Api.CustomModels.GeneralLedger;
using AICloud.Accounts.Api.Services.APInvoices;
using AICloud.Accounts.Api.Services.GeneralLedger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AICloud.Accounts.Api.Controllers
{    
    [AuthorizeUser]
    public class APInvoicesApiController : ApiController
    {
        public APInvoicesApiController()
        {

        }

        [HttpGet]
        public IHttpActionResult GetLedgerWithBanks()
        {
             var token = Request.Headers.Authorization;
            if (token == null)
                return Unauthorized();
            var generalLedgerService = new GeneralLedgerService(token.ToString());
            return Ok(generalLedgerService.GetLedgerWithBanks());
        }

         [HttpPost]
        public IHttpActionResult PostInvoice(PostApInvoiceModel data)
        {
             var token = Request.Headers.Authorization;
            if (token == null)
                return Unauthorized();
            var invSvc = new ApInvoiceService(token.ToString());
            invSvc.processApInvoicing(data);
            return Ok();
        }
         [HttpGet]
         [Route("api/APInvoicesApi/GetApInvoice")]
        public IHttpActionResult GetApInvoice()
        {
            var token = Request.Headers.Authorization;
            if (token == null)
                return Unauthorized();
            var invSvc = new ApInvoiceService(token.ToString());
               return Ok(invSvc.GetApInvoices());
        }
    }
}
