using AICloud.Accounts.Api.Models.Security;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace AICloud.Accounts.Api.Attributes
{
     public class AuthorizeUser : AuthorizationFilterAttribute  
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var authToken = actionContext.Request.Headers.Authorization;
           if(authToken != null) 
            { 
                var identityUrl = ConfigurationManager.AppSettings.Get("IdentityUrl");
                var client = new RestClient($"{identityUrl}api/auth/authenticate");
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", $"{authToken}");
                IRestResponse response = client.Execute(request);
                if (response.StatusCode != HttpStatusCode.OK)
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                var data = JsonConvert.DeserializeObject<Claims>(response.Content);
            } else
            {
                   actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            base.OnAuthorization(actionContext);
        }
    } 
}