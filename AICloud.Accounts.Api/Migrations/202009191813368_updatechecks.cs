namespace AICloud.Accounts.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatechecks : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ARChecks", "InvoiceRelated", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ARChecks", "InvoiceRelated", c => c.Boolean(nullable: false));
        }
    }
}
