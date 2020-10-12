namespace AICloud.Accounts.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class auto_incrementforapinvoice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountDetails", "CreatedAt", c => c.Int(nullable: false));
            DropColumn("dbo.AccountDetails", "UniqueId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AccountDetails", "UniqueId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.AccountDetails", "CreatedAt");
        }
    }
}
