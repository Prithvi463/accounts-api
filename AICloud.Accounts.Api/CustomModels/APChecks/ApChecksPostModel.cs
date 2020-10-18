using AICloud.Accounts.Api.CustomModels.APInvoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AICloud.Accounts.Api.CustomModels.APChecks
{
    public class ApChecksPostModel
    {
       public int GeneralLedger_Id {get;set;}
      public int Vendor_Id{get;set;}
      public string checkNumber{get;set;}
      public DateTime CheckDate{get;set;}
      public double CheckAmount{get;set;}
      public double RemainingAmount{get;set;}
      public string Description{get;set;}
      public List<ApInvoicesList> ApInvoices {get;set;}
    }
}