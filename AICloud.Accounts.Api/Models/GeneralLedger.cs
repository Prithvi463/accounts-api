using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AICloud.Accounts.Api.Models
{
	public class GeneralLedger
	{
		public int Id { get; set; }

		[ForeignKey("BankDetails")] public int Bank_Id { get; set; }
		public BankDetails BankDetails { get; set; }
		public string AccountType { get; set; }
		public string AccountCode { get; set; }
		public string SequenceNumber { get; set; }
		public DateTime PostDate { get; set; }
		public string CreditAmount { get; set; }
		public string DebitAmount { get; set; }
		public string Balance { get; set; }

	}
}