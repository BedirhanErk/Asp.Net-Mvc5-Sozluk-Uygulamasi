namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig19_add_is_Read4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Read", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "Read");
        }
    }
}
