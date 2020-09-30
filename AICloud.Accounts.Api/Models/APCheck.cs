using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AICloud.Accounts.Api.Models
{
    public class APCheck
	{
		public int Id { get; set; }
		public string ChequeNumber { get; set; }
		public DateTime ChequeDate { get; set; }
		public decimal ChequeAmount { get; set; }
		public decimal RemainingAmount { get; set; }
		public decimal ExchangeRate { get; set; }
		public string Description { get; set; }
	}
}