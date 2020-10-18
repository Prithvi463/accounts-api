namespace AICloud.Accounts.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes_in_apchecks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.APChecks", "Vendor_Id", c => c.Int(nullable: false));
            AddColumn("dbo.APChecks", "BankGeneralLedger_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.APChecks", "ChequeAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.APChecks", "RemainingAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.APChecks", "ExchangeRate", c => c.Double(nullable: false));
            DropColumn("dbo.APChecks", "Bank_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.APChecks", "Bank_Id", c => c.String());
            AlterColumn("dbo.APChecks", "ExchangeRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.APChecks", "RemainingAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.APChecks", "ChequeAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.APChecks", "BankGeneralLedger_Id");
            DropColumn("dbo.APChecks", "Vendor_Id");
        }
    }
}
