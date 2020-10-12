using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AICloud.Accounts.Api.Models
{
   	public class APInvoice
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string InvoiceNumber { get; set; }
		public DateTime InvoiceDate { get; set; }
		public DateTime DueDate { get; set; }
		public decimal InvoiceAmount { get; set; }
		public int GeneralLedger_Id { get; set; }
		public int Vendor_Id { get; set; }
	}
}