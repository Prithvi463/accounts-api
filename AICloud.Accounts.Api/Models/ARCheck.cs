using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AICloud.Accounts.Api.Models
{
	public class ARCheck
	{
		public int Id { get; set; }
		public DateTime DepositDate { get; set; }
		public DateTime ReceivedDate { get; set; }
		public DateTime ChequeDate { get; set; }
		public int Customer_Id { get; set; }
		public int Job_Id { get; set; }
		public string ChequeNumber { get; set; }
		public decimal Amount { get; set; }
		public decimal RemainingAmount { get; set; }
		public string Comment { get; set; }
		public string CashAccount { get; set; }
		public string InvoiceRelated { get; set; }
	}
}