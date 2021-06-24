namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig22_add_skill : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        SkillName = c.String(),
                        SkillPercent = c.Int(nullable: false),
                        SkillValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SkillId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Skills");
        }
    }
}
