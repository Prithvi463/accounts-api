namespace AICloud.Accounts.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_id_as_guid_in_accountdetails : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.AccountDetails");
            AddColumn("dbo.AccountDetails", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.AccountDetails", "UpdatedAt", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.AccountDetails", "Deleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.AccountDetails", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AccountDetails", "CreatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddPrimaryKey("dbo.AccountDetails", "Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AccountDetails", new[] { "CreatedAt" });
            DropPrimaryKey("dbo.AccountDetails");
            AlterColumn("dbo.AccountDetails", "CreatedAt", c => c.DateTime(nullable: false));
            DropColumn("dbo.AccountDetails", "Deleted");
            DropColumn("dbo.AccountDetails", "UpdatedAt");
            DropColumn("dbo.AccountDetails", "Version");
            AddPrimaryKey("dbo.AccountDetails", "Id");
        }
    }
}
