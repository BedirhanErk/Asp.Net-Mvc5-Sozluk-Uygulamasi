namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig8_addmessageclass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        SenderMail = c.String(maxLength: 80),
                        ReceiverMail = c.String(maxLength: 80),
                        Subject = c.String(maxLength: 100),
                        MessageContent = c.String(),
                        MessageDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Messages");
        }
    }
}
