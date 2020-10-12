namespace AICloud.Accounts.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_identity_to_apinvoice_accountdetails : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.AccountDetails");
            AlterColumn("dbo.AccountDetails", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.AccountDetails", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.AccountDetails");
            AlterColumn("dbo.AccountDetails", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.AccountDetails", "Id");
        }
    }
}
