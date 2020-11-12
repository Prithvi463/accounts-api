using AICloud.Accounts.Api.CustomModels.APChecks;
using AICloud.Accounts.Api.Services.AccountDetails;
using AICloud.Accounts.Api.Services.GeneralLedger;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;

namespace AICloud.Accounts.Api.Services.APChecks
{
    public class ApChecksService
    {
        
        private string  _apiLink;
        public ApChecksService()
        {
            
             _apiLink = ConfigurationManager.AppSettings.Get("AccountApiUrl");
        }

         public ApChecksModel CreateApCheck(ApChecksModel apInvoice)
        {
            var _apiClient = new RestClient(_apiLink);

			var request = new RestRequest();
			request.Resource = $"api/ApChecks";
			request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
			request.AddParameter("application/json", JsonConvert.SerializeObject(apInvoice), ParameterType.RequestBody);
            request.Method = Method.POST;
			var apiResponse = _apiClient.Execute(request);
			if (apiResponse.StatusCode != HttpStatusCode.Created)
				throw new Exception("Error occured");
            var invoice = JsonConvert.DeserializeObject<ApChecksModel>(apiResponse.Content);
			return invoice;

        }

        public void ProcessApChecks(ApChecksPostModel apCheckModel)
        {
             var postModel = new ApChecksModel();
            postModel.BankGeneralLedger_Id = apCheckModel.GeneralLedger_Id;
            postModel.ChequeAmount = apCheckModel.CheckAmount;
            postModel.ChequeDate = apCheckModel.CheckDate;
            postModel.ChequeNumber = apCheckModel.checkNumber;
            postModel.Description = apCheckModel.Description;
            postModel.Vendor_Id = apCheckModel.Vendor_Id;
            postModel.RemainingAmount = apCheckModel.RemainingAmount;
            postModel.ExchangeRate = 0;
            var check = CreateApCheck(postModel);

            //Get AP Account
            var generalLedgerSvc = new GeneralLedgerService();
            var accountPayable = generalLedgerSvc.GetAPGeneralLedger();

            var accountDetailsSvc = new AccountDetailsService();

            accountDetailsSvc.ProcessAccounting(2,check.ChequeAmount,check.Id,"ApCheck",accountPayable.Id);
        
            accountDetailsSvc.ProcessAccounting(1,check.ChequeAmount,check.Id,"ApCheck",check.BankGeneralLedger_Id);


        }
    }
}