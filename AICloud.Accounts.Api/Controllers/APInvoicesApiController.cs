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
    public class APInvoicesApiController : ApiController
    {
        public APInvoicesApiController()
        {

        }

        [HttpGet]
        public IHttpActionResult GetLedgerWithBanks()
        {
            var generalLedgerService = new GeneralLedgerService();
            return Ok(generalLedgerService.GetLedgerWithBanks());
        }

         [HttpPost]
        public IHttpActionResult PostInvoice(PostApInvoiceModel data)
        {
            var invSvc = new ApInvoiceService();
            invSvc.processApInvoicing(data);
            return Ok();
        }
         [HttpGet]
         [Route("api/APInvoicesApi/GetApInvoice")]
        public IHttpActionResult GetApInvoice()
        {
            var invSvc = new ApInvoiceService();
               return Ok(invSvc.GetApInvoices());
        }
    }
}
