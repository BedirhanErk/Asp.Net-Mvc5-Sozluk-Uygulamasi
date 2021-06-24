namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig12_some_status_deleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contacts", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "Status", c => c.Boolean(nullable: false));
        }
    }
}
