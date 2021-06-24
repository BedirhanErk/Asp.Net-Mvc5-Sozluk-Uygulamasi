namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig17_add_is_Read2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Read", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "Read");
        }
    }
}
