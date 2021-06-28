namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig25_message_change : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "ReceiverDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "ReceiverDelete");
        }
    }
}
