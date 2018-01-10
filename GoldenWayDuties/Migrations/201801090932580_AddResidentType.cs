namespace GoldenWayDuties.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddResidentType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResidentTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurataionInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Owners", "ResidentTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Owners", "ResidentTypeId");
            AddForeignKey("dbo.Owners", "ResidentTypeId", "dbo.ResidentTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Owners", "ResidentTypeId", "dbo.ResidentTypes");
            DropIndex("dbo.Owners", new[] { "ResidentTypeId" });
            DropColumn("dbo.Owners", "ResidentTypeId");
            DropTable("dbo.ResidentTypes");
        }
    }
}
