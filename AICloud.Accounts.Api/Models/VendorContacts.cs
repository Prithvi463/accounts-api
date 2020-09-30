using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AICloud.Accounts.Api.Models
{
   public class VendorContacts
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		[ForeignKey("Vendor")] public int Vendor_Id { get; set; }
		public Vendor Vendor { get; set; }

	}
}