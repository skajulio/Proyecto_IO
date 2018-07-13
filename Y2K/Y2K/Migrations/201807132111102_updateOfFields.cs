namespace Y2K.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateOfFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Weathers", "cod", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Weathers", "cod");
        }
    }
}
