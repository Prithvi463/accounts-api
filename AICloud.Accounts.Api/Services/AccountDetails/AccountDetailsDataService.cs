using AICloud.Accounts.Api.CustomModels.AccountDetails;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AICloud.Accounts.Api.Services.AccountDetails
{
    public class AccountDetailsDataService
    {
         private readonly string _connectionString;
        public AccountDetailsDataService() 
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MS_AccountsConnectionString"].ConnectionString;
        }

           public void  SaveAccountDetails(AccountDetailsModel data)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var query = $"Insert into AccountDetails(Id,AccountCode,AccountType,AccountName,ReferenceType,ReferenceId,Credit,Debit,Date,GeneralLedger_Id,CreatedAt) values(" +
                    $"'{Guid.NewGuid()}','{data.AccountCode}','{data.AccountType}','{data.AccountName}','{data.ReferenceType}',{data.ReferenceId},{data.Credit},{data.Debit}," +
                    $"'{data.Date.ToString("yyyy-MM-dd 00:00:00.000")}',{data.GeneralLedger_Id},'{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}')";
                var result = conn.Query<AccountDetailsModel>(query);
            }
        }
    }
}