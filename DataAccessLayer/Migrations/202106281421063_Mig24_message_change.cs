namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig24_message_change : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "ReceiverStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "SenderStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Messages", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "Status", c => c.Boolean(nullable: false));
            DropColumn("dbo.Messages", "SenderStatus");
            DropColumn("dbo.Messages", "ReceiverStatus");
        }
    }
}
