using System;
using System.ComponentModel.DataAnnotations;

namespace AICloud.Accounts.Api.Models
{
	public class APInvoice
	{
		[Key]
		public int Id { get; set; }
		public string InvoiceNumber { get; set; }
		public DateTime InvoiceDate { get; set; }
		public int PaymentType { get; set; }
		public DateTime DueDate { get; set; }
		public decimal InvoiceAmount { get; set; }
		public decimal RetainingAmount { get; set; }
		public decimal DiscountAmount { get; set; }
		public decimal RetainingReleased { get; set; }
		public decimal TotalTaxes { get; set; }
		public decimal NetAmount { get; set; }
		public string Description { get; set; }
	}
}