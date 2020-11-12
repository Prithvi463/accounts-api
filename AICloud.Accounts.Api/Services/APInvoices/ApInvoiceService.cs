using AICloud.Accounts.Api.CustomModels.APInvoices;
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

namespace AICloud.Accounts.Api.Services.APInvoices
{
    public class ApInvoiceService
    {
        private string  _apiLink;
        public ApInvoiceService()
        {
             _apiLink = ConfigurationManager.AppSettings.Get("AccountApiUrl");
        }
          public ApInvoiceModel CreateApInvoice(ApInvoiceModel apInvoice)
        {
            var _apiClient = new RestClient(_apiLink);

			var request = new RestRequest();
			request.Resource = $"api/ApInvoices";
			request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
			request.AddParameter("application/json", JsonConvert.SerializeObject(apInvoice), ParameterType.RequestBody);
            request.Method = Method.POST;
			var apiResponse = _apiClient.Execute(request);
			if (apiResponse.StatusCode != HttpStatusCode.Created)
				throw new Exception("Error occured");
            var invoice = JsonConvert.DeserializeObject<ApInvoiceModel>(apiResponse.Content);
			return invoice;

        }

        public void processApInvoicing(PostApInvoiceModel data)
        {
            var postModel = new ApInvoiceModel();
            postModel.DueDate = data.DueDate;
            postModel.GeneralLedger_Id = data.GeneralLedger_Id;
            postModel.InvoiceAmount = data.InvoiceAmount;
            postModel.InvoiceDate = data.InvoiceDate;
            postModel.InvoiceNumber = data.InvoiceNumber;
            postModel.Vendor_Id = data.vendor_Id;
            var invoice = CreateApInvoice(postModel);

            //Get AP Account
             var generalLedgerSvc = new GeneralLedgerService();
            var gl = generalLedgerSvc.GetAPGeneralLedger();

            var accountDetailsSvc = new AccountDetailsService();

            accountDetailsSvc.ProcessAccounting(2,Convert.ToDouble(invoice.InvoiceAmount),invoice.Id,"ApInvoice",Convert.ToInt32(invoice.GeneralLedger_Id));
        
            var accountDetailsSvc1 = new AccountDetailsService();
             accountDetailsSvc1.ProcessAccounting(1,Convert.ToDouble(invoice.InvoiceAmount),invoice.Id,"ApInvoice",gl.Id);
        
        }

           public List<ApInvoicesList> GetApInvoices()
        {
            var apInvoicesDataSvc = new ApInvoicesDataService();
            return apInvoicesDataSvc.GetApInvoices();
        }
    }
}