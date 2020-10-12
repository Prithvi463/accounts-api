using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AICloud.Accounts.Api.Models
{
  public class AccountType :EntityData
	{
		public int Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string StartSequence { get; set; }
		public string EndSequence { get; set; }

	}
}