namespace InventoryTest_WebForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectMissedNavigationProperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InvoiceItems", "Invoice_Id", "dbo.Invoices");
            DropForeignKey("dbo.InvoiceItems", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.Invoices", "Client_Id", "dbo.Clients");
            DropIndex("dbo.InvoiceItems", new[] { "Invoice_Id" });
            DropIndex("dbo.InvoiceItems", new[] { "Item_Id" });
            DropIndex("dbo.Invoices", new[] { "Client_Id" });
            DropColumn("dbo.InvoiceItems", "InvoiceId_FK");
            DropColumn("dbo.InvoiceItems", "ItemId_FK");
            DropColumn("dbo.Invoices", "ClientId_FK");
            RenameColumn(table: "dbo.InvoiceItems", name: "Invoice_Id", newName: "InvoiceId_FK");
            RenameColumn(table: "dbo.InvoiceItems", name: "Item_Id", newName: "ItemId_FK");
            RenameColumn(table: "dbo.Invoices", name: "Client_Id", newName: "ClientId_FK");
            AlterColumn("dbo.InvoiceItems", "InvoiceId_FK", c => c.Int(nullable: false));
            AlterColumn("dbo.InvoiceItems", "ItemId_FK", c => c.Int(nullable: false));
            AlterColumn("dbo.Invoices", "ClientId_FK", c => c.Int(nullable: false));
            CreateIndex("dbo.InvoiceItems", "InvoiceId_FK");
            CreateIndex("dbo.InvoiceItems", "ItemId_FK");
            CreateIndex("dbo.Invoices", "ClientId_FK");
            AddForeignKey("dbo.InvoiceItems", "InvoiceId_FK", "dbo.Invoices", "Id", cascadeDelete: true);
            AddForeignKey("dbo.InvoiceItems", "ItemId_FK", "dbo.Items", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Invoices", "ClientId_FK", "dbo.Clients", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "ClientId_FK", "dbo.Clients");
            DropForeignKey("dbo.InvoiceItems", "ItemId_FK", "dbo.Items");
            DropForeignKey("dbo.InvoiceItems", "InvoiceId_FK", "dbo.Invoices");
            DropIndex("dbo.Invoices", new[] { "ClientId_FK" });
            DropIndex("dbo.InvoiceItems", new[] { "ItemId_FK" });
            DropIndex("dbo.InvoiceItems", new[] { "InvoiceId_FK" });
            AlterColumn("dbo.Invoices", "ClientId_FK", c => c.Int());
            AlterColumn("dbo.InvoiceItems", "ItemId_FK", c => c.Int());
            AlterColumn("dbo.InvoiceItems", "InvoiceId_FK", c => c.Int());
            RenameColumn(table: "dbo.Invoices", name: "ClientId_FK", newName: "Client_Id");
            RenameColumn(table: "dbo.InvoiceItems", name: "ItemId_FK", newName: "Item_Id");
            RenameColumn(table: "dbo.InvoiceItems", name: "InvoiceId_FK", newName: "Invoice_Id");
            AddColumn("dbo.Invoices", "ClientId_FK", c => c.Int(nullable: false));
            AddColumn("dbo.InvoiceItems", "ItemId_FK", c => c.Int(nullable: false));
            AddColumn("dbo.InvoiceItems", "InvoiceId_FK", c => c.Int(nullable: false));
            CreateIndex("dbo.Invoices", "Client_Id");
            CreateIndex("dbo.InvoiceItems", "Item_Id");
            CreateIndex("dbo.InvoiceItems", "Invoice_Id");
            AddForeignKey("dbo.Invoices", "Client_Id", "dbo.Clients", "Id");
            AddForeignKey("dbo.InvoiceItems", "Item_Id", "dbo.Items", "Id");
            AddForeignKey("dbo.InvoiceItems", "Invoice_Id", "dbo.Invoices", "Id");
        }
    }
}
