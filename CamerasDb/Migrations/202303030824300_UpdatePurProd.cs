namespace CamerasDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePurProd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Purchases", "Worker_Id", "dbo.Workers");
            DropForeignKey("dbo.Productions", "Worker_Id", "dbo.Workers");
            DropIndex("dbo.Productions", new[] { "Worker_Id" });
            DropIndex("dbo.Purchases", new[] { "Worker_Id" });
            DropColumn("dbo.Productions", "Worker_Id");
            DropColumn("dbo.Purchases", "Worker_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Purchases", "Worker_Id", c => c.Int());
            AddColumn("dbo.Productions", "Worker_Id", c => c.Int());
            CreateIndex("dbo.Purchases", "Worker_Id");
            CreateIndex("dbo.Productions", "Worker_Id");
            AddForeignKey("dbo.Productions", "Worker_Id", "dbo.Workers", "Id");
            AddForeignKey("dbo.Purchases", "Worker_Id", "dbo.Workers", "Id");
        }
    }
}
