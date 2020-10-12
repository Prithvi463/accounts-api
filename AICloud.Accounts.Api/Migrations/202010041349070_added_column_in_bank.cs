namespace AICloud.Accounts.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_column_in_bank : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BankDetails", "RunningBalance", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BankDetails", "RunningBalance");
        }
    }
}
