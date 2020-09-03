using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AICloud.Accounts.Api.Context
{
	public class AccountsDbContext : DbContext
	{
		
				private const string connectionStringName = "MS_AccountsConnectionString";
		public AccountsDbContext() : base(connectionStringName)
		{
			Database.CreateIfNotExists();
			var config = new AICloud.Accounts.Api.Migrations.Configuration();
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<AccountsDbContext, AICloud.Accounts.Api.Migrations.Configuration>(true, config));
		}

		public System.Data.Entity.DbSet<AICloud.Accounts.Api.Models.Vendor> Vendors { get; set; }
	}
}