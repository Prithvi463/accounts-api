﻿namespace AICloud.Accounts.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ARInvoice : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.APChecks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChequeNumber = c.String(),
                        ChequeDate = c.DateTime(nullable: false),
                        ChequeAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RemainingAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ExchangeRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.APInvoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceNumber = c.String(),
                        InvoiceDate = c.DateTime(nullable: false),
                        PaymentType = c.Int(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        InvoiceAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RetainingAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RetainingReleased = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalTaxes = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ARChecks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepositDate = c.DateTime(nullable: false),
                        ReceivedDate = c.DateTime(nullable: false),
                        ChequeDate = c.DateTime(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                        Job_Id = c.Int(nullable: false),
                        ChequeNumber = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RemainingAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comment = c.String(),
                        CashAccount = c.String(),
                        InvoiceRelated = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ARInvoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepositDate = c.DateTime(nullable: false),
                        ReceivedDate = c.DateTime(nullable: false),
                        CheckDate = c.DateTime(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                        ChequeNumber = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RemainingAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CashAccount = c.String(),
                        Comment = c.String(),
                        InvoiceRelated = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
          
        }
        
        public override void Down()
        {          
            DropTable("dbo.ARInvoices");
            DropTable("dbo.ARChecks");
            DropTable("dbo.APInvoices");
            DropTable("dbo.APChecks");
        }
    }
}
