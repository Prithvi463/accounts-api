namespace AICloud.Accounts.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_bank_in_Checks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.APChecks", "Bank_Id", c => c.String());
            AddColumn("dbo.ARChecks", "Bank_Id", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ARChecks", "Bank_Id");
            DropColumn("dbo.APChecks", "Bank_Id");
        }
    }
}
