namespace AICloud.Accounts.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db_changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.APInvoices", "GeneralLedger_Id", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.APInvoices", "GeneralLedger_Id");
        }
    }
}
