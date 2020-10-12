namespace AICloud.Accounts.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_account_details : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountDetails",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        AccountCode = c.String(),
                        AccountType = c.String(),
                        AccountName = c.String(),
                        ReferenceType = c.String(),
                        ReferenceId = c.String(),
                        Credit = c.Double(nullable: false),
                        Debit = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UniqueId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AccountDetails");
        }
    }
}
