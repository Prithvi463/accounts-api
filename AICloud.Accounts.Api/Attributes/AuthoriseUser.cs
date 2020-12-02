using AICloud.Accounts.Api.Models.Security;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
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
                var client = new RestClient("https://localhost:44327/api/auth/authenticate");
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