namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedSorting : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "Sorting", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "Sorting");
        }
    }
}
