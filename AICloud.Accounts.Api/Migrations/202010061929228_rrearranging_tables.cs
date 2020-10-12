namespace AICloud.Accounts.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rrearranging_tables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BankDetails", "OpeningBalance", c => c.Double(nullable: false));
            AddColumn("dbo.GeneralLedgers", "AccountName", c => c.String());
            AddColumn("dbo.GeneralLedgers", "StartSequenceNumber", c => c.String());
            AddColumn("dbo.GeneralLedgers", "EndSequenceNumber", c => c.String());
            AddColumn("dbo.GeneralLedgers", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.BankDetails", "RunningBalance");
            DropColumn("dbo.GeneralLedgers", "SequenceNumber");
            DropColumn("dbo.GeneralLedgers", "PostDate");
            DropColumn("dbo.GeneralLedgers", "CreditAmount");
            DropColumn("dbo.GeneralLedgers", "DebitAmount");
            DropColumn("dbo.GeneralLedgers", "Balance");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GeneralLedgers", "Balance", c => c.String());
            AddColumn("dbo.GeneralLedgers", "DebitAmount", c => c.String());
            AddColumn("dbo.GeneralLedgers", "CreditAmount", c => c.String());
            AddColumn("dbo.GeneralLedgers", "PostDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.GeneralLedgers", "SequenceNumber", c => c.String());
            AddColumn("dbo.BankDetails", "RunningBalance", c => c.Double(nullable: false));
            DropColumn("dbo.GeneralLedgers", "Date");
            DropColumn("dbo.GeneralLedgers", "EndSequenceNumber");
            DropColumn("dbo.GeneralLedgers", "StartSequenceNumber");
            DropColumn("dbo.GeneralLedgers", "AccountName");
            DropColumn("dbo.BankDetails", "OpeningBalance");
        }
    }
}
