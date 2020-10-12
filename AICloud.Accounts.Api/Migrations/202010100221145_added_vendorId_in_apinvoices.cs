namespace AICloud.Accounts.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_vendorId_in_apinvoices : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.APInvoices", "Vendor_Id", c => c.String());
            DropColumn("dbo.APInvoices", "PaymentType");
            DropColumn("dbo.APInvoices", "RetainingAmount");
            DropColumn("dbo.APInvoices", "DiscountAmount");
            DropColumn("dbo.APInvoices", "RetainingReleased");
            DropColumn("dbo.APInvoices", "TotalTaxes");
            DropColumn("dbo.APInvoices", "NetAmount");
            DropColumn("dbo.APInvoices", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.APInvoices", "Description", c => c.String());
            AddColumn("dbo.APInvoices", "NetAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.APInvoices", "TotalTaxes", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.APInvoices", "RetainingReleased", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.APInvoices", "DiscountAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.APInvoices", "RetainingAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.APInvoices", "PaymentType", c => c.Int(nullable: false));
            DropColumn("dbo.APInvoices", "Vendor_Id");
        }
    }
}
