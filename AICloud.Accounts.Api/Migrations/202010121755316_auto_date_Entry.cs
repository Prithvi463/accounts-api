namespace AICloud.Accounts.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class auto_date_Entry : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AccountDetails", "CreatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AccountDetails", "CreatedAt", c => c.Int(nullable: false));
        }
    }
}
