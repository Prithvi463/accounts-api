﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AICloud.Accounts.Api.CustomModels.APInvoices
{
    public class ApInvoiceModel
    {
        public int Id { get; set; }
		public string InvoiceNumber { get; set; }
		public DateTime InvoiceDate { get; set; }
		public DateTime DueDate { get; set; }
		public decimal InvoiceAmount { get; set; }
		public int GeneralLedger_Id { get; set; }
		public int Vendor_Id { get; set; }
    }
}