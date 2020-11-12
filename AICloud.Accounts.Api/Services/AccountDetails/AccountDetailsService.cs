using AICloud.Accounts.Api.CustomModels.AccountDetails;
using AICloud.Accounts.Api.Services.GeneralLedger;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;

namespace AICloud.Accounts.Api.Services.AccountDetails
{
    public class AccountDetailsService
    {
        private string  _apiLink;
        public AccountDetailsService()
        {
             _apiLink = ConfigurationManager.AppSettings.Get("AccountApiUrl");
        }
        public AccountDetailsModel CreateAccountEntry(AccountDetailsModel apInvoice)
        {
            var _apiClient = new RestClient(_apiLink);

			var request = new RestRequest();
			request.Resource = $"api/AccountDetails";
			request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
			request.AddParameter("application/json", JsonConvert.SerializeObject(apInvoice), ParameterType.RequestBody);
            request.Method = Method.POST;
			var apiResponse = _apiClient.Execute(request);
			if (apiResponse.StatusCode != HttpStatusCode.Created)
				throw new Exception("Error occured");
            var accountDetails = JsonConvert.DeserializeObject<AccountDetailsModel>(apiResponse.Content);
			return accountDetails;

        }

        public void ProcessAccounting(int entryType,double amount,int referenceId,string referenceType,int glId)
        {
            var generalLedgerSvc = new GeneralLedgerService();
            var gl = generalLedgerSvc.GetGeneralLedgerById(glId);
            var accountEntry = new AccountDetailsModel();
            accountEntry.ReferenceId = referenceId;
            accountEntry.ReferenceType = referenceType;
            accountEntry.AccountCode = gl.AccountCode;
            accountEntry.AccountName = gl.AccountName;
            accountEntry.AccountType = gl.AccountType;
            accountEntry.Date = DateTime.Today;
            accountEntry.GeneralLedger_Id = glId;
            if(entryType == 1) //credit
            {
                 accountEntry.Debit = 0;
                 accountEntry.Credit = amount;
            } else if (entryType == 2)//debit
            {
                accountEntry.Debit = amount;
                 accountEntry.Credit = 0;
            }
            accountEntry.CreatedAt = DateTime.Now;
            var accountDetailsDataSvc = new AccountDetailsDataService();
            accountDetailsDataSvc.SaveAccountDetails(accountEntry);
            //CreateAccountEntry(accountEntry);
        }
    }
}