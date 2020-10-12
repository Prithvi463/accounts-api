namespace AICloud.Accounts.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changed_Id_datatypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AccountDetails", "ReferenceId", c => c.Int(nullable: false));
            AlterColumn("dbo.AccountDetails", "GeneralLedger_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.APInvoices", "GeneralLedger_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.APInvoices", "Vendor_Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.APInvoices", "Vendor_Id", c => c.String());
            AlterColumn("dbo.APInvoices", "GeneralLedger_Id", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.AccountDetails", "GeneralLedger_Id", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.AccountDetails", "ReferenceId", c => c.String());
        }
    }
}
