namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedConversionToModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "Src", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "Src");
        }
    }
}
