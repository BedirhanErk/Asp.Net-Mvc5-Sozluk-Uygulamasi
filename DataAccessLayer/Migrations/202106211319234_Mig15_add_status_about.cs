namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig15_add_status_about : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "Status");
        }
    }
}
