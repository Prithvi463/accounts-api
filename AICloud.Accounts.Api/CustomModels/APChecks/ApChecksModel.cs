using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AICloud.Accounts.Api.CustomModels.APChecks
{
    public class ApChecksModel
    {
        public int Id { get; set; }
		public string ChequeNumber { get; set; }
		public DateTime ChequeDate { get; set; }
		public double ChequeAmount { get; set; }
		public double RemainingAmount { get; set; }
		public double ExchangeRate { get; set; }
		public string Description { get; set; }
		public int Vendor_Id { get; set; }
		public int BankGeneralLedger_Id { get; set; }
    }
}