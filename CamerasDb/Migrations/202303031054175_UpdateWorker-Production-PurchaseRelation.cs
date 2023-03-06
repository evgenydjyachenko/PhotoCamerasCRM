namespace CamerasDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateWorkerProductionPurchaseRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productions", "Worker_Id", c => c.Int());
            AddColumn("dbo.Purchases", "Worker_Id", c => c.Int());
            CreateIndex("dbo.Productions", "Worker_Id");
            CreateIndex("dbo.Purchases", "Worker_Id");
            AddForeignKey("dbo.Purchases", "Worker_Id", "dbo.Workers", "Id");
            AddForeignKey("dbo.Productions", "Worker_Id", "dbo.Workers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productions", "Worker_Id", "dbo.Workers");
            DropForeignKey("dbo.Purchases", "Worker_Id", "dbo.Workers");
            DropIndex("dbo.Purchases", new[] { "Worker_Id" });
            DropIndex("dbo.Productions", new[] { "Worker_Id" });
            DropColumn("dbo.Purchases", "Worker_Id");
            DropColumn("dbo.Productions", "Worker_Id");
        }
    }
}
