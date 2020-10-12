using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AICloud.Accounts.Api.CustomModels.AccountDetails
{
    public class AccountDetailsModel
    {
        public string Id { get; set; }
        public string AccountCode { get; set; }
        public string AccountType { get; set; }
        public string AccountName { get; set; }
        public string ReferenceType { get; set; }
        public int ReferenceId { get; set; }
        public double Credit{ get; set; }
        public double Debit { get; set; }
        public int GeneralLedger_Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; }
        
    }
}