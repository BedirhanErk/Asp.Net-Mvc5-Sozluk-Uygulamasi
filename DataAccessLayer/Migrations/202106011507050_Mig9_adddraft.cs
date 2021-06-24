namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig9_adddraft : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Draft", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Draft");
        }
    }
}
