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
    public class GeneralLedgerService
    {
        private readonly string _apiLink;
        public GeneralLedgerService()
        {
          _apiLink = "https://localhost:44301/";
        }

        public void CreateLedgerEntry(string bank_Id,int accountType,string accountCode,string sequenceNo,double amount)
        {
            //var ledger = new GeneralLedgerModel();
            //ledger.Bank_Id = Convert.ToInt32(bank_Id);
            //ledger.AccountCode = accountCode;
            //ledger.PostDate = DateTime.Today;
            //var generalLedgerDataService = new GeneralLedgerDataService();
            //var latestEntry = generalLedgerDataService.GetLatestLedgerEntry(bank_Id);
            //double previousAmount = 0.0;
            //if (latestEntry != null)
            //    previousAmount = Convert.ToDouble(latestEntry.Balance);
            ////get previous balace and add credit/debit entries
            //switch (accountType)
            //{
            //    case (int)LedgerTypes.OpeningBalance:
            //        ledger.AccountType = "OpeningBalance";
            //        ledger.AccountCode = "A";
            //        ledger.SequenceNumber = string.Empty;
            //        ledger.CreditAmount = amount.ToString();
            //        ledger.DebitAmount = "0";
            //        ledger.Balance = amount.ToString();
            //        break;
            //    case (int)LedgerTypes.Asserts:
            //         ledger.AccountType = "Asset";
            //        ledger.AccountCode = "A";
            //         ledger.SequenceNumber = sequenceNo;
            //         ledger.CreditAmount = amount.ToString();
            //          ledger.DebitAmount = "0";
            //         ledger.Balance = (previousAmount + amount).ToString();
            //        break;
            //         case (int)LedgerTypes.Laibilities:
            //         ledger.AccountType = "Laibility";
            //         ledger.AccountCode = "L";
            //         ledger.SequenceNumber = sequenceNo;
            //         ledger.CreditAmount = "0";
            //         ledger.DebitAmount = amount.ToString();
            //         ledger.Balance = (previousAmount - amount).ToString();
            //        break;
            //}

            //var glTableService = new GeneralLedgerTableService();

            //glTableService.CreateGLEntry(ledger);
        }

        public List<GetLedgerWithBanksModel> GetLedgerWithBanks()
        {
            var generalLedgerDataService = new GeneralLedgerDataService();
            var result = generalLedgerDataService.GetLedgerWithBanks();
            return result;
        }

        public GeneralLedgerModel GetGeneralLedgerById(int id)
        {
            var _apiClient = new RestClient(_apiLink);
           var request = new RestRequest();
			request.Resource = "/api/generalledgers";
			request.AddQueryParameter("$filter", $"Id eq {id}");
			request.Method = Method.GET;
			var mobileApiResponse = _apiClient.Execute(request);
			if (mobileApiResponse.StatusCode != HttpStatusCode.OK)
				throw new Exception("Error from FinFlo Mobile API");
			var gl = JsonConvert.DeserializeObject<List<GeneralLedgerModel>>(mobileApiResponse.Content);
			return gl.Where(s=> $"{s.Id}" == $"{id}").FirstOrDefault();
        }

         public GeneralLedgerModel GetAPGeneralLedger()
        {
            var _apiClient = new RestClient(_apiLink);
           var request = new RestRequest();
			request.Resource = "/api/generalledgers";
			request.Method = Method.GET;
			var mobileApiResponse = _apiClient.Execute(request);
			if (mobileApiResponse.StatusCode != HttpStatusCode.OK)
				throw new Exception("Error from FinFlo Mobile API");
			var gl = JsonConvert.DeserializeObject<List<GeneralLedgerModel>>(mobileApiResponse.Content);
			return gl.Where(d=>d.AccountName=="AP").FirstOrDefault();
        }


    }
}