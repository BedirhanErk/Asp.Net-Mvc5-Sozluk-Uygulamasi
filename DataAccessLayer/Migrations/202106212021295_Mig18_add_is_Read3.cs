namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig18_add_is_Read3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contacts", "Read");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "Read", c => c.String());
        }
    }
}
