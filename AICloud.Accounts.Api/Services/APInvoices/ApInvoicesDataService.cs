using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AICloud.Accounts.Api.Services.APInvoices
{
    public class ApInvoicesDataService
    {
          private readonly string _connectionString;
        public ApInvoicesDataService() 
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MS_AccountsConnectionString"].ConnectionString;
        }
      
       
    }
}