﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AICloud.Accounts.Api
{
    public static class WebApiConfig
    {
       	public static void Register(HttpConfiguration config)
				{
			// Web API configuration and services
			config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
								name: "DefaultApi",
								routeTemplate: "api/{controller}/{id}",
								defaults: new { id = RouteParameter.Optional }
						);
			config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
						config.Formatters.JsonFormatter.SupportedMediaTypes.Add(
								new System.Net.Http.Headers.MediaTypeHeaderValue("application/json-patch+json"));
				}
    }
}