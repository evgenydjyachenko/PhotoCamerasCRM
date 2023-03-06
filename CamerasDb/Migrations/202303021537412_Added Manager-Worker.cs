namespace CamerasDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedManagerWorker : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Managerrs", "Managerr_Id", "dbo.Managerrs");
            DropIndex("dbo.Managerrs", new[] { "Managerr_Id" });
            AddColumn("dbo.Workers", "Manager_Id", c => c.Int());
            CreateIndex("dbo.Workers", "Manager_Id");
            AddForeignKey("dbo.Workers", "Manager_Id", "dbo.Managerrs", "Id");
            DropColumn("dbo.Managerrs", "Managerr_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Managerrs", "Managerr_Id", c => c.Int());
            DropForeignKey("dbo.Workers", "Manager_Id", "dbo.Managerrs");
            DropIndex("dbo.Workers", new[] { "Manager_Id" });
            DropColumn("dbo.Workers", "Manager_Id");
            CreateIndex("dbo.Managerrs", "Managerr_Id");
            AddForeignKey("dbo.Managerrs", "Managerr_Id", "dbo.Managerrs", "Id");
        }
    }
}
