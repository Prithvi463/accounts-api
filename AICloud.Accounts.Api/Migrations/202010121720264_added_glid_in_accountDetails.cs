namespace AICloud.Accounts.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_glid_in_accountDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountDetails", "GeneralLedger_Id", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AccountDetails", "GeneralLedger_Id");
        }
    }
}
