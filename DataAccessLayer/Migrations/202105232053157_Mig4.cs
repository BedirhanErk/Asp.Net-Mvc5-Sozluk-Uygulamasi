namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Writers", "WriterImage", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "WriterImage", c => c.String(maxLength: 100));
        }
    }
}
