namespace AICloud.Accounts.Api.Migrations
{
    using Microsoft.Azure.Mobile.Server.Tables;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AICloud.Accounts.Api.Context.AccountsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
           SetSqlGenerator("System.Data.SqlClient", new EntityTableSqlGenerator());
        }

        protected override void Seed(AICloud.Accounts.Api.Context.AccountsDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
