using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AICloud.Accounts.Api.CustomModels.GeneralLedger
{
    public class PostLedgerModel
    {
        public string Bank_Id { get;set; }
        public int AccountType { get;set; }

         public string Amount { get;set; }
         public string SequenceNumber { get;set; }
    }
}