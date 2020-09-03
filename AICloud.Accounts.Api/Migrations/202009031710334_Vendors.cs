namespace AICloud.Accounts.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Vendors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MobileNo = c.String(),
                        Email = c.String(),
                        WorkPhone = c.String(),
                        HouseNo = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        County = c.String(),
                        Country = c.String(),
                        PinCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vendors");
        }
    }
}
