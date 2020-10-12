using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AICloud.Accounts.Api.CustomModels.GeneralLedger
{
    public class GeneralLedgerModel
    {
        public int Id { get; set; }
		public int Bank_Id { get; set; }
		public string AccountName { get; set; }
		public string AccountType { get; set; }
		public string AccountCode { get; set; }
		public string StartSequenceNumber { get; set; }
		public string EndSequenceNumber { get; set; }
		public DateTime Date { get; set; }
    }
}