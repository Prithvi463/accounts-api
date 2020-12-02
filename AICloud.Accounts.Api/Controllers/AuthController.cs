using AICloud.Accounts.Api.Models.Security;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AICloud.Accounts.Api.Controllers
{
    public class AuthController : ApiController
    {
         [Route("auth/validate")]
        public IHttpActionResult Post([FromUri] string access_token)
        {  
            var identityUrl = ConfigurationManager.AppSettings.Get("IdentityUrl");
            var client = new RestClient($"{identityUrl}api/auth/authenticate");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {access_token}");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
               return Content(HttpStatusCode.Unauthorized, response.Content);
            var data = JsonConvert.DeserializeObject<Claims>(response.Content);

            
            return Ok(data);
        }
    }
}
