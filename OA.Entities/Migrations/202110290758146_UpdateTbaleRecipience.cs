namespace OA.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTbaleRecipience : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Recipience", "DayOfFound");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipience", "DayOfFound", c => c.DateTime(nullable: false));
        }
    }
}
