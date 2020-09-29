using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AICloud.Accounts.Api.Models
{
	public class BankDetails
	{
		public int Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string ShortName { get; set; }
		public string RoutingCode { get; set; }
		public string AccountNumber { get; set; }
		public string ChequeStartingNumber { get; set; }
		public string RunningChequeNumber { get; set; }
	}
}