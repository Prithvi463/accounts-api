using AICloud.Accounts.Api.CustomModels.APInvoices;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
       public List<ApInvoicesList>  GetApInvoices()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var query = $"select api.*,v.CompanyName as Vendor_CompanyName,gl.AccountName as GeneralLedger_Name from apinvoices api join vendors v on api.Vendor_Id = v.Id join GeneralLedgers gl on api.GeneralLedger_Id = gl.Id";
                var result = conn.Query<ApInvoicesList>(query);

                return result.ToList();
            }
        }
       
    }
}