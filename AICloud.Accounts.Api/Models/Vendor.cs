using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AICloud.Accounts.Api.Models
{
    public class Vendor
	{
		public int Id { get; set; }
		public string VendorId { get; set; }
		public string CompanyName { get; set; }
		public string MobileNo { get; set; }
		public string Email { get; set; }
		public string WorkPhone { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Country { get; set; }
		public string ZipCode { get; set; }

	}
}