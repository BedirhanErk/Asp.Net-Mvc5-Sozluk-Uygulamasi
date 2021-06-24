namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig20_admin_delete : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Admins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdminUserName = c.String(maxLength: 50),
                        AdminPassword = c.String(maxLength: 50),
                        AdminRole = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.AdminId);
            
        }
    }
}
