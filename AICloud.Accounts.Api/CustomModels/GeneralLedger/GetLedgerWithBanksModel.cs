using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AICloud.Accounts.Api.CustomModels.GeneralLedger
{
    public class GetLedgerWithBanksModel
    {
        public string Bank_Id { get; set; }
         public string BankName { get; set; }
        public string ShortName { get; set; }
         public string RoutingCode { get; set; }
         public string AccountNumber { get; set; }
         public string CheckStartingNumber { get; set; }
         public string RunningBalance { get; set; }
        public string AccountType { get; set; }
         public string SequenceNumber { get; set; }
        public DateTime PostDate { get; set; }
        public string  CreditAmount{ get; set; }
        public string  DebitAmount{ get; set; }
        public string  Balance{ get; set; }

    }
}