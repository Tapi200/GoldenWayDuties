namespace GoldenWayDuties.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsHouseResidentToOwner : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Owners", "IsHouseResident", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Owners", "IsHouseResident");
        }
    }
}
