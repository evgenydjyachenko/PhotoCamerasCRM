namespace CamerasDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Director : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Admins", newName: "Directors");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Directors", newName: "Admins");
        }
    }
}
