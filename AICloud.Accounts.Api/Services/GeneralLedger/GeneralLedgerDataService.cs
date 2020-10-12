using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper.Contrib.Extensions;
using AICloud.Accounts.Api.CustomModels.GeneralLedger;

namespace AICloud.Accounts.Api.Services.GeneralLedger
{
    
    public class GeneralLedgerDataService 
    {
        private readonly string _connectionString;
        public GeneralLedgerDataService() 
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MS_AccountsConnectionString"].ConnectionString;
        }

        public List<GetLedgerWithBanksModel>  GetLedgerWithBanks()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var query = "select *,bd.ChequeStartingNumber as CheckStaringNumber,bd.Name as BankName from GeneralLedgers gl join BankDetails bd on gl.Bank_Id =bd.Id";
                var result = conn.Query<GetLedgerWithBanksModel>(query);
			    return result.ToList();
            }
        }

         public GeneralLedgerModel  GetLatestLedgerEntry(string bank_Id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var query = $"select * from GeneralLedgers where Bank_Id= {bank_Id}";
                var result = conn.Query<GeneralLedgerModel>(query);
			    return result.OrderByDescending(d=> d.Id).FirstOrDefault();
            }
        }
    }

    
}