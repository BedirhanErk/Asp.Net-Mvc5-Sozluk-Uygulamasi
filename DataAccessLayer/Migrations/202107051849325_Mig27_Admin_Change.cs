namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig27_Admin_Change : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "AdminName", c => c.String());
            AlterColumn("dbo.Admins", "AdminStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "AdminStatus", c => c.Int(nullable: false));
            AlterColumn("dbo.Admins", "AdminName", c => c.Int(nullable: false));
        }
    }
}
