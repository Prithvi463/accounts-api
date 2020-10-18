using AICloud.Accounts.Api.CustomModels.APChecks;
using AICloud.Accounts.Api.Services.APChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AICloud.Accounts.Api.Controllers
{
    public class APChecksApiController : ApiController
    {
        public APChecksApiController()
        {

        }

        [HttpPost]
        public IHttpActionResult PostApCheck(ApChecksPostModel data)
        {
            var apChecksService = new ApChecksService();
            apChecksService.ProcessApChecks(data);
            return Ok();
        }
    }
}
