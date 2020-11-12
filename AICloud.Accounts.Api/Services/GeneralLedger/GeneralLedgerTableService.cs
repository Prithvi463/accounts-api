using AICloud.Accounts.Api.CustomModels.GeneralLedger;
using AICloud.Accounts.Api.Enums.GeneralLedger;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;

namespace AICloud.Accounts.Api.Services.GeneralLedger
{
    public class GeneralLedgerTableService
    {
        private string  _apiLink;
        public GeneralLedgerTableService()
        {
              _apiLink = ConfigurationManager.AppSettings.Get("AccountApiUrl");
        }
        public void CreateGLEntry(GeneralLedgerModel _glRecord)
        {
            var _apiClient = new RestClient(_apiLink);

			var request = new RestRequest();
			request.Resource = $"api/GeneralLedgers";
			request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
			request.AddParameter("application/json", JsonConvert.SerializeObject(_glRecord), ParameterType.RequestBody);
			var mobileApiResponse = _apiClient.Execute(request);
            request.Method = Method.POST;
			var apiResponse = _apiClient.Execute(request);
			if (apiResponse.StatusCode != HttpStatusCode.Created)
				throw new Exception("Error Fetching Customer");

        }
        
    }
}