namespace AICloud.Accounts.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vendorcontacts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendors", "Name", c => c.String());
            AddColumn("dbo.Vendors", "HouseNo", c => c.String());
            AddColumn("dbo.Vendors", "Street", c => c.String());
            AddColumn("dbo.Vendors", "County", c => c.String());
            AddColumn("dbo.Vendors", "PinCode", c => c.String());
            DropColumn("dbo.Vendors", "VendorId");
            DropColumn("dbo.Vendors", "CompanyName");
            DropColumn("dbo.Vendors", "Address1");
            DropColumn("dbo.Vendors", "Address2");
            DropColumn("dbo.Vendors", "ZipCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vendors", "ZipCode", c => c.String());
            AddColumn("dbo.Vendors", "Address2", c => c.String());
            AddColumn("dbo.Vendors", "Address1", c => c.String());
            AddColumn("dbo.Vendors", "CompanyName", c => c.String());
            AddColumn("dbo.Vendors", "VendorId", c => c.String());
            DropColumn("dbo.Vendors", "PinCode");
            DropColumn("dbo.Vendors", "County");
            DropColumn("dbo.Vendors", "Street");
            DropColumn("dbo.Vendors", "HouseNo");
            DropColumn("dbo.Vendors", "Name");
        }
    }
}
