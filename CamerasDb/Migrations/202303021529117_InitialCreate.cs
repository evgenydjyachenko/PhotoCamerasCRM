namespace CamerasDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SureName = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                        Salt = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Managerrs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SureName = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                        Salt = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Productions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Int(nullable: false),
                        Manufacturer_Id = c.Int(),
                        Worker_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturers", t => t.Manufacturer_Id)
                .ForeignKey("dbo.Workers", t => t.Worker_Id)
                .Index(t => t.Manufacturer_Id)
                .Index(t => t.Worker_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModelName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Int(nullable: false),
                        Store_Id = c.Int(),
                        Worker_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stores", t => t.Store_Id)
                .ForeignKey("dbo.Workers", t => t.Worker_Id)
                .Index(t => t.Store_Id)
                .Index(t => t.Worker_Id);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SureName = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                        Salt = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        Name = c.String(),
                        OpenDate = c.DateTime(nullable: false),
                        CloseDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        Worker_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Workers", t => t.Worker_Id)
                .Index(t => t.Worker_Id);
            
            CreateTable(
                "dbo.SpareParts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Manufacturer_Id = c.Int(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturers", t => t.Manufacturer_Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Manufacturer_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.ProductProductions",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Production_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Production_Id })
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Productions", t => t.Production_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Production_Id);
            
            CreateTable(
                "dbo.PurchaseProducts",
                c => new
                    {
                        Purchase_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Purchase_Id, t.Product_Id })
                .ForeignKey("dbo.Purchases", t => t.Purchase_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Purchase_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpareParts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.SpareParts", "Manufacturer_Id", "dbo.Manufacturers");
            DropForeignKey("dbo.Purchases", "Worker_Id", "dbo.Workers");
            DropForeignKey("dbo.Productions", "Worker_Id", "dbo.Workers");
            DropForeignKey("dbo.Orders", "Worker_Id", "dbo.Workers");
            DropForeignKey("dbo.Purchases", "Store_Id", "dbo.Stores");
            DropForeignKey("dbo.PurchaseProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.PurchaseProducts", "Purchase_Id", "dbo.Purchases");
            DropForeignKey("dbo.ProductProductions", "Production_Id", "dbo.Productions");
            DropForeignKey("dbo.ProductProductions", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Productions", "Manufacturer_Id", "dbo.Manufacturers");
            DropIndex("dbo.PurchaseProducts", new[] { "Product_Id" });
            DropIndex("dbo.PurchaseProducts", new[] { "Purchase_Id" });
            DropIndex("dbo.ProductProductions", new[] { "Production_Id" });
            DropIndex("dbo.ProductProductions", new[] { "Product_Id" });
            DropIndex("dbo.SpareParts", new[] { "Product_Id" });
            DropIndex("dbo.SpareParts", new[] { "Manufacturer_Id" });
            DropIndex("dbo.Orders", new[] { "Worker_Id" });
            DropIndex("dbo.Purchases", new[] { "Worker_Id" });
            DropIndex("dbo.Purchases", new[] { "Store_Id" });
            DropIndex("dbo.Productions", new[] { "Worker_Id" });
            DropIndex("dbo.Productions", new[] { "Manufacturer_Id" });
            DropTable("dbo.PurchaseProducts");
            DropTable("dbo.ProductProductions");
            DropTable("dbo.SpareParts");
            DropTable("dbo.Orders");
            DropTable("dbo.Workers");
            DropTable("dbo.Stores");
            DropTable("dbo.Purchases");
            DropTable("dbo.Products");
            DropTable("dbo.Productions");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Managerrs");
            DropTable("dbo.Admins");
        }
    }
}
