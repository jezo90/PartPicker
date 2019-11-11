namespace PartPicker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Case", "Fans", c => c.Int(nullable: false));
            DropColumn("dbo.Case", "MaxFan");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Case", "MaxFan", c => c.Int(nullable: false));
            DropColumn("dbo.Case", "Fans");
        }
    }
}
