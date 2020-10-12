using Microsoft.Azure.Mobile.Server;
using System;

namespace AICloud.Accounts.Api.Models
{
    public class AccountDetails : EntityData
    {
        public string AccountCode { get; set; }
        public string AccountType { get; set; }
        public string AccountName { get; set; }
        public string ReferenceType { get; set; }
        public int ReferenceId { get; set; }
        public double Credit{ get; set; }
        public double Debit { get; set; }
        public int GeneralLedger_Id { get; set; }
        public DateTime Date { get; set; }

    }
}