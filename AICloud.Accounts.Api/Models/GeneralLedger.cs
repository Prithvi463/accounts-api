using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AICloud.Accounts.Api.Models
{
   public class GeneralLedger
	{
		[Key]
		public int Id { get; set; }

		[ForeignKey("BankDetails")] public int Bank_Id { get; set; }
		public BankDetails BankDetails { get; set; }
		public string AccountName { get; set; }
		public string AccountType { get; set; }
		public string AccountCode { get; set; }
		public string StartSequenceNumber { get; set; }
		public string EndSequenceNumber { get; set; }
		public DateTime Date { get; set; }
	}
}