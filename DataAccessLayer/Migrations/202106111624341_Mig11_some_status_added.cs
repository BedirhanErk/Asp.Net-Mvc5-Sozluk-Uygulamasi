namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig11_some_status_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Status");
            DropColumn("dbo.Contacts", "Status");
        }
    }
}
